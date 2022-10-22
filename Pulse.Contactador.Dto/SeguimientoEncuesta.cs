using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class SeguimientoEncuesta
    {
        public Evaluador Evaluador { get; set; }
        public Encuesta Encuesta { get; set; }
        public String CuerpoCorreo { get; set; }
        public DateTime FechaUltimoEnvio { get; set; }
        public int CantidadRecordatorios { get; set; }
    }
}
