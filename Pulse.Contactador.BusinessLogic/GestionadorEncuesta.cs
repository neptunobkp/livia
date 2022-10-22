using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dto;

namespace Pulse.Contactador.BusinessLogic
{
    public class GestionadorEncuesta
    {
        Dao.Implementaciones.DaoEncuestaGateway _daoEncuesta;

        public GestionadorEncuesta()
        {
            _daoEncuesta = new Pulse.Contactador.Dao.Implementaciones.DaoEncuestaGateway();
        }

        public Respuesta ObtenerRespuesta(int idRespuesta)
        {
            Respuesta resultado = _daoEncuesta.FindRespuesta(idRespuesta);
            resultado.ItemsRespuestas = _daoEncuesta.FindItemsPreguntaByIdRespuesta(idRespuesta);
            return resultado;
        }


        public int GuardarSemillaRespuestaEncuesta(Respuesta respuestaEncuesta)
        {
            return _daoEncuesta.CreateRespuesta(respuestaEncuesta);
        }

        public void ActualizarGuardarRespuestasEncuesta(Respuesta respuestaEncuesta)
        {
            _daoEncuesta.UpdateRespuesta(respuestaEncuesta);
            foreach (ItemRespuesta cadaItemRespuesta in respuestaEncuesta.ItemsRespuestas)
            {
                cadaItemRespuesta.IdentificadorPropietario = respuestaEncuesta.Id;
                _daoEncuesta.CreateItemRespuesta(cadaItemRespuesta);
            }
        }

        public void GuardarRespuestaEncuesta(Respuesta respuestaEncuesta)
        {
            respuestaEncuesta.Id = _daoEncuesta.CreateRespuesta(respuestaEncuesta);
            foreach (ItemRespuesta cadaItemRespuesta in respuestaEncuesta.ItemsRespuestas)
            {
                cadaItemRespuesta.IdentificadorPropietario = respuestaEncuesta.Id;
                _daoEncuesta.CreateItemRespuesta(cadaItemRespuesta);
            }
        }

        public Encuesta ObtenerEncuesta(int id)
        {
            Encuesta encuesta = new Encuesta();
            encuesta = _daoEncuesta.FindEncuesta(id);
            encuesta.PlantillaEncuesta = _daoEncuesta.FindPlantillaById(encuesta.PlantillaEncuesta.Id);

            encuesta.Paginas = _daoEncuesta.FindPaginasByEncuestaId(id);
            foreach (Pagina cadaPagina in encuesta.Paginas)
            {
                cadaPagina.Preguntas = _daoEncuesta.FindPreguntasByPaginaId(cadaPagina.Id).OrderBy(t => t.Id).ToList();
                foreach (Pregunta cadaPregunta in cadaPagina.Preguntas)
                {
                    if (cadaPregunta.TipoPregunta == TiposPregunta.SeleccionUnica || cadaPregunta.TipoPregunta == TiposPregunta.SeleccionMultiple || cadaPregunta.TipoPregunta == TiposPregunta.Matriz)
                        obtenerItemsPreguntas(cadaPregunta);
                }
            }
            return encuesta;
        }

        public void obtenerItemsPreguntas(Pregunta cadaPregunta)
        {
            List<ItemPregunta> itemsPreguntas = null;
            if (cadaPregunta.TipoPregunta == TiposPregunta.SeleccionUnica)
                (cadaPregunta as PreguntaOpcionUnica).Items = _daoEncuesta.FindItemsPreguntaByIdPregunta(cadaPregunta.Id).OrderBy(t => t.OrdenCorrelativo).ToList();
            if (cadaPregunta.TipoPregunta == TiposPregunta.SeleccionMultiple)
                (cadaPregunta as PreguntaOpcionMultiple).Items = _daoEncuesta.FindItemsPreguntaByIdPregunta(cadaPregunta.Id).OrderBy(t => t.OrdenCorrelativo).ToList();
            if (cadaPregunta.TipoPregunta == TiposPregunta.Matriz)
            {
                itemsPreguntas = _daoEncuesta.FindItemsPreguntaByIdPregunta(cadaPregunta.Id);
                (cadaPregunta as PreguntaMatriz).ItemsColumnas = new List<ItemPregunta>();
                (cadaPregunta as PreguntaMatriz).ItemsFilas = new List<ItemPregunta>();
                (cadaPregunta as PreguntaMatriz).ItemsColumnas = itemsPreguntas.Where(t => t.TipoItemPregunta == TiposItemPregunta.ColumnaMatriz).ToList();
                (cadaPregunta as PreguntaMatriz).ItemsFilas = itemsPreguntas.Where(t => t.TipoItemPregunta == TiposItemPregunta.FliaMatriz).ToList();
            }
        }
        public List<Encuesta> ObtenerTodasLasEncuestas()
        {
            return _daoEncuesta.FindAllEncuestas();
        }

        public Respuesta RecuperarRespuestaPorItemCorreoCampaniaEncuesta(int itemCorreoId, int campaniaId, int encuestaId)
        {
            return _daoEncuesta.FindRespuestaPorItemCorreoIdCampaniaIdEncuestaId(itemCorreoId, campaniaId, encuestaId);
        }

        public Respuesta ObtenerRespuestaPorEncuestaEvaluador(int encuestaId, int evaluadorId)
        {
            return _daoEncuesta.FindRespuestasByEncuestaEvaluador(encuestaId, evaluadorId);
        }

        public Respuesta ObtenerRespuestasPorEncuestaEvaluadorModificada(int encuestaId, int evaluadorId)
        {
            List<Respuesta> respuestas = _daoEncuesta.FindRespuestasByEncuestaEvaluadorModificada(encuestaId, evaluadorId);
            if (respuestas.Count > 0)
            {
                if (respuestas.Any(t => t.TipoEstadoRespuestaEncuesta == TiposEstadoRespuestaEncuesta.EncuestaTerminada))
                    return respuestas.First(t => t.TipoEstadoRespuestaEncuesta == TiposEstadoRespuestaEncuesta.EncuestaTerminada);
                else
                    return respuestas.First();
            }
            else
                return null;
        }
    }
}
