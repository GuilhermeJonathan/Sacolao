using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sacolao.Aplicacao.GestaoDeFrutas.Modelos
{
    public class ModeloDeCadastroDeFruta
    {
        public ModeloDeCadastroDeFruta()
        {

        }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public string QuantidadeEstoque { get; set; }
        public string Valor { get; set; }
    }
}
