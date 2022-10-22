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
    public class DaoCW_MENSAJECORREO
    {
        SqlMapper _mapper;
        #region Instacia SqlMapper
        SqlMapper Instance()
        {
            return ((_mapper == null) ? _mapper = MapperFactory.CrearMapper() : _mapper);
        }
        #endregion

        public int IDMENSAJECORREO { get; set; }
        public String ENCABEZADOHTML { get; set; }
        public String CUERPOHTML { get; set; }
        public String PIEPAGINAHTML { get; set; }
        public String TITULO { get; set; }
        public String NOMBREDE { get; set; }
        public String DIRECCIONCORREODE { get; set; }
        public String NOMBREA { get; set; }
        public int IDPROPIETARIO { get; set; }
        public int TIPOPROPIETARIO { get; set; }
        public int USUARIOCREADOR { get; set; }
        public int USUARIOMODIFICADOR { get; set; }
        public DateTime FECHACREACION { get; set; }
        public DateTime FECHAMODIFICACION { get; set; }
        public int TIPOESTADOENTIDAD { get; set; }
        public String ARCHIVOSADJUNTOS { get; set; }


        #region Metodos DaoCW_MENSAJECORREO
        public int Create(MensajeCorreoDestino daoObject)
        {
            try
            {
                DaoCW_MENSAJECORREO daocw_mensajecorreo = DaoCW_MENSAJECORREOTypeHandler.CastToDao(daoObject);
                object resultado = Instance().Insert("DaoCW_MENSAJECORREO.CreateDaoCW_MENSAJECORREO", daocw_mensajecorreo);
                return Convert.ToInt32(resultado);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear daocw_mensajecorreo", ex);
            }
        }

        public MensajeCorreoDestino Find(int id)
        {
            try
            {
                DaoCW_MENSAJECORREO resultado = Instance().QueryForObject<DaoCW_MENSAJECORREO>("DaoCW_MENSAJECORREO.FindDaoCW_MENSAJECORREO", id);
                MensajeCorreoDestino resultadoCasteado = DaoCW_MENSAJECORREOTypeHandler.CastToDto(resultado);
                return resultadoCasteado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_MENSAJECORREO", ex);
            }
        }

        public List<MensajeCorreoDestino> FindAll()
        {
            try
            {
                return DaoCW_MENSAJECORREOTypeHandler.CastList(Instance().QueryForList<DaoCW_MENSAJECORREO>("DaoCW_MENSAJECORREO.FindAllDaoCW_MENSAJECORREO", null));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_MENSAJECORREO", ex);
            }
        }

        public void Update(MensajeCorreoDestino daoObject)
        {
            try
            {
                DaoCW_MENSAJECORREO daocw_mensajecorreo = DaoCW_MENSAJECORREOTypeHandler.CastToDao(daoObject);
                Instance().Update("DaoCW_MENSAJECORREO.UpdateDaoCW_MENSAJECORREO", daocw_mensajecorreo);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de actualizar datos de daocw_mensajecorreo", ex);
            }

        }

        public void Delete(int idStatement)
        {
            try
            {
                Instance().Delete("DaoCW_MENSAJECORREO.DeleteDaoCW_MENSAJECORREO", idStatement);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de eliminar daocw_mensajecorreo", ex);

            }

        }

        #endregion

    }
}
