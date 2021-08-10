using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sacolao.Api.Models
{
    public class Fruta
    {
        public Fruta() { }

        public Fruta(int id, string nome, string descricao, string foto, int quantidadeEstoque, decimal valor)
        {
            this.Id = id;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Foto = foto;
            this.QuantidadeEstoque = quantidadeEstoque;
            this.Valor = valor;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public int QuantidadeEstoque { get; set; }
        public decimal Valor { get; set; }
        public IEnumerable<Compra> Compras { get; set; }
    }
}
