using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sacolao.Aplicacao
{
    public class ExcecaoDeAplicacao : Exception
    {
        public ExcecaoDeAplicacao(string message) : base(message)
        {
        }
    }
}
