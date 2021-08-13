using Sacolao.Aplicacao.GestaoDeCarrinhos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sacolao.Aplicacao.GestaoDeCarrinhos
{
    public interface IServicoDeGestaoDeCarrinhos
    {
        Task<Carrinho> CadastrarFrutaNoCarrinho(int id, int quantidade);
        Task<Carrinho> AdicionarFrutaNoCarrinho(Carrinho carrinho, int id, int quantidade);
    }
}
