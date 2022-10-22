using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;


using Pulse.Utils.Exceptions;

namespace Pulse.Utils.MailUtils
{
    public class MailHelper
    {
        public String IpSMTP { get; set; }
        public String CorreoSalida { get; set; }

        public MailHelper(string ipsmtp, string correosalida)
        {
            this.IpSMTP = ipsmtp;
            this.CorreoSalida = correosalida;
        }


        private string ConstruirMail(string cuerpoMail)
        {
            StringBuilder cuerpo = new StringBuilder();

            cuerpo.AppendLine("<HTML><BODY>");
            cuerpo.AppendLine(cuerpoMail);
            cuerpo.AppendLine("</BODY></HTML>");

            return cuerpo.ToString();
        }

        public bool EnviarMail(string direccionEmail, string cuerpoMail, string tituloMail, string casilla, Attachment atachFile)
        {

            try
            {
                String smtpClientIp = "100.1.1.6";
                MailMessage Correo = new MailMessage();
                SmtpClient smtp = new SmtpClient(smtpClientIp);
                Correo.From = new MailAddress(casilla, "BCi Seguros Vida");
                Correo.Subject = tituloMail;
                Correo.To.Add(new MailAddress(direccionEmail));
                Correo.Attachments.Add(atachFile);
                Correo.IsBodyHtml = true;
                Correo.Body = ConstruirMail(cuerpoMail);
                smtp.Send(Correo);
                return true;
            }
            catch (Exception ex)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("direccionEmail", direccionEmail);
                parameters.Add("cuertpoMail", cuerpoMail);
                parameters.Add("titulo", tituloMail);
                parameters.Add("casill", casilla);
                LoggerManager.LogError("error al enviar el email", TiposCategoryLog.LogWEB, ex, parameters);
                return false;
            }
        }

        public bool EnviarMail(String direccionEmail, String cuerpoMail, String tituloMail, String casilla, List<Attachment> atachFileCollection)
        {
            try
            {

                String smtpClientIp = "100.1.1.6";
                MailMessage Correo = new MailMessage();
                SmtpClient smtp = new SmtpClient(smtpClientIp);
                Correo.From = new MailAddress(casilla, casilla);
                Correo.Subject = tituloMail;
                Correo.To.Add(new MailAddress(direccionEmail));
                foreach (var cadaEmail in atachFileCollection)
                {
                    Correo.Attachments.Add(cadaEmail);
                }

                Correo.IsBodyHtml = true;
                Correo.Body = ConstruirMail(cuerpoMail);

                smtp.Send(Correo);
                return true;
            }
            catch (Exception ex)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("direccionEmail", direccionEmail);
                parameters.Add("cuertpoMail", cuerpoMail);
                parameters.Add("titulo", tituloMail);
                parameters.Add("casill", casilla);
                LoggerManager.LogError("error al enviar el email", TiposCategoryLog.LogWEB, ex, parameters);
                throw new ActionableException("Hay un problema al enviar el email");
            }
        }
    }
}
