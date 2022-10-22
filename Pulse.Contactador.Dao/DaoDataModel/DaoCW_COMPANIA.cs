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
    public class DaoCW_COMPANIA
    {
        SqlMapper _mapper;
        #region Instacia SqlMapper
        SqlMapper Instance()
        {
            return ((_mapper == null) ? _mapper = MapperFactory.CrearMapper() : _mapper);
        }
        #endregion

        public int IDCOMPANIA { get; set; }
        public int RUT { get; set; }
        public String RAZONSOCIAL { get; set; }
        public int TIPOESTADOENTIDAD { get; set; }


        #region Metodos DaoCW_COMPANIA
        public int Create(Empresa daoObject)
        {
            try
            {
                DaoCW_COMPANIA daocw_compania = DaoCW_COMPANIATypeHandler.CastToDao(daoObject);
                object resultado = Instance().Insert("DaoCW_COMPANIA.CreateDaoCW_COMPANIA", daocw_compania);
                return Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear daocw_compania", ex);
            }

        }

        public Empresa Find(int id)
        {
            try
            {
                DaoCW_COMPANIA resultado = Instance().QueryForObject<DaoCW_COMPANIA>("DaoCW_COMPANIA.Find", id);
                Empresa resultadoCasteado = DaoCW_COMPANIATypeHandler.CastToDto(resultado);
                return resultadoCasteado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_COMPANIA", ex);
            }
        }

        public List<Empresa> FindAll()
        {
            try
            {
                return DaoCW_COMPANIATypeHandler.CastList(Instance().QueryForList<DaoCW_COMPANIA>("DaoCW_COMPANIA.FindAllDaoCW_COMPANIA", null));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_COMPANIA", ex);
            }
        }

        public void Update(Empresa daoObject)
        {
            try
            {
                DaoCW_COMPANIA daocw_compania = DaoCW_COMPANIATypeHandler.CastToDao(daoObject);
                Instance().Update("DaoCW_COMPANIA.UpdateDaoCW_COMPANIA", daocw_compania);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de actualizar datos de daocw_compania", ex);
            }

        }

        public void Delete(int idStatement)
        {
            try
            {
                Instance().Delete("DaoCW_COMPANIA.DeleteDaoCW_COMPANIA", idStatement);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de eliminar daocw_compania", ex);

            }
        }

        #endregion

    }
}
