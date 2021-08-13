using Sacolao.Aplicacao.GestaoDeFrutas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sacolao.Aplicacao.GestaoDeCarrinhos.Modelos
{
    public class ModeloDeFrutaCarrinhoDaLista
    {
        public ModeloDeFrutaCarrinhoDaLista(FrutaCarrinho frutaCarrinho)
        {
            if (frutaCarrinho == null)
                return;

            this.Quantidade = frutaCarrinho.Quantidade;
            this.Total = frutaCarrinho.Total.ToString("F");
            this.Fruta = new ModeloDeFrutasDaLista(frutaCarrinho.Fruta);
        }

        public int Quantidade { get; set; }
        public string Total { get; set; }
        public ModeloDeFrutasDaLista Fruta { get; set; }
    }
}
