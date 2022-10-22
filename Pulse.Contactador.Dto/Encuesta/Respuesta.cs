using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class Respuesta : LayerSupertype
    {
        public Campania CampaniaPropietaria { get; set; }
        public Encuesta EncuestaRespondida { get; set; }
        public PersonaEncuestable Encuestado { get; set; }
        public DateTime InicioRespuestaEncuesta { get; set; }
        public DateTime? TerminoRespuestaEncuesta { get; set; }
        public String DireccionIP { get; set; }
        public String NombreUsuarioCliente { get; set; }
        public bool Completado { get; set; }
        public int MinutosParaCompletarEncuesta { get; set; }
        public String Navegador { get; set; }
        public List<ItemRespuesta> ItemsRespuestas { get; set; }
        public String UrlEncuestaEnviada { get; set; }
        public String Anotacion { get; set; }
        public String IdentificadorAnexo { get; set; }
        public TiposEstadoRespuestaEncuesta TipoEstadoRespuestaEncuesta { get; set; }
    }
}
