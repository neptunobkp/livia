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
    public class DaoCW_SEGUIMIENTOENCUESTA
    {
        SqlMapper _mapper;
        #region Instacia SqlMapper
        SqlMapper Instance()
        {
            return ((_mapper == null) ? _mapper = MapperFactory.CrearMapper() : _mapper);
        }
        #endregion

        public int IDEVALUADOR { get; set; }
        public int IDENCUESTA { get; set; }
        public String CUERPOCORREO { get; set; }
        public DateTime FECHAULTIMOENVIO { get; set; }
        public int CANTIDADRECORDATORIOS { get; set; }

        #region Metodos DaoCW_SEGUIMIENTOENCUESTA
        public void Create(SeguimientoEncuesta daoObject)
        {
            try
            {
                DaoCW_SEGUIMIENTOENCUESTA daocw_seguimientoEncuesta = DaoCW_SEGUIMIENTOENCUESTATypeHandler.CastToDao(daoObject);
                Instance().Insert("DaoCW_SEGUIMIENTOENCUESTA.CreateDaoCW_SEGUIMIENTOENCUESTA", daocw_seguimientoEncuesta);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear DaoCW_SEGUIMIENTOENCUESTA", ex);
            }
        }

        public SeguimientoEncuesta Find(SeguimientoEncuesta daoObject)
        {
            try
            {
                DaoCW_SEGUIMIENTOENCUESTA daocw_seguimientoEncuesta = DaoCW_SEGUIMIENTOENCUESTATypeHandler.CastToDao(daoObject);
                DaoCW_SEGUIMIENTOENCUESTA resultado = Instance().QueryForObject<DaoCW_SEGUIMIENTOENCUESTA>("DaoCW_SEGUIMIENTOENCUESTA.FindDaoCW_SEGUIMIENTOENCUESTA", daocw_seguimientoEncuesta);
                SeguimientoEncuesta resultadoCasteado = DaoCW_SEGUIMIENTOENCUESTATypeHandler.CastToDto(resultado);
                return resultadoCasteado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_SEGUIMIENTOENCUESTA", ex);
            }
        }

        public List<SeguimientoEncuesta> FindAll()
        {
            try
            {
                return DaoCW_SEGUIMIENTOENCUESTATypeHandler.CastList(Instance().QueryForList<DaoCW_SEGUIMIENTOENCUESTA>("DaoCW_SEGUIMIENTOENCUESTA.FindAllDaoCW_SEGUIMIENTOENCUESTA", null));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_SEGUIMIENTOENCUESTA", ex);
            }
        }

        public void Update(SeguimientoEncuesta daoObject)
        {
            try
            {
                DaoCW_SEGUIMIENTOENCUESTA daocw_seguimientoEncuesta = DaoCW_SEGUIMIENTOENCUESTATypeHandler.CastToDao(daoObject);
                Instance().Update("DaoCW_SEGUIMIENTOENCUESTA.UpdateDaoCW_SEGUIMIENTOENCUESTA", daocw_seguimientoEncuesta);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de actualizar datos de DaoCW_SEGUIMIENTOENCUESTA", ex);
            }

        }

        public void Delete(SeguimientoEncuesta daoObject)
        {
            try
            {
                DaoCW_SEGUIMIENTOENCUESTA daocw_seguimientoEncuesta = DaoCW_SEGUIMIENTOENCUESTATypeHandler.CastToDao(daoObject);
                Instance().Delete("DaoCW_SEGUIMIENTOENCUESTA.DeleteDaoCW_SEGUIMIENTOENCUESTA", daocw_seguimientoEncuesta);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de eliminar DaoCW_SEGUIMIENTOENCUESTA", ex);
            }
        }

        #endregion

    }
}
