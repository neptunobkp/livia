using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    public class PresentadorCarpetaEncuesta
    {
        public String UrlEncuesta { get; set; }
        public String NombreEncuesta { get; set; }
        public String TipoCategoria { get; set; }
        public String PathImagenEstado { get; set; }
        public bool Disponible { get; set; }
        public String ToolTipIcon { get; set; }
        public String Estado { get; set; }
        public String Introduccion { get; set; }
    }
}
