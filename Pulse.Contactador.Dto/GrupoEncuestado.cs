using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class GrupoEncuestado : LayerSupertype
    {
        public List<PersonaDestinatario> Destinatarios { get; set; }
        public String Nombre { get; set; }
        public int Estado { get; set; }
    }
}
