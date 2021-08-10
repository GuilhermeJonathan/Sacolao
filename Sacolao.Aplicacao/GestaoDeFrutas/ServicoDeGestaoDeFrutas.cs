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

        public async Task<List<ModeloDeFrutasDaLista>> BuscarTodasAsFrutas()
        {
            try
            {
                return await this._servicoHttp.Get<List<ModeloDeFrutasDaLista>>(new Uri($"{this._urlDaApi}/Fruta/BuscarFrutas"), null);
            }
            catch (InvalidOperationException)
            {
                throw new ExcecaoDeAplicacao("O serviço não está disponível.");
            }

            return null;
        }
    }
}
