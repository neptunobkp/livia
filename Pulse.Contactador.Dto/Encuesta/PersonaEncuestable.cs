using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class PersonaEncuestable : Persona
    {
        public String CorreoIntermediarioEncuesta { get; set; }
    }
}
