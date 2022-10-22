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
    public class DaoCW_CONFSALIDACORREO
    {
        SqlMapper _mapper;
        #region Instacia SqlMapper
        SqlMapper Instance()
        {
            return ((_mapper == null) ? _mapper = MapperFactory.CrearMapper() : _mapper);
        }
        #endregion

        public int IDCONFSALIDACORREO { get; set; }
        public String SERVIDORSMTP { get; set; }
        public String PUERTOSERVIDOR { get; set; }
        public String SSLHABILITADO { get; set; }
        public String USUARIO { get; set; }
        public String CONTRASENIA { get; set; }
        public String CORREOCASILLASALIDA { get; set; }
        public String NOMBRECASILLASALDA { get; set; }
        public int IDPROPIETARIO { get; set; }
        public int TIPOPROPIETARIO { get; set; }
        public int USUARIOCREADOR { get; set; }
        public DateTime FECHACREACION { get; set; }
        public int USUARIOMODIFICADOR { get; set; }
        public DateTime FECHAMODIFICACION { get; set; }


        #region Metodos DaoCW_CONFSALIDACORREO
        public int Create(ConfiguracionSalidaCorreo daoObject)
        {
            try
            {
                DaoCW_CONFSALIDACORREO daocw_confsalidacorreo = DaoCW_CONFSALIDACORREOTypeHandler.CastToDao(daoObject);
                object resultado =  Instance().Insert("DaoCW_CONFSALIDACORREO.CreateDaoCW_CONFSALIDACORREO", daocw_confsalidacorreo);
                return Convert.ToInt32(resultado);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear daocw_confsalidacorreo", ex);
            }

        }

        public ConfiguracionSalidaCorreo Find(int id)
        {
            try
            {
                DaoCW_CONFSALIDACORREO resultado = Instance().QueryForObject<DaoCW_CONFSALIDACORREO>("DaoCW_CONFSALIDACORREO.Find", id);
                ConfiguracionSalidaCorreo resultadoCasteado = DaoCW_CONFSALIDACORREOTypeHandler.CastToDto(resultado);
                return resultadoCasteado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_CONFSALIDACORREO", ex);
            }
        }

        public List<ConfiguracionSalidaCorreo> FindAll()
        {
            try
            {
                return DaoCW_CONFSALIDACORREOTypeHandler.CastList(Instance().QueryForList<DaoCW_CONFSALIDACORREO>("DaoCW_CONFSALIDACORREO.FindAllDaoCW_CONFSALIDACORREO", null));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_CONFSALIDACORREO", ex);
            }
        }

        public void Update(ConfiguracionSalidaCorreo daoObject)
        {
            try
            {
                DaoCW_CONFSALIDACORREO daocw_confsalidacorreo = DaoCW_CONFSALIDACORREOTypeHandler.CastToDao(daoObject);
                Instance().Update("DaoCW_CONFSALIDACORREO.UpdateDaoCW_CONFSALIDACORREO", daocw_confsalidacorreo);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de actualizar datos de daocw_confsalidacorreo", ex);
            }

        }

        public void Delete(int idStatement)
        {
            try
            {
                Instance().Delete("DaoCW_CONFSALIDACORREO.DeleteDaoCW_CONFSALIDACORREO", idStatement);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de eliminar daocw_confsalidacorreo", ex);

            }

        }

        #endregion

    }
}
