using System;
using System.Collections.Generic;
using System.Text;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System.Linq;
using System.Diagnostics;
using Pulse.Contactador.Dao.DaoDataModel;
using Pulse.Contactador.Dto;
using Pulse.Contactador.Dto.Core;

namespace Pulse.Contactador.Dao.DaoTypeHandlers
{
    public class DaoCW_ITEMCATALOGOPARAMETROTypeHandler
    {
        public static ItemCatalogoParametro CastToDto(DaoCW_ITEMCATALOGOPARAMETRO cw_itemcatalogoparametro)
        {
            ItemCatalogoParametro dtoObject = new ItemCatalogoParametro();
            dtoObject.Id = cw_itemcatalogoparametro.IDITEMCATALOGOPARAMETRO;
            dtoObject.Descripcion = cw_itemcatalogoparametro.DESCRIPCION;
            dtoObject.Codigo = cw_itemcatalogoparametro.CODIGO;
            dtoObject.TipoEstadoEntidad = (TiposEstadoEntidad)cw_itemcatalogoparametro.TIPOESTADOENTIDAD;
            dtoObject.IdentificadorPropietario = cw_itemcatalogoparametro.IDITEMCATALOGOPARAMETRO;
            return dtoObject;
        }

        public static DaoCW_ITEMCATALOGOPARAMETRO CastToDao(ItemCatalogoParametro dtoObject)
        {
            DaoCW_ITEMCATALOGOPARAMETRO daoObject = new DaoCW_ITEMCATALOGOPARAMETRO();
            daoObject.IDITEMCATALOGOPARAMETRO = dtoObject.Id;
            daoObject.DESCRIPCION = dtoObject.Descripcion;
            daoObject.CODIGO = dtoObject.Codigo;
            daoObject.TIPOESTADOENTIDAD = (int)dtoObject.TipoEstadoEntidad;
            daoObject.IDCATALOGOPARAMETRO = dtoObject.IdentificadorPropietario;
            return daoObject;
        }

        public static List<ItemCatalogoParametro> CastList(IList<DaoCW_ITEMCATALOGOPARAMETRO> listOfDaocw_itemcatalogoparametro)
        {
            List<ItemCatalogoParametro> resultado = new List<ItemCatalogoParametro>();
            foreach (var cadacw_itemcatalogoparametro in listOfDaocw_itemcatalogoparametro)
            {
                resultado.Add(CastToDto(cadacw_itemcatalogoparametro));
            }
            return resultado;
        }


    }
}
