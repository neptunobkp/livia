using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dto;

namespace Pulse.Contactador.BusinessLogic.EnvioCorreo
{
    public class ConfiguradorArchivosAdjuntos
    {
        /// <summary>
        /// Método para configurar los archivos adjuntos en un mensaje de campania
        /// </summary>
        /// <param name="campania">Campaña para configuración</param>
        /// <param name="rutaContenedorArchivosAdjuntos">Esta ruta, debe ser la del sitio /bandeja. dentro de la bandeja existira una carpeta para los archivos adjuntos de mensaje</param>
        public void ConfigurarArchivosAdjuntosCampania(Campania campania, String rutaContenedorArchivosAdjuntos)
        {
            if (campania.ControladorEnvioCorreo.TipoEnvioCorreo == TiposEnvioCorreo.EnvioConElMismoMensaje)
                configurarArchivosAdjuntosMensajeUnico(campania, rutaContenedorArchivosAdjuntos);
        }




        private static void configurarArchivosAdjuntosMensajeUnico(Campania campania, String rutaContenedorArchivosAdjuntos)
        {
            if (campania.ControladorEnvioCorreo.MensajeCorreoUnico.ReferenciaArchivoAdjuntos == null) return;
            List<String> nombreArchivosAdjuntos = campania.ControladorEnvioCorreo.MensajeCorreoUnico.ReferenciaArchivoAdjuntos.Split('|').ToList();
            nombreArchivosAdjuntos = nombreArchivosAdjuntos.Where(t => !string.IsNullOrEmpty(t)).ToList();
            if (nombreArchivosAdjuntos.Count > 0)
            {
                campania.ControladorEnvioCorreo.MensajeCorreoUnico.ArchivosEnviables = new List<ArchivoEnviable>();
                foreach (String cadaNombreArchivo in nombreArchivosAdjuntos)
                {
                    campania.ControladorEnvioCorreo.MensajeCorreoUnico.ArchivosEnviables.Add(new ArchivoEnviable()
                    {
                        RutaFisica = String.Format(@"{0}{1}\{2}", rutaContenedorArchivosAdjuntos, campania.ControladorEnvioCorreo.MensajeCorreoUnico.Id.ToString(), cadaNombreArchivo),
                        Nombre = cadaNombreArchivo
                    });
                }
            }
        }
    }
}
