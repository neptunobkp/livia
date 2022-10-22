using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class Campania : LayerSupertype
    {
        public CarpetaEncuesta CarpetaEncuesta { get; set; }
        public Encuesta Encuesta { get; set; }
        public DateTime? FechaEnvioEsperado { get; set; }
        public ControladorEnvioCorreo ControladorEnvioCorreo { get; set; }
        public EntidadParametrizable Motivo { get; set; }
        public String Nombre { get; set; }
        public DateTime? FechaTerminoEsperado { get; set; }
        public TiposPeriodosEjecucion TipoPeriodoEjecucion { get; set; }
        public TiposFormaContacto TipoFormaContacto{ get; set; }
    }
}
