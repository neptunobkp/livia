using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dto.Agendable;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class CorreoDestino : LayerSupertype
    {
        public PersonaDestinatario Destinatario { get; set; }
        public String IdentificadorRelacionalOrigen { get; set; }
        public MensajeCorreoDestino Mensaje { get; set; }
        public String GlosaParametrosEncadenables { get; set; }
        public String ParametrosEncadenables { get; set; }
        public List<ArchivoEnviable> ArchivosEnviables { get; set; }
        public String ArchivosAdjuntosEnviable { get; set; }
        public TiposEstadoEnvio TipoEstadoEnvio { get; set; }
        public String Anotacion { get; set; }
        public bool CorreoContieneEncuesta { get; set; }
        public String ParametrosRedireccionEncuesta { get; set; }
        public DateTime FechaEnvio { get; set; }
    }
}
