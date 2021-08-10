using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sacolao.Aplicacao.ComunicacaoViaHttp
{
    public interface IServicoDeComunicacaoViaHttp
    {
        Task<T> Get<T>(Uri url, IDictionary<string, string> parametros = null,
           IDictionary<string, string> cabecalho = null);
    }
}
