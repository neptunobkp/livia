using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class ItemPregunta : LayerSupertype
    {
        public TiposItemPregunta TipoItemPregunta { get; set; }
        public int OrdenCorrelativo { get; set; }
        public String ValorInterno { get; set; }
        public String GlosaPregunta { get; set; } //MAX 500
        public bool Seleccionado { get; set; }
        public String NombreGrupo { get; set; }
    }
}
