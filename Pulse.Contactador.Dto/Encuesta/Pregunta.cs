using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class Pregunta : LayerSupertype
    {
        /// <summary>
        /// largo 500
        /// </summary>
        public String GlosaPregunta { get; set; }
        public String NotaAdicionalPregunta { get; set; }
        public String NotaAdicionalFinalPregunta { get; set; }
        public TiposPregunta TipoPregunta { get; set; }
        public String Codigo { get; set; }
        public bool Obligatorio { get; set; }
        public int NumeroPagina { get; set; }
        public String CategoriaPregunta { get; set; }
    }
}
