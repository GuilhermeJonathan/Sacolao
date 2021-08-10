using Sacolao.Aplicacao.GestaoDeFrutas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sacolao.Aplicacao.GestaoDeFrutas
{
    public interface IServicoDeGestaoDeFrutas
    {
        Task<List<ModeloDeFrutasDaLista>> BuscarTodasAsFrutas();
    }
}
