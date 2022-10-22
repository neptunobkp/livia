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
    public class DaoCW_ITEMRESPUESTA
    {
        SqlMapper _mapper;
        #region Instacia SqlMapper
        SqlMapper Instance()
        {
            return ((_mapper == null) ? _mapper = MapperFactory.CrearMapper() : _mapper);
        }
        #endregion

        public int IDITEMRESPUESTA { get; set; }
        public int IDPREGUNTA { get; set; }
        public String GLOSARESPUESTA { get; set; }
        public String VALORRESPUESTA { get; set; }
        public int NUMEROORDEN { get; set; }
        public String VALORTIPOCOLUMNA { get; set; }
        public String GLOSATIPOCOLUMNA { get; set; }
        public int TIPOPREGUNTARESPONDIDA { get; set; }
        public String OTRARESPUESTA { get; set; }
        public int IDRESPUESTA { get; set; }


        #region Metodos DaoCW_ITEMRESPUESTA
        public int Create(ItemRespuesta daoObject)
        {
            try
            {
                DaoCW_ITEMRESPUESTA daocw_itemrespuesta = DaoCW_ITEMRESPUESTATypeHandler.CastToDao(daoObject);
                object resultado = Instance().Insert("DaoCW_ITEMRESPUESTA.CreateDaoCW_ITEMRESPUESTA", daocw_itemrespuesta);
                return Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear daocw_itemrespuesta", ex);
            }
        }

        public ItemRespuesta Find(int id)
        {
            try
            {
                DaoCW_ITEMRESPUESTA resultado = Instance().QueryForObject<DaoCW_ITEMRESPUESTA>("DaoCW_ITEMRESPUESTA.Find", id);
                ItemRespuesta resultadoCasteado = DaoCW_ITEMRESPUESTATypeHandler.CastToDto(resultado);
                return resultadoCasteado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_ITEMRESPUESTA", ex);
            }
        }

        public List<ItemRespuesta> FindAll()
        {
            try
            {
                return DaoCW_ITEMRESPUESTATypeHandler.CastList(Instance().QueryForList<DaoCW_ITEMRESPUESTA>("DaoCW_ITEMRESPUESTA.FindAllDaoCW_ITEMRESPUESTA", null));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_ITEMRESPUESTA", ex);
            }
        }

        public void Update(ItemRespuesta daoObject)
        {
            try
            {
                DaoCW_ITEMRESPUESTA daocw_itemrespuesta = DaoCW_ITEMRESPUESTATypeHandler.CastToDao(daoObject);
                Instance().Update("DaoCW_ITEMRESPUESTA.UpdateDaoCW_ITEMRESPUESTA", daocw_itemrespuesta);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de actualizar datos de daocw_itemrespuesta", ex);
            }

        }

        public void Delete(int idStatement)
        {
            try
            {
                Instance().Delete("DaoCW_ITEMRESPUESTA.DeleteDaoCW_ITEMRESPUESTA", idStatement);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de eliminar daocw_itemrespuesta", ex);

            }

        }

        #endregion


        internal List<ItemRespuesta> FindByPreguntaId(int preguntaId)
        {
            try
            {
                return DaoCW_ITEMRESPUESTATypeHandler.CastList(Instance().QueryForList<DaoCW_ITEMRESPUESTA>("DaoCW_ITEMRESPUESTA.FindDaoCW_ITEMRESPUESTAByPREGUNTAID", preguntaId));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_ITEMRESPUESTA", ex);
            }
        }

        internal List<ItemRespuesta> FindByRespuestaId(int idRespuesta)
        {
            try
            {
                return DaoCW_ITEMRESPUESTATypeHandler.CastList(Instance().QueryForList<DaoCW_ITEMRESPUESTA>("DaoCW_ITEMRESPUESTA.FindDaoCW_BYIDRESPUESTA", idRespuesta));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_ITEMRESPUESTA", ex);
            }
        }
    }
}
