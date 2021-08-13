using Sacolao.Aplicacao.GestaoDeFrutas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sacolao.Aplicacao.GestaoDeCarrinhos.Modelos
{
    public class Carrinho
    {
        public Carrinho()
        {
            this.Frutas = new List<FrutaCarrinho>();
        }

        public Carrinho(int id, Fruta fruta, int quantidade) : this()
        {
            if (fruta != null)
                this.Frutas.Add(new FrutaCarrinho(quantidade, fruta));
            
            this.Id = id;
            this.Recalcular();
        }

        public int Id { get; set; }
        public int TotalProdutos { get; set; }
        public decimal Valor { get; set; }
        public ICollection<FrutaCarrinho> Frutas { get; set; }

        public void AdicionarFruta(Fruta fruta, int quantidade)
        {
            if (fruta != null)
            {
                if (this.Frutas.Any(a => a.Fruta.Id.Equals(fruta.Id)))
                {
                    var frutaSelecionada = this.Frutas.FirstOrDefault(a => a.Fruta.Id.Equals(fruta.Id));
                    frutaSelecionada.Quantidade += quantidade;
                    frutaSelecionada.Total = frutaSelecionada.Quantidade * fruta.Valor;
                } else 
                    this.Frutas.Add(new FrutaCarrinho(quantidade, fruta));
            }
        }

        public void Recalcular()
        {
            this.TotalProdutos = this.Frutas.Sum(a => a.Quantidade);
            this.Valor = this.Frutas.Sum(a => a.Total);
        }
    }
}
