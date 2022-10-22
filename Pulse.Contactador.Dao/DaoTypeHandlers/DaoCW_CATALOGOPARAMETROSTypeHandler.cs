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
    public class DaoCW_CATALOGOPARAMETROSTypeHandler
    {
        public static CatalogoParametro CastToDto(DaoCW_CATALOGOPARAMETROS cw_catalogoparametros)
        {
            CatalogoParametro dtoObject = new CatalogoParametro();
            dtoObject.Id = cw_catalogoparametros.IDCATALOGOPARAMETRO;
            dtoObject.Nombre = cw_catalogoparametros.NOMBRE;
            dtoObject.TipoEstadoEntidad = (TiposEstadoEntidad)cw_catalogoparametros.TIPOESTADOENTIDAD;
            dtoObject.Codigo = cw_catalogoparametros.CODIGO;
            return dtoObject;
        }

        public static DaoCW_CATALOGOPARAMETROS CastToDao(CatalogoParametro dtoObject)
        {
            DaoCW_CATALOGOPARAMETROS daoObject = new DaoCW_CATALOGOPARAMETROS();
            daoObject.IDCATALOGOPARAMETRO = dtoObject.Id;
            daoObject.NOMBRE = dtoObject.Nombre;
            daoObject.TIPOESTADOENTIDAD = (int)dtoObject.TipoEstadoEntidad;
            daoObject.CODIGO = dtoObject.Codigo;
            return daoObject;
        }

        public static List<CatalogoParametro> CastList(IList<DaoCW_CATALOGOPARAMETROS> listOfDaocw_catalogoparametros)
        {
            List<CatalogoParametro> resultado = new List<CatalogoParametro>();
            foreach (var cadacw_catalogoparametros in listOfDaocw_catalogoparametros)
            {
                resultado.Add(CastToDto(cadacw_catalogoparametros));
            }
            return resultado;
        }


    }
}
