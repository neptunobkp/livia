using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class ItemResultadoEncuesta
    {
        public String Glosa { get; set; }
        public decimal Porcentaje { get; set; }
        public int Cantidad { get; set; }
    }
}
