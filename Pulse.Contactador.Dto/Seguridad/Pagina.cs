using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto.Seguridad
{
    [Serializable]
    public class Pagina : LayerSupertype
    {
        public String Nombre { get; set; }
        public String Url { get; set; }
        public String Alias { get; set; }
        public List<Funcionalidad> Funcionalidades { get; set; }
    }
}
