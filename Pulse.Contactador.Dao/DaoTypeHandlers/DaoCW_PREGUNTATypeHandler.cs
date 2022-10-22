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
    public class DaoCW_PREGUNTATypeHandler
    {
        public static Pregunta CastToDto(DaoCW_PREGUNTA cw_pregunta)
        {
            Pregunta dtoObject = new Pregunta();
            dtoObject.Id = cw_pregunta.IDPREGUNTA;
            dtoObject.GlosaPregunta = cw_pregunta.GLOSAPREGUNTA;
            dtoObject.NotaAdicionalPregunta = cw_pregunta.NOTAADICIONALPREGUNTA;
            dtoObject.NotaAdicionalFinalPregunta = cw_pregunta.NOTAADICIONALFINALPREGUNTA;
            dtoObject.TipoPregunta = (TiposPregunta)cw_pregunta.TIPOPREGUNTA;
            dtoObject.Codigo = cw_pregunta.CODIGOIDENTIFICADOR;
            dtoObject.IdentificadorPropietario = cw_pregunta.IDPAGINA;
            dtoObject.NumeroPagina = cw_pregunta.NUMEROPAGINA;
            dtoObject.Obligatorio = Convert.ToBoolean(cw_pregunta.OBLIGATORIO);
            dtoObject.CategoriaPregunta = cw_pregunta.CATEGORIAPREGUNTA;

            switch ((TiposPregunta)cw_pregunta.TIPOPREGUNTA)
            {
                case TiposPregunta.SeleccionUnica:
                    PreguntaOpcionUnica resultDtoObjectPOU = new PreguntaOpcionUnica();
                    copiarInfoPOU(resultDtoObjectPOU, dtoObject);
                    resultDtoObjectPOU.OtraOpcion = Convert.ToBoolean(cw_pregunta.OTRAOPCION);
                    resultDtoObjectPOU.PresentarAleatoriamente = Convert.ToBoolean(cw_pregunta.PRESENTARALEATORIAMENTE);
                    resultDtoObjectPOU.PresentarEnCombobox = Convert.ToBoolean(cw_pregunta.PRESENTARENCOMBOBOX);
                    resultDtoObjectPOU.PresentarHorizontal = Convert.ToBoolean(cw_pregunta.PRESENTARHORIZONTAL);
                    return resultDtoObjectPOU;
                case TiposPregunta.SeleccionMultiple:
                    PreguntaOpcionMultiple resultDtoObjectPOM = new PreguntaOpcionMultiple();
                    copiarInfoPOM(resultDtoObjectPOM, dtoObject);
                    resultDtoObjectPOM.CantidadColumnasPresentacion = cw_pregunta.CANTIDADCOLUMNASPRESENTACION;
                    resultDtoObjectPOM.LimiteMaximoSeleccionables = cw_pregunta.LIMITEMAXIMOSELECCIONABLES;
                    resultDtoObjectPOM.LimiteMinimoSeleccionables = cw_pregunta.LIMITEMINIMOSELECCIONABLES;
                    resultDtoObjectPOM.OtraOpcion = Convert.ToBoolean(cw_pregunta.OTRAOPCION);
                    resultDtoObjectPOM.PresentarAleatoriamente = Convert.ToBoolean(cw_pregunta.PRESENTARALEATORIAMENTE);
                    return resultDtoObjectPOM;
                case TiposPregunta.Matriz:
                    PreguntaMatriz resultDtoObjectPM = new PreguntaMatriz();
                    copiarInfoPM(resultDtoObjectPM, dtoObject);
                    return resultDtoObjectPM;
                default:
                    break;
            }
            return dtoObject;
        }

        private static void copiarInfoPM(PreguntaMatriz resultDtoObjectPM, Pregunta dtoObject)
        {
            resultDtoObjectPM.Id = dtoObject.Id;
            resultDtoObjectPM.GlosaPregunta = dtoObject.GlosaPregunta;
            resultDtoObjectPM.NotaAdicionalPregunta = dtoObject.NotaAdicionalPregunta;
            resultDtoObjectPM.NotaAdicionalFinalPregunta = dtoObject.NotaAdicionalFinalPregunta;
            resultDtoObjectPM.TipoPregunta = dtoObject.TipoPregunta;
            resultDtoObjectPM.Codigo = dtoObject.Codigo;
            resultDtoObjectPM.IdentificadorPropietario = dtoObject.IdentificadorPropietario;
            resultDtoObjectPM.NumeroPagina = dtoObject.NumeroPagina;
            resultDtoObjectPM.Obligatorio = dtoObject.Obligatorio;
            resultDtoObjectPM.CategoriaPregunta = dtoObject.CategoriaPregunta;
        }

        private static void copiarInfoPOU(PreguntaOpcionUnica resultDtoObjectPOU, Pregunta dtoObject)
        {
            resultDtoObjectPOU.Id = dtoObject.Id;
            resultDtoObjectPOU.GlosaPregunta = dtoObject.GlosaPregunta;
            resultDtoObjectPOU.NotaAdicionalPregunta = dtoObject.NotaAdicionalPregunta;
            resultDtoObjectPOU.NotaAdicionalFinalPregunta = dtoObject.NotaAdicionalFinalPregunta;
            resultDtoObjectPOU.TipoPregunta = dtoObject.TipoPregunta;
            resultDtoObjectPOU.Codigo = dtoObject.Codigo;
            resultDtoObjectPOU.IdentificadorPropietario = dtoObject.IdentificadorPropietario;
            resultDtoObjectPOU.NumeroPagina = dtoObject.NumeroPagina;
            resultDtoObjectPOU.Obligatorio = dtoObject.Obligatorio;
            resultDtoObjectPOU.CategoriaPregunta = dtoObject.CategoriaPregunta;
        }

        private static void copiarInfoPOM(PreguntaOpcionMultiple resultDtoObjectPOM, Pregunta dtoObject)
        {
            resultDtoObjectPOM.Id = dtoObject.Id;
            resultDtoObjectPOM.GlosaPregunta = dtoObject.GlosaPregunta;
            resultDtoObjectPOM.NotaAdicionalPregunta = dtoObject.NotaAdicionalPregunta;
            resultDtoObjectPOM.NotaAdicionalFinalPregunta = dtoObject.NotaAdicionalFinalPregunta;
            resultDtoObjectPOM.TipoPregunta = dtoObject.TipoPregunta;
            resultDtoObjectPOM.Codigo = dtoObject.Codigo;
            resultDtoObjectPOM.IdentificadorPropietario = dtoObject.IdentificadorPropietario;
            resultDtoObjectPOM.NumeroPagina = dtoObject.NumeroPagina;
            resultDtoObjectPOM.Obligatorio = dtoObject.Obligatorio;
            resultDtoObjectPOM.CategoriaPregunta = dtoObject.CategoriaPregunta;
        }

        public static DaoCW_PREGUNTA CastToDao(Pregunta dtoObject)
        {
            DaoCW_PREGUNTA daoObject = new DaoCW_PREGUNTA();

            daoObject.IDPREGUNTA = dtoObject.Id;
            daoObject.GLOSAPREGUNTA = dtoObject.GlosaPregunta;
            daoObject.NOTAADICIONALPREGUNTA = dtoObject.NotaAdicionalPregunta;
            daoObject.NOTAADICIONALFINALPREGUNTA = dtoObject.NotaAdicionalFinalPregunta;
            daoObject.TIPOPREGUNTA = (int)dtoObject.TipoPregunta;
            daoObject.CODIGOIDENTIFICADOR = dtoObject.Codigo;
            daoObject.IDPAGINA = dtoObject.IdentificadorPropietario;
            daoObject.NUMEROPAGINA = dtoObject.NumeroPagina;
            daoObject.OBLIGATORIO = Convert.ToInt32(dtoObject.Obligatorio);
            daoObject.CATEGORIAPREGUNTA = dtoObject.CategoriaPregunta;
            return daoObject;
        }

        public static DaoCW_PREGUNTA CastToDao(PreguntaOpcionUnica dtoObject)
        {
            DaoCW_PREGUNTA daoObject = new DaoCW_PREGUNTA();

            daoObject.IDPREGUNTA = dtoObject.Id;
            daoObject.GLOSAPREGUNTA = dtoObject.GlosaPregunta;
            daoObject.NOTAADICIONALPREGUNTA = dtoObject.NotaAdicionalPregunta;
            daoObject.NOTAADICIONALFINALPREGUNTA = dtoObject.NotaAdicionalFinalPregunta;
            daoObject.TIPOPREGUNTA = (int)dtoObject.TipoPregunta;
            daoObject.CODIGOIDENTIFICADOR = dtoObject.Codigo;
            daoObject.OTRAOPCION = Convert.ToInt32(dtoObject.OtraOpcion);
            daoObject.PRESENTARALEATORIAMENTE = Convert.ToInt32(dtoObject.PresentarAleatoriamente);
            daoObject.PRESENTARENCOMBOBOX = Convert.ToInt32(dtoObject.PresentarEnCombobox);
            daoObject.PRESENTARHORIZONTAL = Convert.ToInt32(dtoObject.PresentarHorizontal);
            daoObject.IDPAGINA = dtoObject.IdentificadorPropietario;
            daoObject.NUMEROPAGINA = dtoObject.NumeroPagina;
            daoObject.OBLIGATORIO = Convert.ToInt32(dtoObject.Obligatorio);
            daoObject.CATEGORIAPREGUNTA = dtoObject.CategoriaPregunta;
            return daoObject;
        }

        public static DaoCW_PREGUNTA CastToDao(PreguntaOpcionMultiple dtoObject)
        {
            DaoCW_PREGUNTA daoObject = new DaoCW_PREGUNTA();

            daoObject.IDPREGUNTA = dtoObject.Id;
            daoObject.GLOSAPREGUNTA = dtoObject.GlosaPregunta;
            daoObject.NOTAADICIONALPREGUNTA = dtoObject.NotaAdicionalPregunta;
            daoObject.NOTAADICIONALFINALPREGUNTA = dtoObject.NotaAdicionalFinalPregunta;
            daoObject.TIPOPREGUNTA = (int)dtoObject.TipoPregunta;
            daoObject.CODIGOIDENTIFICADOR = dtoObject.Codigo;
            daoObject.OTRAOPCION = Convert.ToInt32(dtoObject.OtraOpcion);
            daoObject.PRESENTARALEATORIAMENTE = Convert.ToInt32(dtoObject.PresentarAleatoriamente);
            daoObject.CANTIDADCOLUMNASPRESENTACION = Convert.ToInt32(dtoObject.CantidadColumnasPresentacion);
            daoObject.LIMITEMAXIMOSELECCIONABLES = Convert.ToInt32(dtoObject.LimiteMaximoSeleccionables);
            daoObject.LIMITEMINIMOSELECCIONABLES = Convert.ToInt32(dtoObject.LimiteMinimoSeleccionables);
            daoObject.IDPAGINA = dtoObject.IdentificadorPropietario;
            daoObject.NUMEROPAGINA = dtoObject.NumeroPagina;
            daoObject.OBLIGATORIO = Convert.ToInt32(dtoObject.Obligatorio);
            daoObject.CATEGORIAPREGUNTA = dtoObject.CategoriaPregunta;
            return daoObject;
        }

        public static DaoCW_PREGUNTA CastToDao(PreguntaMatriz dtoObject)
        {
            DaoCW_PREGUNTA daoObject = new DaoCW_PREGUNTA();

            daoObject.IDPREGUNTA = dtoObject.Id;
            daoObject.GLOSAPREGUNTA = dtoObject.GlosaPregunta;
            daoObject.NOTAADICIONALPREGUNTA = dtoObject.NotaAdicionalPregunta;
            daoObject.NOTAADICIONALFINALPREGUNTA = dtoObject.NotaAdicionalFinalPregunta;
            daoObject.TIPOPREGUNTA = (int)dtoObject.TipoPregunta;
            daoObject.CODIGOIDENTIFICADOR = dtoObject.Codigo;
            daoObject.IDPAGINA = dtoObject.IdentificadorPropietario;
            daoObject.NUMEROPAGINA = dtoObject.NumeroPagina;
            daoObject.OBLIGATORIO = Convert.ToInt32(dtoObject.Obligatorio);
            daoObject.CATEGORIAPREGUNTA = dtoObject.CategoriaPregunta;
            return daoObject;
        }

        public static List<Pregunta> CastList(IList<DaoCW_PREGUNTA> listOfDaocw_pregunta)
        {
            List<Pregunta> resultado = new List<Pregunta>();
            foreach (var cadacw_pregunta in listOfDaocw_pregunta)
            {
                resultado.Add(CastToDto(cadacw_pregunta));
            }
            return resultado;
        }


    }
}
