using Sacolao.Aplicacao.ComunicacaoViaHttp;
using Sacolao.Aplicacao.GestaoDeFrutas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sacolao.Aplicacao.GestaoDeFrutas
{
    public class ServicoDeGestaoDeFrutas : IServicoDeGestaoDeFrutas
    {
        private readonly string _urlDaApi;
        private readonly IServicoDeComunicacaoViaHttp _servicoHttp;

        public ServicoDeGestaoDeFrutas(string urlDaApi, IServicoDeComunicacaoViaHttp servicoHttp)
        {
            this._urlDaApi = urlDaApi;
            _servicoHttp = servicoHttp;
        }

        public async Task<ModeloDeListaDeFrutas> BuscarTodasAsFrutas(ModeloDeFiltroDeFrutas filtro)
        {
            try
            {
                var retorno = await this._servicoHttp.Get<List<Fruta>>(new Uri($"{this._urlDaApi}/Fruta/BuscarFrutas"), null);
                return new ModeloDeListaDeFrutas(retorno, retorno.Count, filtro);
            }
            catch (InvalidOperationException)
            {
                throw new ExcecaoDeAplicacao("O serviço não está disponível.");
            }
        }

        public async Task<ModeloDeEdicaoDeFruta> BuscarFrutaPorId(int id)
        {
            try
            {
                var retorno = await this._servicoHttp.Get<Fruta>(new Uri($"{this._urlDaApi}/Fruta/byId/{id}"), null);
                return new ModeloDeEdicaoDeFruta(retorno);
            }
            catch (InvalidOperationException)
            {
                throw new ExcecaoDeAplicacao("O serviço não está disponível.");
            }
        }

        public async Task<ModeloDeEdicaoDeFruta> SalvarFruta(ModeloDeEdicaoDeFruta modelo)
        {
            try
            {
                if (!String.IsNullOrEmpty(modelo.Valor))
                    modelo.Valor = modelo.Valor.Replace(",", String.Empty).Replace(".", String.Empty);

                var retorno = await this._servicoHttp.PutJson<ModeloDeEdicaoDeFruta, Fruta>(new Uri($"{this._urlDaApi}/Fruta/salvarFruta/{modelo.Id}"),
                    modelo);

                return new ModeloDeEdicaoDeFruta(retorno);
            }
            catch (InvalidOperationException)
            {
                throw new ExcecaoDeAplicacao("O serviço não está disponível.");
            }
        }

        public async Task<ModeloDeEdicaoDeFruta> CadastrarFruta(ModeloDeCadastroDeFruta modelo)
        {
            try
            {
                if (!String.IsNullOrEmpty(modelo.Valor))
                    modelo.Valor = modelo.Valor.Replace(",", String.Empty).Replace(".", String.Empty);

                var retorno = await this._servicoHttp.PostJson<ModeloDeCadastroDeFruta, Fruta>(new Uri($"{this._urlDaApi}/Fruta/cadastrarFruta"),
                    modelo);

                return new ModeloDeEdicaoDeFruta(retorno);
            }
            catch (InvalidOperationException)
            {
                throw new ExcecaoDeAplicacao("O serviço não está disponível.");
            }
        }
    }
}
