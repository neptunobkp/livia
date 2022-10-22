using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dao.DaoDataModel;
using Pulse.Contactador.Dto;

namespace Pulse.Contactador.BusinessLogic
{
    public class GestionarEstadoCampanias
    {
        DaoEstadoCampania _daoEstadoCampania;
        public GestionarEstadoCampanias()
        {
            _daoEstadoCampania = new DaoEstadoCampania();
        }


        public List<EstadoCampania> ObtenerEstadoCampaniasPorCampania(Campania cadaCampania)
        {
            return _daoEstadoCampania.FindByCampaniaId(cadaCampania.Id);
        }

        public void AgregarEstadoCampania(Campania cadaCampania)
        {
            try
            {
                EstadoCampania estadoCampania = new EstadoCampania();
                estadoCampania.Campania = cadaCampania;
                estadoCampania.FechaEjecutada = DateTime.Now;
                _daoEstadoCampania.Create(estadoCampania);
            }
            catch (Exception ex)
            {
                throw new Pulse.Utils.Exceptions.ActionableException("Error al crear el estado campania" + ex.Message, ex);
            }
        }
    }
}
