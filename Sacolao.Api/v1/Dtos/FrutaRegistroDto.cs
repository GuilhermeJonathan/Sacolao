using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sacolao.Api.v1.Dtos
{
    /// <summary>
    /// DTO para registro de Frutas
    /// </summary>
    public class FrutaRegistroDto
    {
        /// <summary>
        /// Identificador da Fruta
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome da Fruta {string}
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Descrição da Fruta {string}
        /// </summary>
        public string Descricao { get; set; }
        /// <summary>
        /// Url da Foto
        /// </summary>
        public string Foto { get; set; }
        /// <summary>
        /// Quantidade no estoque {int}
        /// </summary>
        public int QuantidadeEstoque { get; set; }
        /// <summary>
        /// Valor da Fruta {decimal}
        /// </summary>
        public decimal Valor { get; set; }
    }
}
