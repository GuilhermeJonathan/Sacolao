using Microsoft.AspNetCore.Mvc;
using Sacolao.Aplicacao.GestaoDeFrutas;
using Sacolao.Aplicacao.GestaoDeFrutas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sacolao.Web.CustomExtensions;

namespace Sacolao.Web.Controllers
{
    public class FrutaController : Controller
    {
        [TempData]
        public string MensagemDeSucesso { get; set; }
        [TempData]
        public string MensagemDeErro { get; set; }

        private readonly IServicoDeGestaoDeFrutas _servicoDeGestaoDeFrutas;

        public FrutaController(IServicoDeGestaoDeFrutas servicoDeGestaoDeFrutas)
        {
            _servicoDeGestaoDeFrutas = servicoDeGestaoDeFrutas;
        }

        public async Task<IActionResult> Index(ModeloDeFiltroDeFrutas filtro)
        {
            var lista = await _servicoDeGestaoDeFrutas.BuscarTodasAsFrutas(filtro);
            return View(lista);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var retorno = await _servicoDeGestaoDeFrutas.BuscarFrutaPorId(id);
            return View(retorno);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(ModeloDeEdicaoDeFruta modelo)
        {
            var retorno = await _servicoDeGestaoDeFrutas.SalvarFruta(modelo);

            if (retorno != null)
                MensagemDeSucesso = "Fruta salva com sucesso.";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            var modelo = new ModeloDeCadastroDeFruta();
            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(ModeloDeCadastroDeFruta modelo)
        {
            var retorno = await _servicoDeGestaoDeFrutas.CadastrarFruta(modelo);

            if (retorno == null)
                MensagemDeErro = "Não foi possível realizar cadastro.";
            
            MensagemDeSucesso = "Fruta cadastrada com sucesso.";

            return RedirectToAction(nameof(Index));
        }
    }
}
