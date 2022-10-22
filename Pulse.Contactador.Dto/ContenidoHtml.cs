using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class ContenidoHtml : LayerSupertype
    {
        public String EncabezadoHtml { get; set; }
        public String CuerpoHtml { get; set; }
        public String PiePaginaHtml { get; set; }
        public String Titulo { get; set; }
    }
}
