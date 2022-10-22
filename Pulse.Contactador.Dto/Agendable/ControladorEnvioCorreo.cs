using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class ControladorEnvioCorreo : LayerSupertype
    {
        public ListaCorreoDestino ListaCorreosDestino { get; set; }
        public ConfiguracionSalidaCorreo ConfiguracionSalida { get; set; }
        public TiposEnvioCorreo TipoEnvioCorreo { get; set; }
        public MensajeCorreoDestino MensajeCorreoUnico { get; set; }
    }
}
