using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class ControlPlantilla
    {
        public String ToolTipControl{ get; set; }
        public String Texto { get; set; }
        public int Largo { get; set; }
        public int Ancho { get; set; }
        public bool EsImagen { get; set; }
        public String PathImagen { get; set; }
        public String TextoAlternativo { get; set; }
    }
}
