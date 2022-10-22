using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class PreguntaOpcionMultiple : Pregunta
    {
        public PreguntaOpcionMultiple()
        {
            this.Items = new List<ItemPregunta>() 
            { 
                new ItemPregunta(){ GlosaPregunta = "Opcion 1"}, 
                new ItemPregunta(){ GlosaPregunta = "Opcion 2"} 
            };
        }

        public List<ItemPregunta> Items { get; set; }

        public List<ItemPregunta> ItemsSeleccionados { get; set; }

        public bool OtraOpcion { get; set; }

        public bool PresentarAleatoriamente { get; set; }

        public int? CantidadColumnasPresentacion { get; set; }

        public int? LimiteMaximoSeleccionables { get; set; }

        public int? LimiteMinimoSeleccionables { get; set; }

    }
}
