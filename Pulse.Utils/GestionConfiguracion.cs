using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Diagnostics;
using System.Reflection;
using Pulse.Utils.Exceptions;

namespace Pulse.Utils
{
    public class GestionConfiguracion
    {
        public static string RecuperaValorParametroConfiguracion(string nombreParametro)
        {
            string valorParametro = ConfigurationManager.AppSettings.Get(nombreParametro);
            if (valorParametro == null)
            {
                string error = "Debe agregar el parámetro [" + nombreParametro + "] a su archivo de configuración";
                Logger.Write(error, "General", 0, 0, TraceEventType.Error);
                throw new PulseUtilsException(error);
            }
            return valorParametro;
        }

        public static string RecuperaCadenaConexionEnCurso(string baseDatosEnCurso)
        {
            string cadenaConexion = ConfigurationManager.ConnectionStrings[baseDatosEnCurso].ToString();
            return cadenaConexion;
        }

       
    }
}
