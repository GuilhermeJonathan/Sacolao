using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sacolao.Api.Models
{
    public class Compra
    {
        public Compra() { }

        public Compra(int id, decimal valor)
        {
            this.Id = id;
            this.Valor = valor;
        }

        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime? DataCadastro { get; set; } = DateTime.Now;
        public IEnumerable<Fruta> Frutas  { get; set; }
    }
}
