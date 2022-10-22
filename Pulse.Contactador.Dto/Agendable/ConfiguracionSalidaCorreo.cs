using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class ConfiguracionSalidaCorreo : LayerSupertype
    {
        public String ServidorSmtp { get; set; }
        public String PuertoServidor { get; set; }
        public String SSLHabilitado { get; set; }
        public bool ConCredenciales { get; set; }
        public String Usuario { get; set; }
        public String Contrasenia { get; set; }
        public String CorreoCasillaSalida { get; set; }
        public String NombreCasillaSalda { get; set; }
    }
}
