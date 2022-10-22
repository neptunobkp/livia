using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class Empresa : LayerSupertype
    {
        public String RazonSocial { get; set; }
        public String Telefono { get; set; }
        public int Rut { get; set; }
        public List<UsuarioContactador> UsuariosRelacionados { get; set; }
    }
}
