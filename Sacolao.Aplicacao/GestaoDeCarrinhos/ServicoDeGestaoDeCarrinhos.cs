using Newtonsoft.Json;
using Sacolao.Aplicacao.ComunicacaoViaHttp;
using Sacolao.Aplicacao.GestaoDeCarrinhos.Modelos;
using Sacolao.Aplicacao.GestaoDeFrutas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sacolao.Aplicacao.GestaoDeCarrinhos
{
    public class ServicoDeGestaoDeCarrinhos : IServicoDeGestaoDeCarrinhos
    {
        private readonly string _urlDaApi;
        private readonly IServicoDeComunicacaoViaHttp _servicoHttp;

        public ServicoDeGestaoDeCarrinhos(string urlDaApi, IServicoDeComunicacaoViaHttp servicoHttp)
        {
            this._urlDaApi = urlDaApi;
            _servicoHttp = servicoHttp;
        }

        public async Task<Carrinho> CadastrarFrutaNoCarrinho(int id, int quantidade)
        {
            try
            {
                var fruta = await this._servicoHttp.Get<Fruta>(new Uri($"{this._urlDaApi}/Fruta/BuscarPorId/{id}"), null);
                
                if(fruta == null)
                    throw new ExcecaoDeAplicacao("Fruta não encontrada.");
                
                if(fruta != null && quantidade > 0)
                    await RealizarBaixaEstoque(id, quantidade);
                
                Random randNum = new Random();
                int idCarrinho = randNum.Next();
                var carrinho = new Carrinho(idCarrinho, fruta, quantidade);
                
                return carrinho;
            }
            catch (InvalidOperationException)
            {
                throw new ExcecaoDeAplicacao("O serviço não está disponível.");
            }
        }

        public async Task<Carrinho> AdicionarFrutaNoCarrinho(Carrinho carrinho, int id, int quantidade)
        {
            try
            {
                var fruta = await this._servicoHttp.Get<Fruta>(new Uri($"{this._urlDaApi}/Fruta/BuscarPorId/{id}"), null);

                if (fruta == null)
                    throw new ExcecaoDeAplicacao("Fruta não encontrada.");

                if (fruta != null && quantidade > 0)
                    await RealizarBaixaEstoque(id, quantidade);

                carrinho.AdicionarFruta(fruta, quantidade);
                carrinho.Recalcular();
                return carrinho;
            }
            catch (InvalidOperationException)
            {
                throw new ExcecaoDeAplicacao("O serviço não está disponível.");
            }
        }

        private async Task<Fruta> RealizarBaixaEstoque(int id , int quantidade)
        {
            var modeloBaixa = new ModeloDeBaixaDeFruta() { Id = id, QuantidadeVenda = quantidade };
            return await this._servicoHttp.PostJson<ModeloDeBaixaDeFruta, Fruta>(new Uri($"{this._urlDaApi}/Fruta/baixarEstoque"), modeloBaixa);
        }
    }
}
