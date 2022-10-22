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
    public class DaoCW_USUARIOEXTERNO
    {
        SqlMapper _mapper;
        #region Instacia SqlMapper
        SqlMapper Instance()
        {
            return ((_mapper == null) ? _mapper = MapperFactory.CrearMapper() : _mapper);
        }
        #endregion

        public int IDUSUARIOEXTERNO { get; set; }
        public int RUT { get; set; }
        public String NOMBRES { get; set; }
        public String TELEFONO { get; set; }
        public String CELULAR { get; set; }
        public String NOMBREINGRESO { get; set; }
        public String CLAVE { get; set; }
        public int TIPOESTADOENTIDAD { get; set; }
        public String CORREO { get; set; }


        #region Metodos DaoCW_USUARIOEXTERNO
        public int Create<T>(Usuario daoObject)
        {
            try
            {
                DaoCW_USUARIOEXTERNO daocw_usuarioexterno = DaoCW_USUARIOEXTERNOTypeHandler.CastToDao(daoObject);
                object resultado = Instance().Insert("DaoCW_USUARIOEXTERNO.CreateDaoCW_USUARIOEXTERNO", daocw_usuarioexterno);
                return Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear daocw_usuarioexterno", ex);
            }

        }

        public Usuario Find(int id)
        {
            try
            {
                DaoCW_USUARIOEXTERNO resultado = Instance().QueryForObject<DaoCW_USUARIOEXTERNO>("DaoCW_USUARIOEXTERNO.Find", id);
                Usuario resultadoCasteado = DaoCW_USUARIOEXTERNOTypeHandler.CastToDto(resultado);
                return resultadoCasteado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_USUARIOEXTERNO", ex);
            }
        }
        internal Usuario FindByNombreIngreso(string nombreIngreso)
        {
            DaoCW_USUARIOEXTERNO resultado = Instance().QueryForObject<DaoCW_USUARIOEXTERNO>("DaoCW_USUARIOEXTERNO.FindDaoCW_USUARIOEXTERNOByNOMBREINGRESO", nombreIngreso);
            if (resultado == null) return null;
            Usuario resultadoCasteado = DaoCW_USUARIOEXTERNOTypeHandler.CastToDto(resultado);
            return resultadoCasteado;
        }



        public List<Usuario> FindAll()
        {
            try
            {
                return DaoCW_USUARIOEXTERNOTypeHandler.CastList(Instance().QueryForList<DaoCW_USUARIOEXTERNO>("DaoCW_USUARIOEXTERNO.FindAllDaoCW_USUARIOEXTERNO", null));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_USUARIOEXTERNO", ex);
            }
        }

        public void Update(Usuario daoObject)
        {
            try
            {
                DaoCW_USUARIOEXTERNO daocw_usuarioexterno = DaoCW_USUARIOEXTERNOTypeHandler.CastToDao(daoObject);
                Instance().Update("DaoCW_USUARIOEXTERNO.UpdateDaoCW_USUARIOEXTERNO", daocw_usuarioexterno);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de actualizar datos de daocw_usuarioexterno", ex);
            }
        }

        public void Delete(int idStatement)
        {
            try
            {
                Instance().Delete("DaoCW_USUARIOEXTERNO.DeleteDaoCW_USUARIOEXTERNO", idStatement);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de eliminar daocw_usuarioexterno", ex);

            }
        }

        #endregion



    }
}
