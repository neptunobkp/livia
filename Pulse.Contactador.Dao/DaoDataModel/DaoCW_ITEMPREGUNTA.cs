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
    public class DaoCW_ITEMPREGUNTA
    {
        SqlMapper _mapper;
        #region Instacia SqlMapper
        SqlMapper Instance()
        {
            return ((_mapper == null) ? _mapper = MapperFactory.CrearMapper() : _mapper);
        }
        #endregion

        public int IDITEMPREGUNTA { get; set; }
        public int IDPREGUNTA { get; set; }
        public int TIPOITEMPREGUNTA { get; set; }
        public int ORDENCORRELATIVO { get; set; }
        public String VALORINTERNO { get; set; }
        public String GLOSA { get; set; }


        #region Metodos DaoCW_ITEMPREGUNTA
        public int Create(ItemPregunta daoObject)
        {
            try
            {
                DaoCW_ITEMPREGUNTA daocw_itempregunta = DaoCW_ITEMPREGUNTATypeHandler.CastToDao(daoObject);
                object resultado = Instance().Insert("DaoCW_ITEMPREGUNTA.CreateDaoCW_ITEMPREGUNTA", daocw_itempregunta);
                return Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear daocw_itempregunta", ex);
            }

        }

        public ItemPregunta Find(int id)
        {
            try
            {
                DaoCW_ITEMPREGUNTA resultado = Instance().QueryForObject<DaoCW_ITEMPREGUNTA>("DaoCW_ITEMPREGUNTA.Find", id);
                ItemPregunta resultadoCasteado = DaoCW_ITEMPREGUNTATypeHandler.CastToDto(resultado);
                return resultadoCasteado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_ITEMPREGUNTA", ex);
            }
        }

        public List<ItemPregunta> FindAll()
        {
            try
            {
                return DaoCW_ITEMPREGUNTATypeHandler.CastList(Instance().QueryForList<DaoCW_ITEMPREGUNTA>("DaoCW_ITEMPREGUNTA.FindAllDaoCW_ITEMPREGUNTA", null));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_ITEMPREGUNTA", ex);
            }
        }

        public void Update(ItemPregunta daoObject)
        {
            try
            {
                DaoCW_ITEMPREGUNTA daocw_itempregunta = DaoCW_ITEMPREGUNTATypeHandler.CastToDao(daoObject);
                Instance().Update("DaoCW_ITEMPREGUNTA.UpdateDaoCW_ITEMPREGUNTA", daocw_itempregunta);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de actualizar datos de daocw_itempregunta", ex);
            }

        }

        public void Delete(int idStatement)
        {
            try
            {
                Instance().Delete("DaoCW_ITEMPREGUNTA.DeleteDaoCW_ITEMPREGUNTA", idStatement);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de eliminar daocw_itempregunta", ex);
            }

        }

        #endregion


        internal List<ItemPregunta> FindByPreguntaId(int id)
        {
            try
            {
                return DaoCW_ITEMPREGUNTATypeHandler.CastList(Instance().QueryForList<DaoCW_ITEMPREGUNTA>("DaoCW_ITEMPREGUNTA.FindDaoCW_ITEMPREGUNTAByIDPREGUNTA", id));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_ITEMPREGUNTA", ex);
            }
        }
    }
}
