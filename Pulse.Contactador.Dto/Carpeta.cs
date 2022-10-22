using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class CarpetaEncuesta : LayerSupertype
    {
        public List<ItemCarpetaEncuesta> ItemsCarpetaEncuesta { get; set; }
        public List<RelacionCarpetaEncuesta> Relaciones { get; set; }
        public String Nombre { get; set; }
    }
}
