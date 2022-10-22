using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using Pulse.Contactador.Dto;
using Pulse.Utils.Exceptions;

namespace Pulse.Contactador.Dao.DaoDataModel
{
    public class DaoEstadoCampania
    {
        SqlMapper _mapper;
        #region Instacia SqlMapper
        SqlMapper Instance()
        {
            return ((_mapper == null) ? _mapper = MapperFactory.CrearMapper() : _mapper);
        }
        #endregion


        #region Metodos EstadoCampania
        public int Create(EstadoCampania estadoCampania)
        {
            try
            {

                object resultado = Instance().Insert("EstadoCampania.Create", estadoCampania);
                return Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear el estado campania", ex);
            }

        }

        public List<EstadoCampania> FindByCampaniaId(int id)
        {
            try
            {
                List<EstadoCampania> resultado = Instance().QueryForList<EstadoCampania>("EstadoCampania.FindByCampaniaId", id).ToList();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_ITEMPREGUNTA", ex);
            }
        }

        public void Update(EstadoCampania estadoCampania)
        {
            try
            {
                Instance().Update("EstadoCampania.UpdateEstadoCampania", estadoCampania);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de actualizar datos de estadocampania", ex);
            }

        }

        #endregion
    }
}
