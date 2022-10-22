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
    public class DaoCW_ITEMCORREODESTINO
    {
        SqlMapper _mapper;
        #region Instacia SqlMapper
        SqlMapper Instance()
        {
            return ((_mapper == null) ? _mapper = MapperFactory.CrearMapper() : _mapper);
        }
        #endregion

        public int IDITEMCORREODESTINO { get; set; }
        public int RUTDESTINATARIO { get; set; }
        public String IDENTIFICADORRELACIONALORIGEN { get; set; }
        public int IDMENSAJECORREO { get; set; }
        public String PARAMETROSENCADENABLES { get; set; }
        public String ARCHIVOSENVIABLES { get; set; }
        public int TIPOESTADOENVIO { get; set; }
        public String ANOTACION { get; set; }
        public String NOMBREDESTINATARIO { get; set; }
        public String CORREODESTINATARIO { get; set; }
        public int IDLISTACORREO { get; set; }
        public DateTime FECHAENVIO { get; set; }
        public int GRUPOID { get; set; }
        public int CELULAR { get; set; }

        #region Metodos DaoCW_ITEMCORREODESTINO
        public int Create(CorreoDestino daoObject)
        {
            try
            {
                DaoCW_ITEMCORREODESTINO daocw_itemcorreodestino = DaoCW_ITEMCORREODESTINOTypeHandler.CastToDao(daoObject);
                object resultado = Instance().Insert("DaoCW_ITEMCORREODESTINO.CreateDaoCW_ITEMCORREODESTINO", daocw_itemcorreodestino);
                return Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear daocw_itemcorreodestino", ex);
            }

        }

        public CorreoDestino Find(int id)
        {
            try
            {
                DaoCW_ITEMCORREODESTINO resultado = Instance().QueryForObject<DaoCW_ITEMCORREODESTINO>("DaoCW_ITEMCORREODESTINO.FindDaoCW_ITEMCORREODESTINO", id);
                if (resultado == null) return null;
                CorreoDestino resultadoCasteado = DaoCW_ITEMCORREODESTINOTypeHandler.CastToDto(resultado);
                return resultadoCasteado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_ITEMCORREODESTINO", ex);
            }
        }

        public List<CorreoDestino> FindAll()
        {
            try
            {
                return DaoCW_ITEMCORREODESTINOTypeHandler.CastList(Instance().QueryForList<DaoCW_ITEMCORREODESTINO>("DaoCW_ITEMCORREODESTINO.FindAllDaoCW_ITEMCORREODESTINO", null));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_ITEMCORREODESTINO", ex);
            }
        }

        internal IList<CorreoDestino> FindByListaCorreoId(int listaCorreoId)
        {
            try
            {
                return DaoCW_ITEMCORREODESTINOTypeHandler.CastList(Instance().QueryForList<DaoCW_ITEMCORREODESTINO>("DaoCW_ITEMCORREODESTINO.FindByListaCorreoId", listaCorreoId));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_ITEMCORREODESTINO", ex);
            }
        }

        public void Update(CorreoDestino daoObject)
        {
            try
            {
                DaoCW_ITEMCORREODESTINO daocw_itemcorreodestino = DaoCW_ITEMCORREODESTINOTypeHandler.CastToDao(daoObject);
                Instance().Update("DaoCW_ITEMCORREODESTINO.UpdateDaoCW_ITEMCORREODESTINO", daocw_itemcorreodestino);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de actualizar datos de daocw_itemcorreodestino", ex);
            }

        }

        public void Delete(int idStatement)
        {
            try
            {
                Instance().Delete("DaoCW_ITEMCORREODESTINO.DeleteDaoCW_ITEMCORREODESTINO", idStatement);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de eliminar daocw_itemcorreodestino", ex);

            }

        }

        #endregion



    }
}
