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
    public class DaoCW_MENSAJECORREOTypeHandler
    {
        public static MensajeCorreoDestino CastToDto(DaoCW_MENSAJECORREO cw_mensajecorreo)
        {
            MensajeCorreoDestino dtoObject = new MensajeCorreoDestino() { UsuarioCreador = new Usuario(), UsuarioModificador = new Usuario() };
            dtoObject.Id = cw_mensajecorreo.IDMENSAJECORREO;
            dtoObject.EncabezadoHtml = cw_mensajecorreo.ENCABEZADOHTML;
            dtoObject.CuerpoHtml = cw_mensajecorreo.CUERPOHTML;
            dtoObject.PiePaginaHtml = cw_mensajecorreo.PIEPAGINAHTML;
            dtoObject.Titulo = cw_mensajecorreo.TITULO;
            dtoObject.NombreDe = cw_mensajecorreo.NOMBREDE;
            dtoObject.DireccionCorreoDe = cw_mensajecorreo.DIRECCIONCORREODE;
            dtoObject.NombreA = cw_mensajecorreo.NOMBREA;
            dtoObject.IdentificadorPropietario = cw_mensajecorreo.IDPROPIETARIO;
            dtoObject.TipoPropietario = (TiposPropietario)cw_mensajecorreo.TIPOPROPIETARIO;
            dtoObject.UsuarioCreador.Id = cw_mensajecorreo.USUARIOCREADOR;
            dtoObject.UsuarioModificador.Id = cw_mensajecorreo.USUARIOMODIFICADOR;
            dtoObject.FechaCreacion = cw_mensajecorreo.FECHACREACION;
            dtoObject.FechaModificacion = cw_mensajecorreo.FECHAMODIFICACION;
            dtoObject.TipoEstadoEntidad = (TiposEstadoEntidad)cw_mensajecorreo.TIPOESTADOENTIDAD;
            dtoObject.ReferenciaArchivoAdjuntos = cw_mensajecorreo.ARCHIVOSADJUNTOS;
            return dtoObject;
        }

        public static DaoCW_MENSAJECORREO CastToDao(MensajeCorreoDestino dtoObject)
        {
            DaoCW_MENSAJECORREO daoObject = new DaoCW_MENSAJECORREO();

            daoObject.IDMENSAJECORREO = dtoObject.Id;
            daoObject.ENCABEZADOHTML = dtoObject.EncabezadoHtml;
            daoObject.CUERPOHTML = dtoObject.CuerpoHtml;
            daoObject.PIEPAGINAHTML = dtoObject.PiePaginaHtml;
            daoObject.TITULO = dtoObject.Titulo;
            daoObject.NOMBREDE = dtoObject.NombreDe;
            daoObject.DIRECCIONCORREODE = dtoObject.DireccionCorreoDe;
            daoObject.NOMBREA = dtoObject.NombreA;
            daoObject.IDPROPIETARIO = dtoObject.IdentificadorPropietario;
            daoObject.TIPOPROPIETARIO = (int)dtoObject.TipoPropietario;
            if (dtoObject.UsuarioCreador != null)
                daoObject.USUARIOCREADOR = dtoObject.UsuarioCreador.Id;
            if (dtoObject.UsuarioModificador != null)
                daoObject.USUARIOMODIFICADOR = dtoObject.UsuarioModificador.Id;
            daoObject.FECHACREACION = dtoObject.FechaCreacion;
            daoObject.FECHAMODIFICACION = dtoObject.FechaModificacion;
            daoObject.TIPOESTADOENTIDAD = (int)dtoObject.TipoEstadoEntidad;
            daoObject.ARCHIVOSADJUNTOS = dtoObject.ReferenciaArchivoAdjuntos;
            return daoObject;
        }

        public static List<MensajeCorreoDestino> CastList(IList<DaoCW_MENSAJECORREO> listOfDaocw_mensajecorreo)
        {
            List<MensajeCorreoDestino> resultado = new List<MensajeCorreoDestino>();
            foreach (var cadacw_mensajecorreo in listOfDaocw_mensajecorreo)
            {
                resultado.Add(CastToDto(cadacw_mensajecorreo));
            }
            return resultado;
        }
    }
}
