using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dto;

namespace Pulse.Contactador.BusinessLogic
{

    public class GestionadorCreacionEncuesta
    {
        Dao.Implementaciones.DaoEncuestaGateway _daoEncuesta;
        public GestionadorCreacionEncuesta()
        {
            _daoEncuesta = new Pulse.Contactador.Dao.Implementaciones.DaoEncuestaGateway();
        }


        public void CrearEncuesta(Encuesta encuesta)
        {
            encuesta.Id = _daoEncuesta.CreateEncuesta(encuesta);
            foreach (Pagina cadaPagina in encuesta.Paginas)
            {
                cadaPagina.IdentificadorPropietario = encuesta.Id;
                //BORRRARARARARA
                cadaPagina.NumeroPagina = 1;
                cadaPagina.Id = _daoEncuesta.CreatePagina(cadaPagina);
                foreach (Pregunta cadaPregunta in cadaPagina.Preguntas)
                {
                    cadaPregunta.IdentificadorPropietario = cadaPagina.Id;
                    cadaPregunta.Id = _daoEncuesta.CreatePregunta(cadaPregunta);
                    if (cadaPregunta.TipoPregunta == TiposPregunta.SeleccionUnica || cadaPregunta.TipoPregunta == TiposPregunta.SeleccionMultiple || cadaPregunta.TipoPregunta == TiposPregunta.Matriz)
                        crearItemsPreguntas(cadaPregunta);
                }
            }
        }



        private void crearItemsPreguntas(Pregunta cadaPregunta)
        {
            List<ItemPregunta> itemsPreguntas = null;
            if (cadaPregunta.TipoPregunta == TiposPregunta.SeleccionUnica)
                itemsPreguntas = (cadaPregunta as PreguntaOpcionUnica).Items;
            if (cadaPregunta.TipoPregunta == TiposPregunta.SeleccionMultiple)
                itemsPreguntas = (cadaPregunta as PreguntaOpcionMultiple).Items;
            if (cadaPregunta.TipoPregunta == TiposPregunta.Matriz)
            {
                itemsPreguntas = (cadaPregunta as PreguntaMatriz).ItemsColumnas;

                itemsPreguntas.AddRange((cadaPregunta as PreguntaMatriz).ItemsFilas);
            }

            foreach (ItemPregunta cadaItemPregunta in itemsPreguntas)
            {
                cadaItemPregunta.IdentificadorPropietario = cadaPregunta.Id;
                _daoEncuesta.CreateItemPregunta(cadaItemPregunta);
            }

        }
    }
}
