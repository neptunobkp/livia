using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class EvaluadorEncuesta
    {
        public Evaluador Evaluador { get; set; }
        public Encuesta Encuesta { get; set; }
        public int Estado { get; set; }
        public int Obligatoriedad { get; set; }
        public String Guid { get; set; }
    }
}
