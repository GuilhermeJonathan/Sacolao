using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sacolao.Api.Data;
using Sacolao.Api.v1.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sacolao.Api.v1.Controllers
{
    /// <summary>
    /// LoginController
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly IRepository _repo;
        private readonly IMapper _mapper;

        public LoginController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        /// <summary>
        /// Método responsável por realizar Login de usuário
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("usuario")]
        public IActionResult Post(ModeloLoginUsuario model)
        {
            var usuario = _repo.LoginUsuario(model.Email, model.Senha);

            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);

            if (usuario != null)
                return Ok(usuarioDto);
            
            return BadRequest("Usuário ou senha inválidos.");
        }
    }
}
