using Sacolao.Aplicacao.GestaoDeFrutas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sacolao.Aplicacao.GestaoDeCarrinhos.Modelos
{
    public class FrutaCarrinho
    {
        public FrutaCarrinho(int quantidade, Fruta fruta)
        {
            this.Quantidade = quantidade;
            this.Fruta = fruta;
            this.Total = fruta.Valor * quantidade;
        }

        public int Quantidade { get; set; }
        public decimal Total { get; set; }
        public Fruta Fruta { get; set; }
    }
}
