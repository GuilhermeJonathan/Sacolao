using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sacolao.Web.CustomExtensions
{
    public class ControllerExtensions
    {
        public ControllerExtensions(string mensagemDeSucesso, string mensagemDeErro)
        {
            MensagemDeSucesso = mensagemDeSucesso;
            MensagemDeErro = mensagemDeErro;
        }

        [TempData]
        public string MensagemDeSucesso { get; set; }
        [TempData]
        public string MensagemDeErro { get; set; }

        public void AdicionarMensagemDeSucesso(string mensagem)
        {
            this.MensagemDeSucesso = mensagem;
        }

        public void AdicionarMensagemDeErro(string mensagem)
        {
            this.MensagemDeErro = mensagem;
        }
    }
}
