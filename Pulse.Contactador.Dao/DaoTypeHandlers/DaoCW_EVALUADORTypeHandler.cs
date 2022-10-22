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
    public class DaoCW_EVALUADORTypeHandler
    {
        public static Evaluador CastToDto(DaoCW_EVALUADOR cw_evaluador)
        {
            Evaluador dtoObject = new Evaluador();
            dtoObject.Id = cw_evaluador.IDEVALUADOR;
            dtoObject.Correo = cw_evaluador.CORREO;
            dtoObject.Area = cw_evaluador.AREA;
            dtoObject.Gerencia = cw_evaluador.GERENCIA;
            dtoObject.Nombre = cw_evaluador.NOMBRE;
            return dtoObject;
        }

        public static DaoCW_EVALUADOR CastToDao(Evaluador dtoObject)
        {
            DaoCW_EVALUADOR daoObject = new DaoCW_EVALUADOR();

            daoObject.IDEVALUADOR = dtoObject.Id;
            daoObject.CORREO = dtoObject.Correo;
            daoObject.AREA = dtoObject.Area;
            daoObject.GERENCIA = dtoObject.Gerencia;
            daoObject.NOMBRE = dtoObject.Nombre;
            return daoObject;
        }

        public static List<Evaluador> CastList(IList<DaoCW_EVALUADOR> listOfDaocw_evaluador)
        {
            List<Evaluador> resultado = new List<Evaluador>();
            foreach (var cadacw_evaluador in listOfDaocw_evaluador)
            {
                resultado.Add(CastToDto(cadacw_evaluador));
            }
            return resultado;
        }
    }
}
