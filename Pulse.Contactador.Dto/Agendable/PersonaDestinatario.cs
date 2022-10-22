using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class PersonaDestinatario : Persona
    {
        public String RutOrigen { get; set; }
        public String CorreosOrigen { get; set; }
        public String IdentificadorEncuesta { get; set; }
        public String IdentificadorContextoOrigen { get; set; }
        public String GlosaParametros { get; set; }
        public String ReferenciaArchivosAdjuntoOrigen { get; set; }
        public String TipoMotivo { get; set; }
        public int Celular { get; set; }
    }
}
