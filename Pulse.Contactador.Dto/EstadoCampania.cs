using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class EstadoCampania : LayerSupertype
    {
        public Campania Campania { get; set; }
        public DateTime FechaEjecutada { get; set; }
    }
}
