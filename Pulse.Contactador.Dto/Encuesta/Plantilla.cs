using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class Plantilla : ContenidoHtml
    {
        public String Nombre { get; set; }
        public String PathBanner { get; set; }
        public HorizontalAlign AlineacionLogo { get; set; }
        public HorizontalAlign AlineacionEncuesta { get; set; }
        public String RutaArchivoCss { get; set; }

        public ControlPlantilla BotonSiguiente { get; set; }
        public ControlPlantilla BotonVolver { get; set; }
        public ControlPlantilla BotonGuardar { get; set; }
        public ControlPlantilla BotonSalir { get; set; }

        public String NombreCarpetaEstilo { get; set; }
    }
}
