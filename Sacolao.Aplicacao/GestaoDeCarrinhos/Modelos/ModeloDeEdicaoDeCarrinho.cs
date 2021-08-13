using Sacolao.Aplicacao.GestaoDeFrutas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sacolao.Aplicacao.GestaoDeCarrinhos.Modelos
{
    public class ModeloDeEdicaoDeCarrinho
    {
        public ModeloDeEdicaoDeCarrinho()
        {
            this.Id = 0;
            this.Frutas = new List<ModeloDeFrutaCarrinhoDaLista>();
        }

        public ModeloDeEdicaoDeCarrinho(Carrinho carrinho) : this()
        {
            if (carrinho == null)
                return;

            this.Id = carrinho.Id;
            this.TotalProdutos = carrinho.TotalProdutos.ToString();
            this.Valor = carrinho.Valor.ToString("F");
            carrinho.Frutas.ToList().ForEach(a => this.Frutas.Add(new ModeloDeFrutaCarrinhoDaLista(a)));
        }

        public int Id { get; set; }
        public string TotalProdutos { get; set; }
        public string Valor { get; set; }
        public IList<ModeloDeFrutaCarrinhoDaLista> Frutas { get; set; }
    }
}
