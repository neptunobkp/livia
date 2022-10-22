using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto.Seguridad
{
    [Serializable]
    public class Perfil : LayerSupertype
    {
        public String Nombre { get; set; }
        public List<Modulo> ModulosDisponibles { get; set; }
    }
}
