using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dto;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using Pulse.Utils.Exceptions;

namespace Pulse.Contactador.BusinessLogic.EnvioCorreo
{
    public class ControladorSuperiorEnvio : IEmailing
    {
        public void EnviarEmail(CorreoDestino correoDestino, ConfiguracionSalidaCorreo config)
        {
            try
            {
                parametrizarMensaje(correoDestino);
                MailMessage objMessage = new MailMessage();
                SmtpClient smtp = new SmtpClient(config.ServidorSmtp);
                //if (config.SSLHabilitado != null) smtp.Credentials = new NetworkCredential(config.Usuario, config.Contrasenia);
                objMessage.To.Add(correoDestino.Destinatario.Correo);
                //objMessage.From = new MailAddress(config.CorreoCasillaSalida, config.NombreCasillaSalda);
                objMessage.From = new MailAddress(config.CorreoCasillaSalida, "Bci Seguros");
                //objMessage.Subject = correoDestino.Mensaje.Titulo;
                objMessage.Subject = "Encuesta Calidad Servicio Interno";
                ContentType htmlMimeType = new System.Net.Mime.ContentType("text/html");
                objMessage.IsBodyHtml = true;
                objMessage.Body = builderPlainHtml(correoDestino.Mensaje.CuerpoHtml);
                objMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess | DeliveryNotificationOptions.OnFailure | DeliveryNotificationOptions.Delay;
                //objMessage.Headers.Add("Disposition-Notification-To", "infozenit@zenitseguros.cl");
                // agregarVistaAlternativaPrincipal(correoDestino, objMessage);
                //agregarVistaAlternativaSecundaria(correoDestino, objMessage);
                objMessage.BodyEncoding = System.Text.Encoding.UTF8;
                agregarArchivosAdjuntos(correoDestino, objMessage);
                if (!string.IsNullOrEmpty(config.PuertoServidor)) smtp.Port = Int32.Parse(config.PuertoServidor);
                if (!string.IsNullOrEmpty(config.SSLHabilitado)) smtp.EnableSsl = Boolean.Parse(config.SSLHabilitado);

                LoggerManager.LogError(correoDestino.Destinatario.Correo + ": " + objMessage.Body, TiposCategoryLog.LogWEB, new Exception());
                smtp.Send(objMessage);
                LoggerManager.LogError("enviado", TiposCategoryLog.LogWEB, new Exception());
                suDescansito();
            }
            catch (Exception ex)
            {
                LoggerManager.LogError("fallo:" + correoDestino.Destinatario.Correo, TiposCategoryLog.LogWEB, ex);
                throw new ActionableException("Email no enviado: " + ex.Message, ex);
            }
        }

