using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sacolao.Aplicacao.GestaoDeFrutas.Modelos
{
    public class ModeloDeListaDeFrutas
    {
        public ModeloDeListaDeFrutas()
        {
            this.Filtro = new ModeloDeFiltroDeFrutas();
            this.Lista = new List<ModeloDeFrutasDaLista>();
        }

        public ModeloDeListaDeFrutas(IEnumerable<Fruta> lista, int totalDeRegistros, ModeloDeFiltroDeFrutas filtro = null) : this()
        {
            if (lista == null)
                return;

            if (filtro != null)
                this.Filtro = filtro;

            this.TotalDeRegistros = totalDeRegistros;
            lista.ToList().ForEach(a => this.Lista.Add(new ModeloDeFrutasDaLista(a)));
        }

        public ModeloDeFiltroDeFrutas Filtro { get; private set; }
        public List<ModeloDeFrutasDaLista> Lista { get; private set; }
        public int TotalDeRegistros { get; private set; }
    }
}
