using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class PreguntaMatriz : Pregunta
    {
        public List<ItemPregunta> ItemsColumnas { get; set; }
        public List<ItemPregunta> ItemsFilas { get; set; }
        public List<ItemPregunta> ItemsSeleccionados { get; set; }
    }
}
