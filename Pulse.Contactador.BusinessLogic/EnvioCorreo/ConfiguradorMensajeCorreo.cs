using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dto;

namespace Pulse.Contactador.BusinessLogic.EnvioCorreo
{
    public class ConfiguradorMensajeCorreo
    {

        internal void ConfigurarMensaje(CorreoDestino cadaCorreoDestino, MensajeCorreoDestino mensajeCorreoDestino, TiposEnvioCorreo tiposEnvioCorreo)
        {
            if (tiposEnvioCorreo == TiposEnvioCorreo.EnvioConElMismoMensaje)
            {
                cadaCorreoDestino.Mensaje = new MensajeCorreoDestino()
                {
                    Titulo = mensajeCorreoDestino.Titulo,
                    CuerpoHtml = mensajeCorreoDestino.CuerpoHtml,
                    ArchivosEnviables = clonarArchivos(mensajeCorreoDestino.ArchivosEnviables),
                };
            }
            else
            {
                cadaCorreoDestino.Mensaje = new MensajeCorreoDestino()
                {
                    Titulo = mensajeCorreoDestino.Titulo,
                    CuerpoHtml = mensajeCorreoDestino.CuerpoHtml,
                    ArchivosEnviables = clonarArchivos(mensajeCorreoDestino.ArchivosEnviables),
                };
            }
        }

        private List<ArchivoEnviable> clonarArchivos(List<ArchivoEnviable> archivosEnviables)
        {
            if (archivosEnviables == null) return null;
            List<ArchivoEnviable> resultado = new List<ArchivoEnviable>();
            foreach (var cadaItem in archivosEnviables)
            {
                resultado.Add(new ArchivoEnviable() { RutaFisica = cadaItem.RutaFisica });
            }
            return resultado;
        }
    }
}
