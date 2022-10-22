using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Pulse.Utils.Exceptions;


namespace Pulse.Contactador.BusinessLogic.EnvioSms
{
    public class ControladorSuperiorEnvioSms
    {
        public void EnviarSms(int celular, string mensaje)
        {
            if (string.IsNullOrEmpty(celular.ToString()) || celular.ToString().Length != 8)
            {
                throw new ApplicationException("El número de celular debe contener 8 dígitos.");
            }
            if (string.IsNullOrEmpty(mensaje) || mensaje.Length > 160)
            {
                throw new ApplicationException("El Largo máximo permitido para le mensaje es de 160 caracteres.");
            }

            try
            {
                //ConsumirUrlTiaxa(celular.ToString(), mensaje);
            }
            catch (Exception ex)
            {
                LoggerManager.LogError("Ha ocurrido un error al consumir el servicio de tiaxa", TiposCategoryLog.LogBL, ex);
                throw ex;
            }
        }

        public void ConsumirUrlTiaxa(string celular, string textoMensaje)
        {

            string url = Pulse.Utils.GestionConfiguracion.RecuperaValorParametroConfiguracion("UrlTiaxa");
            string sURL = url + "?PHONE=" + celular + "&TEXT=" + textoMensaje;

            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);
            wrGETURL.Proxy = WebProxy.GetDefaultProxy();

            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);

            string sLine = "";

            string resultado = "";
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    resultado += " " + sLine;
            }
            if (!resultado.Contains("OK"))
                throw new ApplicationException("Ha ocurrido un problema al enviar el SMS: " + resultado); 

        }
    }
}
