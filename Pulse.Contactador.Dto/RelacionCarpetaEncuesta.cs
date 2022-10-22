using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class RelacionCarpetaEncuesta : LayerSupertype
    {
        public CarpetaEncuesta CarpetaEncuesta { get; set; }
        public Encuesta Encuesta { get; set; }
    }
}
