using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class UsuarioContactador : Usuario
    {
        public bool PuedeVerResultados { get; set; }
        public Seguridad.Perfil Perfil { get; set; }
    }
}
