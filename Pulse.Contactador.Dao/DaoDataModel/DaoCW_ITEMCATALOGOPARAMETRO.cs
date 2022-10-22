using System;
using System.Collections.Generic;
using System.Text;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System.Linq;
using System.Diagnostics;
using Pulse.Contactador.Dto;
using Pulse.Contactador.Dto.Core;
using Pulse.Contactador.Dao.DaoTypeHandlers;
using Pulse.Utils.Exceptions;

namespace Pulse.Contactador.Dao.DaoDataModel
{
    public class DaoCW_ITEMCATALOGOPARAMETRO
    {
        SqlMapper _mapper;
        #region Instacia SqlMapper
        SqlMapper Instance()
        {
            return ((_mapper == null) ? _mapper = MapperFactory.CrearMapper() : _mapper);
        }
        #endregion

        public int IDITEMCATALOGOPARAMETRO { get; set; }
        public String DESCRIPCION { get; set; }
        public String CODIGO { get; set; }
        public int TIPOESTADOENTIDAD { get; set; }
        public int IDCATALOGOPARAMETRO { get; set; }

        #region Metodos DaoCW_ITEMCATALOGOPARAMETRO
        public int Create(ItemCatalogoParametro daoObject)
        {
            try
            {
                DaoCW_ITEMCATALOGOPARAMETRO daocw_itemcatalogoparametro = DaoCW_ITEMCATALOGOPARAMETROTypeHandler.CastToDao(daoObject);
                object resultado = Instance().Insert("DaoCW_ITEMCATALOGOPARAMETRO.CreateDaoCW_ITEMCATALOGOPARAMETRO", daocw_itemcatalogoparametro);
                return Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear daocw_itemcatalogoparametro", ex);
            }
        }

        public ItemCatalogoParametro Find(int id)
        {
            try
            {
                DaoCW_ITEMCATALOGOPARAMETRO resultado = Instance().QueryForObject<DaoCW_ITEMCATALOGOPARAMETRO>("DaoCW_ITEMCATALOGOPARAMETRO.Find", id);
                ItemCatalogoParametro resultadoCasteado = DaoCW_ITEMCATALOGOPARAMETROTypeHandler.CastToDto(resultado);
                return resultadoCasteado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_ITEMCATALOGOPARAMETRO", ex);
            }
        }

        public List<ItemCatalogoParametro> FindAll()
        {
            try
            {
                return DaoCW_ITEMCATALOGOPARAMETROTypeHandler.CastList(Instance().QueryForList<DaoCW_ITEMCATALOGOPARAMETRO>("DaoCW_ITEMCATALOGOPARAMETRO.FindAllDaoCW_ITEMCATALOGOPARAMETRO", null));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_ITEMCATALOGOPARAMETRO", ex);
            }
        }

        public void Update(ItemCatalogoParametro daoObject)
        {
            try
            {
                DaoCW_ITEMCATALOGOPARAMETRO daocw_itemcatalogoparametro = DaoCW_ITEMCATALOGOPARAMETROTypeHandler.CastToDao(daoObject);
                Instance().Update("DaoCW_ITEMCATALOGOPARAMETRO.UpdateDaoCW_ITEMCATALOGOPARAMETRO", daocw_itemcatalogoparametro);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de actualizar datos de daocw_itemcatalogoparametro", ex);
            }

        }

        public void Delete(int idStatement)
        {
            try
            {
                Instance().Delete("DaoCW_ITEMCATALOGOPARAMETRO.DeleteDaoCW_ITEMCATALOGOPARAMETRO", idStatement);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de eliminar daocw_itemcatalogoparametro", ex);

            }

        }

        #endregion

    }
}
