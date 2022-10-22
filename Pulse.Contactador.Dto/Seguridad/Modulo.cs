using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto.Seguridad
{
    [Serializable]
    public class Modulo : LayerSupertype
    {
        public String Nombre { get; set; }
        public String Alias { get; set; }
        public List<Pagina> Paginas { get; set; }
    }
}
