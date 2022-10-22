using System;
using System.Collections.Generic;
using System.Text;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System.Linq;
using System.Diagnostics;
using Pulse.Contactador.Dao.DaoDataModel;
using Pulse.Contactador.Dto;
using Pulse.Contactador.Dto.Agendable;

namespace Pulse.Contactador.Dao.DaoTypeHandlers
{
    public class DaoCW_ITEMCORREODESTINOTypeHandler
    {
        public static CorreoDestino CastToDto(DaoCW_ITEMCORREODESTINO cw_itemcorreodestino)
        {
            CorreoDestino dtoObject = new CorreoDestino() { Destinatario = new PersonaDestinatario(), Mensaje = new MensajeCorreoDestino() };
            dtoObject.Id = cw_itemcorreodestino.IDITEMCORREODESTINO;
            dtoObject.Destinatario.Rut = cw_itemcorreodestino.RUTDESTINATARIO;
            dtoObject.IdentificadorRelacionalOrigen = cw_itemcorreodestino.IDENTIFICADORRELACIONALORIGEN;
            dtoObject.Mensaje.Id = cw_itemcorreodestino.IDMENSAJECORREO;
            dtoObject.ParametrosEncadenables = cw_itemcorreodestino.PARAMETROSENCADENABLES;
            dtoObject.ArchivosAdjuntosEnviable = cw_itemcorreodestino.ARCHIVOSENVIABLES;
            dtoObject.TipoEstadoEnvio = (TiposEstadoEnvio)cw_itemcorreodestino.TIPOESTADOENVIO;
            dtoObject.Anotacion = cw_itemcorreodestino.ANOTACION;
            dtoObject.Destinatario.Nombre = cw_itemcorreodestino.NOMBREDESTINATARIO;
            dtoObject.Destinatario.Correo = cw_itemcorreodestino.CORREODESTINATARIO;
            dtoObject.IdentificadorPropietario = cw_itemcorreodestino.IDLISTACORREO;
            dtoObject.TipoEstadoEnvio = (TiposEstadoEnvio)cw_itemcorreodestino.TIPOESTADOENVIO;
            dtoObject.FechaEnvio = cw_itemcorreodestino.FECHAENVIO;
            dtoObject.Destinatario.Celular = cw_itemcorreodestino.CELULAR;
            return dtoObject;
        }

        public static DaoCW_ITEMCORREODESTINO CastToDao(CorreoDestino dtoObject)
        {
            DaoCW_ITEMCORREODESTINO daoObject = new DaoCW_ITEMCORREODESTINO();
            daoObject.IDITEMCORREODESTINO = dtoObject.Id;
            daoObject.RUTDESTINATARIO = dtoObject.Destinatario.Rut;
            daoObject.IDENTIFICADORRELACIONALORIGEN = dtoObject.IdentificadorRelacionalOrigen;

            if (dtoObject.FechaEnvio.Year == 1) // Arreglo para fecha nula en sqlserver - oracle
                daoObject.FECHAENVIO = new DateTime(1970, 1, 1);
            else
                daoObject.FECHAENVIO = dtoObject.FechaEnvio;

            if (dtoObject.Mensaje != null)
                daoObject.IDMENSAJECORREO = dtoObject.Mensaje.Id;
            daoObject.PARAMETROSENCADENABLES = dtoObject.GlosaParametrosEncadenables;
            daoObject.ARCHIVOSENVIABLES = dtoObject.ArchivosAdjuntosEnviable;
            daoObject.TIPOESTADOENVIO = (int)dtoObject.TipoEstadoEnvio;
            daoObject.ANOTACION = dtoObject.Anotacion;
            daoObject.NOMBREDESTINATARIO = dtoObject.Destinatario.Nombre;
            daoObject.CORREODESTINATARIO = dtoObject.Destinatario.Correo;
            daoObject.IDLISTACORREO = dtoObject.IdentificadorPropietario;
            daoObject.CELULAR = dtoObject.Destinatario.Celular;

            return daoObject;
        }

        public static List<CorreoDestino> CastList(IList<DaoCW_ITEMCORREODESTINO> listOfDaocw_itemcorreodestino)
        {
            List<CorreoDestino> resultado = new List<CorreoDestino>();
            foreach (var cadacw_itemcorreodestino in listOfDaocw_itemcorreodestino)
            {
                resultado.Add(CastToDto(cadacw_itemcorreodestino));
            }
            return resultado;
        }


    }
}
