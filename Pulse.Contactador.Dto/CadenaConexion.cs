using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class CadenaConexion : LayerSupertype
    {
        public String Alias { get; set; }
        public String Servidor { get; set; }
        public String BaseDatos { get; set; }
        public String NombreUsuario { get; set; }
        public String Contrasenia { get; set; }
        public String IdentificadorServidor { get; set; }
        public String CadenaConfigurada { get; set; }
        public String Puerto { get; set; }
        public TiposMotorBaseDatos TipoMotorBaseDatos { get; set; }
    }
}
