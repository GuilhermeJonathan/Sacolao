using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sacolao.Aplicacao.GestaoDeFrutas.Modelos
{
    public class ModeloDeEdicaoDeFruta
    {
        public ModeloDeEdicaoDeFruta()
        {

        }

        public ModeloDeEdicaoDeFruta(Fruta fruta)
        {
            this.Id = fruta.Id;
            this.Nome = fruta.Nome;
            this.Descricao = fruta.Descricao;
            this.Foto = fruta.Foto;
            this.QuantidadeEstoque = fruta.QuantidadeEstoque.ToString();
            this.Valor = fruta.Valor.ToString();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public string QuantidadeEstoque { get; set; }
        public string Valor { get; set; }
    }
}
