using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sacolao.Api.v1.Dtos
{
    public class FrutaEstoqueDto
    {
        /// <summary>
        /// Identificador da Fruta
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Quantidade no estoque {int}
        /// </summary>
        public int QuantidadeVenda { get; set; }
    }
}
