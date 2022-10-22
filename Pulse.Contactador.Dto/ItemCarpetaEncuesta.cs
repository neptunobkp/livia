using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class ItemCarpetaEncuesta : LayerSupertype
    {
        public Encuesta Encuesta { get; set; }
        public TiposEstadoCarpetaEncuesta TipoEstadoCarpetaEncuesta { get; set; }
        public GrupoEncuestado GrupoEncuestado { get; set; }
        public CarpetaEncuesta CarpetaEncuesta { get; set; }
    }

    public enum TiposEstadoCarpetaEncuesta
    {
        Indefinido,
        Obligatoria,
        Opcional
    }
}
