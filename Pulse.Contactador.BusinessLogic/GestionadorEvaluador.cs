using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dto;

namespace Pulse.Contactador.BusinessLogic
{
    public class GestionadorEvaluador
    {
        Dao.Implementaciones.DaoEncuestaGateway _daoEvaluador;

        public GestionadorEvaluador()
        {
            _daoEvaluador = new Pulse.Contactador.Dao.Implementaciones.DaoEncuestaGateway();
        } 
        public Evaluador ObtenerEvaluador(int id)
        {
            Evaluador evaluador = new Evaluador();
            evaluador = _daoEvaluador.FindEvaluador(id);
            return evaluador;
        }
        public List<Evaluador> ObtenerTodasLosEvaluadores()
        {
            return _daoEvaluador.FindAllEvaluadores();
        }
        public List<Evaluador> ObtenerEvaluadoresPorGerencia(String gerencia)
        {
            return _daoEvaluador.FindEvaluadoresByGerencia(gerencia);
        }
        public List<Evaluador> ObtenerEvaluadoresPorArea(String area)
        {
            return _daoEvaluador.FindEvaluadoresByArea(area);
        }
        public int AgregarEvaluador(Evaluador evaluador)
        {
            return _daoEvaluador.CreateEvaluador(evaluador);
        }
        public void ActualizarEvaluador(Evaluador evaluador)
        {
            _daoEvaluador.UpdateEvaluador(evaluador);
        }
    }
}
