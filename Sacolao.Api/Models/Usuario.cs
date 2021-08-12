using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sacolao.Api.Models
{
    public class Usuario
    {
        public Usuario() {}

        public Usuario(int id, string nome, string email, string senha)
        {
            this.Id = id;
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public bool Ativo { get; private set; } = true;
    }
}
