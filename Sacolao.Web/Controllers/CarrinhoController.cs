using Microsoft.AspNetCore.Mvc;
using Sacolao.Aplicacao.GestaoDeCarrinhos.Modelos;
using Sacolao.Aplicacao.GestaoDeFrutas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sacolao.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        public IActionResult Index(ModeloDeFiltroDeFrutas filtro)
        {
            return View();
        }

        public IActionResult Cadastrar(ModeloDeCadastroDeCarrinho modelo)
        {
            return View();
        }

        public IActionResult AdicionarNoCarrinho(int id, int total)
        {
            var modelo = new ModeloDeCadastroDeCarrinho() { IdFruta = id, Total = total };
            return RedirectToAction(nameof(Cadastrar), modelo);
        }
    }
}
