using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class ReporteEncuesta
    {
        public String NombreEncuestador { get; set; }
        public String Area { get; set; }
        public String Gerencia { get; set; }
        public String Encuesta { get; set; }
        public String GerenciaArea { get; set; }
        public String Variable { get; set; }
        public String Pregunta { get; set; }
        public String Nota { get; set; }
    }
}
