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
    public class DaoCW_EVALUADORENCUESTA
    {
        SqlMapper _mapper;
        #region Instacia SqlMapper
        SqlMapper Instance()
        {
            return ((_mapper == null) ? _mapper = MapperFactory.CrearMapper() : _mapper);
        }
        #endregion

        public int IDENCUESTA { get; set; }
        public int IDEVALUADOR { get; set; }
        public int ESTADO { get; set; }
        public int OBLIGATORIEDAD { get; set; }
        public String GUID { get; set; }

        #region Metodos DaoCW_EVALUADORENCUESTA
        public int Create(EvaluadorEncuesta daoObject)
        {
            try
            {
                DaoCW_EVALUADORENCUESTA daocw_evaluadorencuesta = DaoCW_EVALUADORENCUESTATypeHandler.CastToDao(daoObject);
                object resultado = Instance().Insert("DaoCW_EVALUADORENCUESTA.CreateDaoCW_EVALUADORENCUESTA", daocw_evaluadorencuesta);
                return Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear daocw_evaluadorencuesta", ex);
            }
        }
        public List<EvaluadorEncuesta> FindDaoCW_EVALUADORENCUESTAByEVALUADOR(int idEvaluador)
        {
            try
            {
                return DaoCW_EVALUADORENCUESTATypeHandler.CastList(Instance().QueryForList<DaoCW_EVALUADORENCUESTA>("DaoCW_EVALUADORENCUESTA.FindDaoCW_EVALUADORENCUESTAByEVALUADOR", idEvaluador));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_EVALUADORENCUESTA", ex);
            }
        }
        public List<EvaluadorEncuesta> FindDaoCW_EVALUADORENCUESTAbyENCUESTA(int idEncuesta)
        {
            try
            {
                return DaoCW_EVALUADORENCUESTATypeHandler.CastList(Instance().QueryForList<DaoCW_EVALUADORENCUESTA>("DaoCW_EVALUADORENCUESTA.FindDaoCW_EVALUADORENCUESTAbyENCUESTA", idEncuesta));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_EVALUADORENCUESTA", ex);
            }
        }

        public List<EvaluadorEncuesta> FindAll()
        {
            try
            {
                return DaoCW_EVALUADORENCUESTATypeHandler.CastList(Instance().QueryForList<DaoCW_EVALUADORENCUESTA>("DaoCW_EVALUADORENCUESTA.FindAllDaoCW_EVALUADORENCUESTA", null));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_EVALUADORENCUESTA", ex);
            }
        }

        public void Update(EvaluadorEncuesta daoObject)
        {
            try
            {
                DaoCW_EVALUADORENCUESTA daocw_evaluador = DaoCW_EVALUADORENCUESTATypeHandler.CastToDao(daoObject);
                Instance().Update("DaoCW_EVALUADORENCUESTA.UpdateDaoCW_EVALUADORENCUESTA", daocw_evaluador);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de actualizar datos de daocw_evaluadorencuesta", ex);
            }
        }
        public void Delete(int idStatement)
        {
            try
            {
                Instance().Delete("DaoCW_EVALUADORENCUESTA.DeleteDaoCW_EVALUADORENCUESTA", idStatement);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de eliminar daocw_evaluadorencuesta", ex);
            }
        }
        public List<EvaluadorEncuesta> FindDaoCW_EVALUADORENCUESTAPendientes()
        {
            try
            {
                return DaoCW_EVALUADORENCUESTATypeHandler.CastList(Instance().QueryForList<DaoCW_EVALUADORENCUESTA>("DaoCW_EVALUADORENCUESTA.FindDaoCW_EVALUADORENCUESTAPendientes", null));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_EVALUADORENCUESTA pendientes", ex);
            }
        }
        public EvaluadorEncuesta FindDaoCW_EVALUADORENCUESTAByGUID(string guid)
        {
            try
            {
                DaoCW_EVALUADORENCUESTA resultado = Instance().QueryForObject<DaoCW_EVALUADORENCUESTA>("DaoCW_EVALUADORENCUESTA.FindDaoCW_EVALUADORENCUESTAByGUID", guid);
                if (resultado == null) throw new DaoException("La encuesta solicitada, no existe.");
                EvaluadorEncuesta resultadoCasteado = DaoCW_EVALUADORENCUESTATypeHandler.CastToDto(resultado);
                return resultadoCasteado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_EVALUADORENCUESTA por GUID", ex);
            }
        }
        #endregion

    }
}