        protected String ExtraerMensajeException(System.Net.Mail.SmtpFailedRecipientsException exObj)
        {
            StringBuilder mensajes = new StringBuilder();
            try
            {
                for (int i = 0; i < exObj.InnerExceptions.Length; i++)
                {
                    SmtpStatusCode status = exObj.InnerExceptions[i].StatusCode;
                    if (status == SmtpStatusCode.MailboxBusy ||
                        status == SmtpStatusCode.MailboxUnavailable)
                        mensajes.AppendLine("El status de respuesta de falla fue: " + exObj.InnerExceptions[i].FailedRecipient + " " + status);
                    else
                        mensajes.AppendLine("El status de respuesta de falla fue: " + exObj.InnerExceptions[i].FailedRecipient);
                }
                return mensajes.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        private string builderPlainHtml(string body)
        {
            fabricarBody(body);
            string bodyHtml = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>";
            bodyHtml += "<html><head><meta http-equiv=Content-Type content=\"text/html; charset=iso-8859-1\">";
            bodyHtml += "</head><body><div><font size=\"2\" face=\"arial\">" + body;
            bodyHtml += "</font></div></body></html>";
            return bodyHtml;
        }

        private void fabricarBody(string body)
        {
            body = body.Replace("(&quot;", "('");
            body = body.Replace("&quot;)", "')");
        }

        private void suDescansito()
        {
            System.Threading.Thread.Sleep(300);
        }

        private void parametrizarMensaje(CorreoDestino correoDestino)
        {
            Parametrizador parametrizador = new Parametrizador();
            correoDestino.Mensaje.CuerpoHtml = parametrizador.Parametrizar(correoDestino.Mensaje.CuerpoHtml,
                !String.IsNullOrEmpty(correoDestino.GlosaParametrosEncadenables) ? correoDestino.GlosaParametrosEncadenables : correoDestino.ParametrosEncadenables);
            correoDestino.Mensaje.CuerpoHtml = correoDestino.Mensaje.CuerpoHtml.Replace("|", "=");
            correoDestino.Mensaje.CuerpoHtml = correoDestino.Mensaje.CuerpoHtml.Replace("#NOMBRES#", correoDestino.Destinatario.Nombre);
            correoDestino.Mensaje.CuerpoHtml = correoDestino.Mensaje.CuerpoHtml.Replace("#CORREO#", correoDestino.Destinatario.Correo);
            correoDestino.Mensaje.Titulo = parametrizador.Parametrizar(correoDestino.Mensaje.Titulo, "Encuesta Calidad de Servicio Interno");
        }

        private static void agregarArchivosAdjuntos(CorreoDestino correoDestino, MailMessage objMessage)
        {
            if (!string.IsNullOrEmpty(correoDestino.ArchivosAdjuntosEnviable))
            {
                if (correoDestino.Mensaje.ArchivosEnviables == null) correoDestino.Mensaje.ArchivosEnviables = new List<ArchivoEnviable>();
                var archivosEnCorreoDestino = correoDestino.ArchivosAdjuntosEnviable.Split('|');
                foreach (String cadaArchivoDestino in archivosEnCorreoDestino)
                    if (!correoDestino.Mensaje.ArchivosEnviables.Any(t => t.RutaFisica == cadaArchivoDestino))
                        correoDestino.Mensaje.ArchivosEnviables.Add(new ArchivoEnviable() { RutaFisica = cadaArchivoDestino });
            }

            if (correoDestino.Mensaje.ArchivosEnviables != null)
            {
                foreach (ArchivoEnviable cadaArchivoAdjunto in correoDestino.Mensaje.ArchivosEnviables)
                {
                    if (System.IO.File.Exists(cadaArchivoAdjunto.RutaFisica))
                        objMessage.Attachments.Add(new Attachment(cadaArchivoAdjunto.RutaFisica));
                    else
                        throw new ActionableException("El archivo adjunto especificado, no existe : " + cadaArchivoAdjunto.RutaFisica);
                }
            }
        }

        private static void agregarVistaAlternativaSecundaria(CorreoDestino correoDestino, MailMessage objMessage)
        {
            ContentType mimeType = new System.Net.Mime.ContentType("text/plain");
            // Construct the body as TEXT.
            string bodyPlain = HtmlStripter.StripHTML(correoDestino.Mensaje.CuerpoHtml);

            AlternateView alternatePlain = AlternateView.CreateAlternateViewFromString(bodyPlain, null, "text/plain");
            alternatePlain.TransferEncoding = System.Net.Mime.TransferEncoding.QuotedPrintable;
            objMessage.AlternateViews.Add(alternatePlain);
        }

        private static void agregarVistaAlternativaPrincipal(CorreoDestino correoDestino, MailMessage objMessage)
        {
            string bodyHtml = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>";
            bodyHtml += "<html><head><meta http-equiv=Content-Type content=\"text/html; charset=iso-8859-1\">";
            bodyHtml += "</head><body><div><font size=\"2\" face=\"arial\">" + correoDestino.Mensaje.CuerpoHtml;
            bodyHtml += "</font></div></body></html>";

            AlternateView alternateHtml = AlternateView.CreateAlternateViewFromString(bodyHtml, null, "text/html");
            alternateHtml.TransferEncoding = System.Net.Mime.TransferEncoding.QuotedPrintable;
            objMessage.AlternateViews.Add(alternateHtml);
        }

    }
}
