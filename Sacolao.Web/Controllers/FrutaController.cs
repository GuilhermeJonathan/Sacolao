using Microsoft.AspNetCore.Mvc;
using Sacolao.Aplicacao.GestaoDeFrutas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sacolao.Web.Controllers
{
    public class FrutaController : Controller
    {
        private readonly IServicoDeGestaoDeFrutas _servicoDeGestaoDeFrutas;

        public FrutaController(IServicoDeGestaoDeFrutas servicoDeGestaoDeFrutas)
        {
            _servicoDeGestaoDeFrutas = servicoDeGestaoDeFrutas;
        }

        public async Task<IActionResult> Index()
        {
            var frutas = await _servicoDeGestaoDeFrutas.BuscarTodasAsFrutas();
            return View();
        }
    }
}
