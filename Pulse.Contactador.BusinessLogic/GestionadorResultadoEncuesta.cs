using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dto;
namespace Pulse.Contactador.BusinessLogic
{
    public class GestionadorResultadoEncuesta
    {
        Dao.Implementaciones.DaoEncuestaGateway _daoEncuestaGateway;

        public GestionadorResultadoEncuesta()
        {
            _daoEncuestaGateway = new Pulse.Contactador.Dao.Implementaciones.DaoEncuestaGateway();
        }

        public List<Respuesta> ObtenerRespuestasPorEncuestaId(int encuestaId)
        {
            var respuestas = _daoEncuestaGateway.FindRespuestasByEncuestaId(encuestaId);
            foreach (var cadaRespuesta in respuestas)
            {
                cadaRespuesta.IdentificadorPropietario = encuestaId;
            }
            return respuestas;
        }

        public List<Encuesta> ObtenerTodasLasEncuestas()
        {
            var encuestas = new GestionadorEncuesta().ObtenerTodasLasEncuestas();
            foreach (Encuesta cadaEncuesta in encuestas)
            {
                cadaEncuesta.CantidadRespuestas = _daoEncuestaGateway.CountResultadoByEncuesta(cadaEncuesta.Id);
            }
            return encuestas;
        }

        public List<ItemRespuesta> ObtenerItemsRespuestaPorPreguntaId(int id)
        {
            try
            {
                return _daoEncuestaGateway.FindItemsRespuestaByIdPregunta(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
