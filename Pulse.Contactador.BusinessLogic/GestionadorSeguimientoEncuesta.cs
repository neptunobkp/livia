using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dto;

namespace Pulse.Contactador.BusinessLogic
{
    public class GestionadorSeguimientoEncuesta
    {
        Dao.Implementaciones.DaoEncuestaGateway _daoSeguimientoEncuesta;

        public GestionadorSeguimientoEncuesta()
        {
            _daoSeguimientoEncuesta = new Pulse.Contactador.Dao.Implementaciones.DaoEncuestaGateway();
        } 
        public SeguimientoEncuesta ObtenerEvaluador(SeguimientoEncuesta seguimientoEncuesta)
        {
            return _daoSeguimientoEncuesta.FindSeguimientoEncuesta(seguimientoEncuesta);
        }
        public List<SeguimientoEncuesta> ObtenerTodosLosSeguimientoEncuesta()
        {
            return _daoSeguimientoEncuesta.FindAllSeguimientoEncuesta();
        }
        public void AgregarSeguimientoEncuesta(SeguimientoEncuesta seguimientoEncuesta)
        {
            _daoSeguimientoEncuesta.CreateSeguimientoEncuesta(seguimientoEncuesta);
        }
        public void ActualizarSeguimientoEncuesta(SeguimientoEncuesta seguimientoEncuesta)
        {
            _daoSeguimientoEncuesta.UpdateSeguimientoEncuesta(seguimientoEncuesta);
        }
    }
}
