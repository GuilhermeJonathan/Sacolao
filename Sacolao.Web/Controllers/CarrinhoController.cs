using Microsoft.AspNetCore.Mvc;
using Sacolao.Aplicacao.GestaoDeCarrinhos;
using Sacolao.Aplicacao.GestaoDeCarrinhos.Modelos;
using Sacolao.Aplicacao.GestaoDeFrutas.Modelos;
using Sacolao.Web.CustomExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sacolao.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        [TempData]
        public string MensagemDeSucesso { get; set; }
        [TempData]
        public string MensagemDeErro { get; set; }

        private readonly IServicoDeGestaoDeCarrinhos _servicoDeGestaoDeCarrinhos;

        public CarrinhoController(IServicoDeGestaoDeCarrinhos servicoDeGestaoDeCarrinhos)
        {
            _servicoDeGestaoDeCarrinhos = servicoDeGestaoDeCarrinhos;
        }

        public IActionResult Index()
        {
            var carrinho = HttpContext.Session.Get<Carrinho>($"carrinho");
            if (carrinho != null)
            {
                var modelo = new ModeloDeEdicaoDeCarrinho(carrinho);
                return View(modelo);
            }

            return View(new ModeloDeEdicaoDeCarrinho());
        }

        public IActionResult Editar(int id)
        {
            var carrinho = HttpContext.Session.Get<Carrinho>($"carrinho");
            if (carrinho != null)
            {
                var modelo = new ModeloDeEdicaoDeCarrinho(carrinho);
                return View(modelo);
            }

            return View(new ModeloDeEdicaoDeCarrinho());
        }

        [HttpGet]
        public async Task<IActionResult> AdicionarNoCarrinho(int id, int total)
        {
            var idCarrinho = 0;

            if (HttpContext.Session.Get<Carrinho>($"carrinho") == null)
            {
                var carrinho = await this._servicoDeGestaoDeCarrinhos.CadastrarFrutaNoCarrinho(id, total);
                HttpContext.Session.Set<Carrinho>($"carrinho", carrinho);
            } else
            {
                var carrinhoSessao = HttpContext.Session.Get<Carrinho>($"carrinho");
                var carrinho = await this._servicoDeGestaoDeCarrinhos.AdicionarFrutaNoCarrinho(carrinhoSessao, id, total);
                HttpContext.Session.Set<Carrinho>($"carrinho", carrinho);
            }

            var modelo = new ModeloDeCadastroDeCarrinho() { IdFruta = id, Total = total };
            return RedirectToAction(nameof(Editar), idCarrinho);
        }

        [HttpPost]
        public IActionResult Finalizar()
        {
            var carrinho = HttpContext.Session.Get<Carrinho>($"carrinho");
            if (carrinho != null)
            {
                HttpContext.Session.Remove("carrinho");
                MensagemDeSucesso = "Compra Finalizada com sucesso.";
            }
            else
                MensagemDeErro = "Não foi possível Finalizar.";

            return RedirectToAction("Index", "Home");
        }
    }
}
