using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class Usuario : Persona
    {
        public String NombreIngreso { get; set; }
        public String Clave { get; set; }
    }
}
