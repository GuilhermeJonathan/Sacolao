using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sacolao.Api.v1.Dtos
{
    public class FrutaDto
    {
        /// <summary>
        /// Identificador da Fruta
        /// </summary>
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public int QuantidadeEstoque { get; set; }
        public decimal Valor { get; set; }
    }
}
