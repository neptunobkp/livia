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
    public class DaoCW_SEGUIMIENTOENCUESTATypeHandler
    {
        public static SeguimientoEncuesta CastToDto(DaoCW_SEGUIMIENTOENCUESTA cw_seguimientoEncuesta)
        {
            SeguimientoEncuesta dtoObject = new SeguimientoEncuesta() { Encuesta = new Encuesta(), Evaluador = new Evaluador() };
            dtoObject.Evaluador.Id = cw_seguimientoEncuesta.IDEVALUADOR;
            dtoObject.Encuesta.Id = cw_seguimientoEncuesta.IDENCUESTA;
            dtoObject.FechaUltimoEnvio = cw_seguimientoEncuesta.FECHAULTIMOENVIO;
            dtoObject.CuerpoCorreo = cw_seguimientoEncuesta.CUERPOCORREO;
            dtoObject.CantidadRecordatorios = cw_seguimientoEncuesta.CANTIDADRECORDATORIOS;
            return dtoObject;
        }

        public static DaoCW_SEGUIMIENTOENCUESTA CastToDao(SeguimientoEncuesta dtoObject)
        {
            DaoCW_SEGUIMIENTOENCUESTA daoObject = new DaoCW_SEGUIMIENTOENCUESTA();

            daoObject.IDEVALUADOR = dtoObject.Evaluador.Id;
            daoObject.IDENCUESTA = dtoObject.Encuesta.Id;
            daoObject.CANTIDADRECORDATORIOS = dtoObject.CantidadRecordatorios;
            daoObject.CUERPOCORREO = dtoObject.CuerpoCorreo;
            daoObject.FECHAULTIMOENVIO = dtoObject.FechaUltimoEnvio;
            return daoObject;
        }

        public static List<SeguimientoEncuesta> CastList(IList<DaoCW_SEGUIMIENTOENCUESTA> listOfDaocw_seguimientoEncuesta)
        {
            List<SeguimientoEncuesta> resultado = new List<SeguimientoEncuesta>();
            foreach (var cadacw_seguimientoEncuesta in listOfDaocw_seguimientoEncuesta)
            {
                resultado.Add(CastToDto(cadacw_seguimientoEncuesta));
            }
            return resultado;
        }
    }
}
