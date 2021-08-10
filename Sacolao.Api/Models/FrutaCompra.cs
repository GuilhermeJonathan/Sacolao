using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sacolao.Api.Models
{
    public class FrutaCompra
    {
        public FrutaCompra() { }

        public FrutaCompra(int frutaId, int compraId)
        {
            this.FrutaId = frutaId;
            this.CompraId = compraId;
        }

        public int FrutaId { get; set; }
        public Fruta Fruta { get; set; }
        public int CompraId { get; set; }
        public Compra Compra { get; set; }
    }
}
