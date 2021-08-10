using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sacolao.Api.Data;
using Sacolao.Api.Models;
using Sacolao.Api.v1.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sacolao.Api.v1.Controllers
{
    /// <summary>
    /// FrutaController
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class FrutaController : ControllerBase
    {
        public readonly IRepository _repo;
        private readonly IMapper _mapper;

        public FrutaController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        /// <summary>
        /// /Método Responsável para retornar todas frutas
        /// </summary>
        /// <returns></returns>
        [HttpGet("BuscarFrutas")]
        public IActionResult Get()
        {
            var frutas = _repo.GetAllFrutas();
            var retorno = _mapper.Map<IEnumerable<FrutaDto>>(frutas);

            if (retorno != null)
                return Ok(retorno);

            return BadRequest("Frutas não encontradas.");
        }

        /// <summary>
        /// /Método Responsável para retornar frutas por nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorNome/{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            var frutas = _repo.GetFrutaByName(nome);
            var retorno = _mapper.Map<IEnumerable<FrutaDto>>(frutas);

            if (retorno != null)
                return Ok(retorno);

            return BadRequest("Frutas não encontradas.");
        }

        /// <summary>
        /// Método responsável por realizar busca de uma fruta por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(int id)
        {
            var fruta = _repo.GetFrutaById(id);

            var frutaDto = _mapper.Map<FrutaDto>(fruta);

            if (frutaDto != null)
                return Ok(frutaDto);

            return BadRequest("Fruta não encontrada.");
        }

        /// <summary>
        /// Método responsável para cadastrar uma Fruta
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("cadastrarFruta")]
        public IActionResult Post(FrutaRegistroDto model)
        {
            var frutaNova = _mapper.Map<Fruta>(model);

            _repo.Add(frutaNova);

            if (_repo.SaveChanges())
                return Created($"/api/fruta/{model.Id}", _mapper.Map<FrutaDto>(frutaNova));

            return BadRequest("Fruta não cadastrada.");
        }

        /// <summary>
        /// Método responsável para atualizar qualquer campo de uma Fruta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("salvarFruta/{id}")]
        public IActionResult SalvarFruta(int id, FrutaRegistroDto model)
        {
            var fruta = _repo.GetFrutaById(id);

            if (fruta == null)
                return BadRequest("Não encontrou nenhuma fruta para ser atualizada.");

            _mapper.Map(model, fruta);

            _repo.Update(fruta);

            if (_repo.SaveChanges())
                return Ok(fruta);

            return BadRequest("Fruta não atualizada.");
        }

        /// <summary>
        /// Método responsável por excluir uma determinada Fruta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("excluirFruta/{id}")]
        public IActionResult Delete(int id)
        {
            var fruta = _repo.GetFrutaById(id);

            if (fruta == null)
                return BadRequest("Não encontrou nenhuma fruta para ser excluída.");

            _repo.Delete(fruta);

            if (_repo.SaveChanges())
                return Ok();

            return BadRequest("Fruta não excluída.");
        }
    }
}
