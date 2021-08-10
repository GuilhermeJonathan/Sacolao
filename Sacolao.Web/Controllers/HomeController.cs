using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sacolao.Aplicacao.GestaoDeFrutas;
using Sacolao.Aplicacao.GestaoDeFrutas.Modelos;
using Sacolao.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Sacolao.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServicoDeGestaoDeFrutas _servicoDeGestaoDeFrutas;

        public HomeController(ILogger<HomeController> logger, IServicoDeGestaoDeFrutas servicoDeGestaoDeFrutas)
        {
            _servicoDeGestaoDeFrutas = servicoDeGestaoDeFrutas;
            _logger = logger;
        }

        public async Task<IActionResult> Index(ModeloDeFiltroDeFrutas filtro)
        {
            var lista = await _servicoDeGestaoDeFrutas.BuscarTodasAsFrutas(filtro);
            return View(lista);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
