using System;
using System.Collections.Generic;
using System.Text;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System.Linq;
using System.Diagnostics;
using Pulse.Contactador.Dto;
using Pulse.Contactador.Dao.DaoTypeHandlers;
using Pulse.Utils.Exceptions;

namespace Pulse.Contactador.Dao.DaoDataModel
{
    public class DaoCW_EVALUADOR
    {
        SqlMapper _mapper;
        #region Instacia SqlMapper
        SqlMapper Instance()
        {
            return ((_mapper == null) ? _mapper = MapperFactory.CrearMapper() : _mapper);
        }
        #endregion

        public int IDEVALUADOR { get; set; }
        public String CORREO { get; set; }
        public String AREA { get; set; }
        public String GERENCIA { get; set; }
        public String NOMBRE { get; set; }

        #region Metodos DaoCW_EVALUADOR
        public int Create(Evaluador daoObject)
        {
            try
            {
                DaoCW_EVALUADOR daocw_evaluador = DaoCW_EVALUADORTypeHandler.CastToDao(daoObject);
                object resultado = Instance().Insert("DaoCW_EVALUADOR.CreateDaoCW_EVALUADOR", daocw_evaluador);
                return Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear daocw_evaluador", ex);
            }
        }

        public Evaluador Find(int id)
        {
            try
            {
                DaoCW_EVALUADOR resultado = Instance().QueryForObject<DaoCW_EVALUADOR>("DaoCW_EVALUADOR.FindDaoCW_EVALUADOR", id);
                Evaluador resultadoCasteado = DaoCW_EVALUADORTypeHandler.CastToDto(resultado);
                return resultadoCasteado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_EVALUADOR", ex);
            }
        }
        public List<Evaluador> FindDaoCW_EVALUADORbyAREA(String area)
        {
            try
            {
                return DaoCW_EVALUADORTypeHandler.CastList(Instance().QueryForList<DaoCW_EVALUADOR>("DaoCW_EVALUADOR.FindDaoCW_EVALUADORbyAREA", area));

            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_EVALUADOR", ex);
            }
        }
        public List<Evaluador> FindDaoCW_EVALUADORbyGERENCIA(String gerencia)
        {
            try
            {
                return DaoCW_EVALUADORTypeHandler.CastList(Instance().QueryForList<DaoCW_EVALUADOR>("DaoCW_EVALUADOR.FindDaoCW_EVALUADORbyGERENCIA", gerencia));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_EVALUADOR", ex);
            }
        }

        public List<Evaluador> FindAll()
        {
            try
            {
                return DaoCW_EVALUADORTypeHandler.CastList(Instance().QueryForList<DaoCW_EVALUADOR>("DaoCW_EVALUADOR.FindAllDaoCW_EVALUADOR", null));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_EVALUADOR", ex);
            }
        }

        public void Update(Evaluador daoObject)
        {
            try
            {
                DaoCW_EVALUADOR daocw_evaluador = DaoCW_EVALUADORTypeHandler.CastToDao(daoObject);
                Instance().Update("DaoCW_EVALUADOR.UpdateDaoCW_EVALUADOR", daocw_evaluador);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de actualizar datos de daocw_evaluador", ex);
            }

        }

        public void Delete(int idStatement)
        {
            try
            {
                Instance().Delete("DaoCW_EVALUADOR.DeleteDaoCW_EVALUADOR", idStatement);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de eliminar daocw_evaluador", ex);
            }
        }

        #endregion

    }
}
