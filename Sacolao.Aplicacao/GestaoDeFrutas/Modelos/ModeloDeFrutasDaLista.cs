using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sacolao.Aplicacao.GestaoDeFrutas.Modelos
{
    public class ModeloDeFrutasDaLista
    {
        public ModeloDeFrutasDaLista(Fruta fruta)
        {
            this.Id = fruta.Id;
            this.Nome = fruta.Nome;
            this.Descricao = fruta.Descricao;
            this.Caminho = $"/images/{fruta.Foto}";
            this.Quantidade = fruta.QuantidadeEstoque.ToString();
            this.Valor = fruta.Valor.ToString("F");
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Caminho { get; set; }
        public string Quantidade { get; set; }
        public string Total { get; set; }
        public string Valor { get; set; }

    }
}
