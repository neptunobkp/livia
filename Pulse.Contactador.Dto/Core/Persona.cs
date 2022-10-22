using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class Persona : LayerSupertype
    {
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public int Rut { get; set; }
        public String Dv { get; set; }
        public String Correo { get; set; }
        public String Telefono { get; set; }
        public String Celular { get; set; }
    }
}
