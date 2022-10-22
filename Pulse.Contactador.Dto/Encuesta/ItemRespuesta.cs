using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class ItemRespuesta : LayerSupertype
    {
        public Pregunta PregunaRespondida { get; set; }
        public ItemPregunta ItemPreguntaRespondida { get; set; }
        public String GlosaRespuesta { get; set; }
        public String ValorRespuesta { get; set; }
        public int NumeroOrden { get; set; }
        public String ValorTipoColumna { get; set; }
        public String GlosaTipoColumna { get; set; }
        public TiposPregunta TipoPreguntaRespondida { get; set; }
        public String OtraRespuesta { get; set; }
    }
}
