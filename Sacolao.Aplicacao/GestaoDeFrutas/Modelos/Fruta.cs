using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sacolao.Aplicacao.GestaoDeFrutas.Modelos
{
    public class Fruta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public int QuantidadeEstoque { get; set; }
        public decimal Valor { get; set; }
    }
}
