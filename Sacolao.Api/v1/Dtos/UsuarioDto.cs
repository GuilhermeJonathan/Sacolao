using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sacolao.Api.v1.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}
