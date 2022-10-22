using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class EntidadParametrizable : LayerSupertype
    {
        public String Codigo { get; set; }
        public String Glosa { get; set; }
    }
}
