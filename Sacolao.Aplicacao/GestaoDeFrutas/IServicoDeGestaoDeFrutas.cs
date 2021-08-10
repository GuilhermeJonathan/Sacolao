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
        Task<ModeloDeListaDeFrutas> BuscarTodasAsFrutas(ModeloDeFiltroDeFrutas filtro);
        Task<ModeloDeEdicaoDeFruta> BuscarFrutaPorId(int id);
        Task<ModeloDeEdicaoDeFruta> SalvarFruta(ModeloDeEdicaoDeFruta modelo);
        Task<ModeloDeEdicaoDeFruta> CadastrarFruta(ModeloDeCadastroDeFruta modelo);
        Task<bool> ExcluirFruta(int id);
    }
}
