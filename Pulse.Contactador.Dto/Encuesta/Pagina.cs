using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class Pagina : LayerSupertype
    {
        public String Titulo { get; set; }
        public String IntroduccionPagina { get; set; }
        public String MensajePiePagina { get; set; }
        public String DescripcionPiePagina { get; set; }
        public List<Pregunta> Preguntas { get; set; }
        public int NumeroPagina { get; set; }
    }
}
