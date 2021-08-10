using Newtonsoft.Json;
using Sacolao.Aplicacao.ComunicacaoViaHttp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sacolao.Infraestrutura
{
    public class ServicoDeComunicacaoViaHttp : IServicoDeComunicacaoViaHttp
    {
        public const string ApplicationJson = "application/json";
        public const string FormUrlEncoded = "application/x-www-form-urlencoded";

        private HttpClient _clienteHttp;

        public ServicoDeComunicacaoViaHttp()
        {
            this._clienteHttp = new HttpClient();
        }

        public async Task<T> Get<T>(Uri url, IDictionary<string, string> parametros = null,
            IDictionary<string, string> cabecalho = null)
        {
            var urlCompleta = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(urlCompleta.Query);

            if (parametros != null)
            {
                foreach (var parametro in parametros)
                {
                    query.Add(parametro.Key, parametro.Value);
                }
            }

            this.MontarCabecalho(cabecalho);
            
            urlCompleta.Query = query.ToString();

            try
            {
                using (var resposta = await this._clienteHttp.GetAsync(urlCompleta.Uri, HttpCompletionOption.ResponseContentRead))
                {
                    resposta.EnsureSuccessStatusCode();

                    var conteudoDaResposta = await resposta.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(conteudoDaResposta);
                };
            }
            catch (HttpRequestException ex)
            {
                throw new InvalidOperationException("Servidor indisponível");
            }
        }

        public async Task<TRetorno> PostJson<T, TRetorno>(Uri url, T dados, IDictionary<string, string> cabecalho = null)
        {
            var resposta = await this.Post<dynamic>(url, dados, cabecalho, this.MontarConteudoJson);
            return JsonConvert.DeserializeObject<TRetorno>(resposta);
        }

        public async Task<TRetorno> PutJson<T, TRetorno>(Uri url, T dados, KeyValuePair<string, string> tokenDeAutorizacao = default(KeyValuePair<string, string>), IDictionary<string, string> cabecalho = null)
        {
            var resposta = await this.Put<dynamic>(url, dados, cabecalho, this.MontarConteudoJson);
            return JsonConvert.DeserializeObject<TRetorno>(resposta);
        }

        private async Task<string> Put<T>(Uri url, T dados, IDictionary<string, string> cabecalho,
            Func<object, HttpContent> montarConteudo)
        {
            this.MontarCabecalho(cabecalho);

            using (var conteudo = montarConteudo.Invoke(dados))
            {
                try
                {
                    using (var resposta = await this._clienteHttp.PutAsync(url, conteudo))
                    {
                        if (!resposta.IsSuccessStatusCode)
                            throw new HttpRequestException();

                        return await resposta.Content.ReadAsStringAsync();
                    }
                }
                catch (HttpRequestException)
                {
                    throw new InvalidOperationException("Servidor indisponível");
                }
            }
        }

        private async Task<string> Post<T>(Uri url, T dados, IDictionary<string, string> cabecalho,
            Func<object, HttpContent> montarConteudo)
        {
            this.MontarCabecalho(cabecalho);

            using (var conteudo = montarConteudo.Invoke(dados))
            {
                try
                {
                    using (var resposta = await this._clienteHttp.PostAsync(url, conteudo))
                    {
                        if (!resposta.IsSuccessStatusCode)
                            throw new HttpRequestException();

                        return await resposta.Content.ReadAsStringAsync();
                    }
                }
                catch (HttpRequestException)
                {
                    throw new InvalidOperationException("Servidor indisponível");
                }
            }
        }

        private void MontarCabecalho(IDictionary<string, string> cabecalho)
        {
            if (cabecalho == null || !cabecalho.Any())
                return;

            this._clienteHttp.DefaultRequestHeaders.Clear();

            if (cabecalho != null)
            {
                foreach (var linha in cabecalho)
                {
                    this._clienteHttp.DefaultRequestHeaders.Add(linha.Key, linha.Value);
                }
            }
        }

        private HttpContent MontarConteudoJson<T>(T conteudo)
        {
            if (conteudo == null)
                return new StringContent("");

            return new StringContent(JsonConvert.SerializeObject(conteudo), Encoding.UTF8, ApplicationJson);
        }
        public void Dispose()
        {
            if (this._clienteHttp != null)
                this._clienteHttp.Dispose();

            GC.SuppressFinalize(this);
        }

        Task<string> IServicoDeComunicacaoViaHttp.Post<T>(Uri url, T dados, IDictionary<string, string> cabecalho, Func<object, HttpContent> montarConteudo)
        {
            throw new NotImplementedException();
        }
    }
}
