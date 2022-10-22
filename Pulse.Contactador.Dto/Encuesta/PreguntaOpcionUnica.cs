using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class PreguntaOpcionUnica : Pregunta
    {
        public PreguntaOpcionUnica()
        {
            this.Items = new List<ItemPregunta>() 
            { 
                new ItemPregunta(){ GlosaPregunta = "Opcion 1"}, 
                new ItemPregunta(){ GlosaPregunta = "Opcion 2"} 
            };
        }

        public List<ItemPregunta> Items { get; set; }

        public ItemPregunta ItemSeleccionado { get; set; }

        public bool OtraOpcion { get; set; }

        public bool PresentarEnCombobox { get; set; }

        public bool PresentarAleatoriamente { get; set; }

        /// <summary>
        /// Por defecto se presentara de manera vertical
        /// </summary>
        public bool PresentarHorizontal { get; set; }
    }
}
