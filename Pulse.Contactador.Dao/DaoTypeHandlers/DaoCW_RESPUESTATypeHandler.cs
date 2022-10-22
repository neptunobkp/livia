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
    public class DaoCW_RESPUESTATypeHandler
    {
        public static Respuesta CastToDto(DaoCW_RESPUESTA cw_respuesta)
        {
            Respuesta dtoObject = new Respuesta() { EncuestaRespondida = new Encuesta(), Encuestado = new PersonaEncuestable(), CampaniaPropietaria = new Campania() };
            dtoObject.Id = cw_respuesta.IDRESPUESTA;
            dtoObject.EncuestaRespondida.Id = cw_respuesta.IDENCUESTA;
            dtoObject.Encuestado.Rut = cw_respuesta.ENCUESTADORUT;
            dtoObject.Encuestado.Nombre = cw_respuesta.ENCUESTADONOMBRE;
            dtoObject.Encuestado.Correo = cw_respuesta.ENCUESTADOCORREO;
            dtoObject.InicioRespuestaEncuesta = cw_respuesta.INICIORESPUESTAENCUESTA;
            dtoObject.TerminoRespuestaEncuesta = cw_respuesta.TERMINORESPUESTAENCUESTA;
            dtoObject.DireccionIP = cw_respuesta.DIRECCIONIP;
            dtoObject.Completado = Convert.ToBoolean(cw_respuesta.COMPLETADO);
            dtoObject.MinutosParaCompletarEncuesta = cw_respuesta.MINUTOSTRANSCURRIDOS;
            dtoObject.Navegador = cw_respuesta.NAVEGADOR;
            dtoObject.UrlEncuestaEnviada = cw_respuesta.URLENCUESTAENVIADA;
            dtoObject.Anotacion = cw_respuesta.ANOTACION;
            dtoObject.Encuestado.Id = cw_respuesta.IDITEMCORREODESTINO;
            dtoObject.TipoEstadoRespuestaEncuesta = (TiposEstadoRespuestaEncuesta)cw_respuesta.TIPOESTADORESPUESTA;
            dtoObject.CampaniaPropietaria.Id = cw_respuesta.IDCAMPANIA;
            return dtoObject;
        }

        public static DaoCW_RESPUESTA CastToDao(Respuesta dtoObject)
        {
            DaoCW_RESPUESTA daoObject = new DaoCW_RESPUESTA();
            daoObject.IDRESPUESTA = dtoObject.Id;
            daoObject.IDENCUESTA = dtoObject.EncuestaRespondida.Id;
            daoObject.ENCUESTADORUT = dtoObject.Encuestado.Rut;
            daoObject.ENCUESTADONOMBRE = dtoObject.Encuestado.Nombre;
            daoObject.ENCUESTADOCORREO = dtoObject.Encuestado.Correo;
            daoObject.INICIORESPUESTAENCUESTA = dtoObject.InicioRespuestaEncuesta;
            daoObject.TERMINORESPUESTAENCUESTA = dtoObject.TerminoRespuestaEncuesta;
            daoObject.DIRECCIONIP = dtoObject.DireccionIP;
            daoObject.COMPLETADO = Convert.ToInt32(dtoObject.Completado);
            daoObject.MINUTOSTRANSCURRIDOS = dtoObject.MinutosParaCompletarEncuesta;
            daoObject.NAVEGADOR = dtoObject.Navegador;
            daoObject.URLENCUESTAENVIADA = dtoObject.UrlEncuestaEnviada;
            daoObject.NOMBREUSUARIOCLIENTE = dtoObject.NombreUsuarioCliente;
            daoObject.ANOTACION = dtoObject.Anotacion;
            daoObject.IDITEMCORREODESTINO = dtoObject.Encuestado.Id;
            daoObject.TIPOESTADORESPUESTA = (int)dtoObject.TipoEstadoRespuestaEncuesta;
            daoObject.IDCAMPANIA = dtoObject.CampaniaPropietaria.Id;
            return daoObject;
        }

        public static List<Respuesta> CastList(IList<DaoCW_RESPUESTA> listOfDaocw_respuesta)
        {
            List<Respuesta> resultado = new List<Respuesta>();
            foreach (var cadacw_respuesta in listOfDaocw_respuesta)
            {
                resultado.Add(CastToDto(cadacw_respuesta));
            }
            return resultado;
        }


    }
}
