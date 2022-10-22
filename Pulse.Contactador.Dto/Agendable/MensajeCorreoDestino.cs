using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class MensajeCorreoDestino : ContenidoHtml
    {
        public String NombreDe { get; set; }
        public String DireccionCorreoDe { get; set; }
        public String NombreA { get; set; }
        public String ReferenciaArchivoAdjuntos { get; set; }
        public List<ArchivoEnviable> ArchivosEnviables { get; set; }
    }
}
