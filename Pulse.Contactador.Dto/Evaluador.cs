using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class Evaluador : LayerSupertype
    {
        public String Correo { get; set; }
        public String Area { get; set; }
        public String Gerencia { get; set; }
        public String Nombre { get; set; }
        public String Guid { get; set; }
    }
}
