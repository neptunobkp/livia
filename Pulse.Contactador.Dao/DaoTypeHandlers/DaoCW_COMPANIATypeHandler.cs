using System;
using System.Collections.Generic;
using System.Text;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System.Linq;
using System.Diagnostics;
using Pulse.Contactador.Dao.DaoDataModel;
using Pulse.Contactador.Dto;

namespace Pulse.Contactador.Dao.DaoTypeHandlers
{
    public class DaoCW_COMPANIATypeHandler
    {
        public static Empresa CastToDto(DaoCW_COMPANIA cw_compania)
        {
            Empresa dtoObject = new Empresa();
            dtoObject.Id = cw_compania.IDCOMPANIA;
            dtoObject.Rut = cw_compania.RUT;
            dtoObject.RazonSocial = cw_compania.RAZONSOCIAL;
            dtoObject.TipoEstadoEntidad = (TiposEstadoEntidad)cw_compania.TIPOESTADOENTIDAD;
            return dtoObject;
        }

        public static DaoCW_COMPANIA CastToDao(Empresa dtoObject)
        {
            DaoCW_COMPANIA daoObject = new DaoCW_COMPANIA();
            daoObject.IDCOMPANIA = dtoObject.Id;
            daoObject.RUT = dtoObject.Rut;
            daoObject.RAZONSOCIAL = dtoObject.RazonSocial;
            daoObject.TIPOESTADOENTIDAD = (int)dtoObject.TipoEstadoEntidad;
            return daoObject;
        }

        public static List<Empresa> CastList(IList<DaoCW_COMPANIA> listOfDaocw_compania)
        {
            List<Empresa> resultado = new List<Empresa>();
            foreach (var cadacw_compania in listOfDaocw_compania)
            {
                resultado.Add(CastToDto(cadacw_compania));
            }
            return resultado;
        }


    }
}
