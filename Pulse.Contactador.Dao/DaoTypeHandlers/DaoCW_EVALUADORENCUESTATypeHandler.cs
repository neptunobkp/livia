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
    public class DaoCW_EVALUADORENCUESTATypeHandler
    {
        public static EvaluadorEncuesta CastToDto(DaoCW_EVALUADORENCUESTA cw_evaluadorencuesta)
        {
            EvaluadorEncuesta dtoObject = new EvaluadorEncuesta() { Encuesta = new Encuesta(), Evaluador = new Evaluador()};
            dtoObject.Evaluador.Id = cw_evaluadorencuesta.IDEVALUADOR;
            dtoObject.Encuesta.Id = cw_evaluadorencuesta.IDENCUESTA;
            dtoObject.Estado = cw_evaluadorencuesta.ESTADO;
            dtoObject.Obligatoriedad = cw_evaluadorencuesta.OBLIGATORIEDAD;
            dtoObject.Guid = cw_evaluadorencuesta.GUID;
            return dtoObject;
        }

        public static DaoCW_EVALUADORENCUESTA CastToDao(EvaluadorEncuesta dtoObject)
        {
            DaoCW_EVALUADORENCUESTA daoObject = new DaoCW_EVALUADORENCUESTA();

            daoObject.IDEVALUADOR = dtoObject.Evaluador.Id;
            daoObject.IDENCUESTA = dtoObject.Encuesta.Id;
            daoObject.ESTADO = dtoObject.Estado;
            daoObject.OBLIGATORIEDAD = dtoObject.Obligatoriedad;
            daoObject.GUID = dtoObject.Guid;
            return daoObject;
        }

        public static List<EvaluadorEncuesta> CastList(IList<DaoCW_EVALUADORENCUESTA> listOfDaocw_evaluadorencuesta)
        {
            List<EvaluadorEncuesta> resultado = new List<EvaluadorEncuesta>();
            foreach (var cadacw_evaluadorencuesta in listOfDaocw_evaluadorencuesta)
            {
                resultado.Add(CastToDto(cadacw_evaluadorencuesta));
            }
            return resultado;
        }
    }
}
