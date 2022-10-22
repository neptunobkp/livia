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
    public class DaoCW_CONFSALIDACORREOTypeHandler
    {
        public static ConfiguracionSalidaCorreo CastToDto(DaoCW_CONFSALIDACORREO cw_confsalidacorreo)
        {
            ConfiguracionSalidaCorreo dtoObject = new ConfiguracionSalidaCorreo() { UsuarioCreador = new Usuario(), UsuarioModificador = new Usuario() };
            dtoObject.Id = cw_confsalidacorreo.IDCONFSALIDACORREO;
            dtoObject.ServidorSmtp = cw_confsalidacorreo.SERVIDORSMTP;
            dtoObject.PuertoServidor = cw_confsalidacorreo.PUERTOSERVIDOR;
            dtoObject.SSLHabilitado = cw_confsalidacorreo.SSLHABILITADO;
            dtoObject.Usuario = cw_confsalidacorreo.USUARIO;
            dtoObject.Contrasenia = cw_confsalidacorreo.CONTRASENIA;
            dtoObject.CorreoCasillaSalida = cw_confsalidacorreo.CORREOCASILLASALIDA;
            dtoObject.NombreCasillaSalda = cw_confsalidacorreo.NOMBRECASILLASALDA;
            dtoObject.IdentificadorPropietario = cw_confsalidacorreo.IDPROPIETARIO;
            dtoObject.TipoPropietario = (TiposPropietario)cw_confsalidacorreo.TIPOPROPIETARIO;
            dtoObject.UsuarioCreador.Id = cw_confsalidacorreo.USUARIOCREADOR;
            dtoObject.FechaCreacion = cw_confsalidacorreo.FECHACREACION;
            dtoObject.UsuarioModificador.Id = cw_confsalidacorreo.USUARIOMODIFICADOR;
            dtoObject.FechaModificacion = cw_confsalidacorreo.FECHAMODIFICACION;
            return dtoObject;
        }

        public static DaoCW_CONFSALIDACORREO CastToDao(ConfiguracionSalidaCorreo dtoObject)
        {
            DaoCW_CONFSALIDACORREO daoObject = new DaoCW_CONFSALIDACORREO();
            daoObject.IDCONFSALIDACORREO = dtoObject.Id;
            daoObject.SERVIDORSMTP = dtoObject.ServidorSmtp;
            daoObject.PUERTOSERVIDOR = dtoObject.PuertoServidor;
            daoObject.SSLHABILITADO = dtoObject.SSLHabilitado;
            daoObject.USUARIO = dtoObject.Usuario;
            daoObject.CONTRASENIA = dtoObject.Contrasenia;
            daoObject.CORREOCASILLASALIDA = dtoObject.CorreoCasillaSalida;
            daoObject.NOMBRECASILLASALDA = dtoObject.NombreCasillaSalda;
            daoObject.IDPROPIETARIO = dtoObject.IdentificadorPropietario;
            daoObject.TIPOPROPIETARIO = (int)dtoObject.TipoPropietario;
            daoObject.USUARIOCREADOR = dtoObject.UsuarioCreador.Id;
            daoObject.FECHACREACION = dtoObject.FechaCreacion;
            daoObject.USUARIOMODIFICADOR = dtoObject.UsuarioModificador.Id;
            daoObject.FECHAMODIFICACION = dtoObject.FechaModificacion;
            return daoObject;
        }

        public static List<ConfiguracionSalidaCorreo> CastList(IList<DaoCW_CONFSALIDACORREO> listOfDaocw_confsalidacorreo)
        {
            List<ConfiguracionSalidaCorreo> resultado = new List<ConfiguracionSalidaCorreo>();
            foreach (var cadacw_confsalidacorreo in listOfDaocw_confsalidacorreo)
            {
                resultado.Add(CastToDto(cadacw_confsalidacorreo));
            }
            return resultado;
        }


    }
}
