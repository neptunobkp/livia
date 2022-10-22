using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class LayerSupertype
    {
        public int Id { get; set; }
        public TiposEstadoEntidad TipoEstadoEntidad { get; set; }
        public Usuario UsuarioCreador { get; set; }
        public Usuario UsuarioModificador { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int IdentificadorPropietario { get; set; }
        public int IdentificadorPropietarioAplicacion { get; set; }
        public TiposPropietario TipoPropietario{ get; set; }
    }
}
