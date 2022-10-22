using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class Encuesta : LayerSupertype
    {
        public Plantilla PlantillaEncuesta { get; set; }
        public List<Pagina> Paginas { get; set; }
        public List<Pregunta> Preguntas { get; set; }
        public int NumeroPaginas { get; set; }
        public String Titulo { get; set; }
        public String Introduccion { get; set; }
        public String MensajePiePagina { get; set; }
        public String DescripcionPiePagina { get; set; }

        public DateTime? FechaInicioVigencia { get; set; }
        public DateTime? FechaTerminoVigencia { get; set; }
        public int? CuotaLimiteEncuesta { get; set; }
        public int? CantidadRespuestas { get; set; }

        public bool PrimeraPaginaContenidaEnPresentacion { get; set; }
        public TiposEstadoRespuestaEncuesta TipoEstaRespuestaEncuesta { get; set; }
        public String TipoServicio { get; set; }

        public override string ToString()
        {
            return this.TipoServicio;
        }
    }
}
