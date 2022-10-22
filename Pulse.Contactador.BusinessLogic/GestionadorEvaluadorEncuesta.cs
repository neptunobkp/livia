using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dto;

namespace Pulse.Contactador.BusinessLogic
{
    public class GestionadorEvaluadorEncuesta
    {
        Dao.Implementaciones.DaoEncuestaGateway _daoEvaluadorEncuesta;

        public GestionadorEvaluadorEncuesta()
        {
            _daoEvaluadorEncuesta = new Pulse.Contactador.Dao.Implementaciones.DaoEncuestaGateway();
        }
        public List<EvaluadorEncuesta> ObtenerTodasLosEvaluadoresEncuesta()
        {
            return _daoEvaluadorEncuesta.FindAllEvaluadoresEncuesta();
        }
        public List<EvaluadorEncuesta> ObtenerEvaluadoresPorEncuesta(int idEncuesta)
        {
            return _daoEvaluadorEncuesta.FindAllEvaluadoresEncuestaPorEncuesta(idEncuesta);
        }
        public List<EvaluadorEncuesta> ObtenerEvaluadoresPorEvaluador(int idEvaluador)
        {
            return _daoEvaluadorEncuesta.FindAllEvaluadoresencuestaPorEvaluador(idEvaluador);
        }
        public int AgregarEvaluadorEncuesta(EvaluadorEncuesta evaluadorEncuesta)
        {
            return _daoEvaluadorEncuesta.CreateEvaluadorEncuesta(evaluadorEncuesta);
        }
        public void ActualizarEvaluadorEncuesta(EvaluadorEncuesta evaluadorEncuesta)
        {
            _daoEvaluadorEncuesta.UpdateEvaluadorEncuesta(evaluadorEncuesta);
        }
        public List<EvaluadorEncuesta> ObtenerTodasLosEvaluadoresEncuestaPendientes()
        {
            return _daoEvaluadorEncuesta.FindEvaluadoresEncuestaPendientes();
        }
        public EvaluadorEncuesta ObtenerEvaluadorEncuestaPorGuid(string guid)
        {
            return _daoEvaluadorEncuesta.FindEvaluadorEncuestaByGuid(guid);
        }
    }
}
