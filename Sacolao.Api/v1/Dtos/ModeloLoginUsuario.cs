using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sacolao.Api.v1.Dtos
{
    public class ModeloLoginUsuario
    {
        /// <summary>
        /// Email de usuário {string}
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Senha de usuário {string}
        /// </summary>
        public string Senha { get; set; }
    }
}
