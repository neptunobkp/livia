using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Utils.Exceptions;

namespace Pulse.Utils.WebUtils.Helpers
{
    public class TextBoxHelper
    {

        public static int? ObtenerEnteroNulable(string text)
        {
            text = ObtenerEnteroAplicable(text);
            int enteroParaValidarCast = 0;
            if (string.IsNullOrEmpty(text)) return null;
            if (!Int32.TryParse(text, out enteroParaValidarCast)) return null;
            else return enteroParaValidarCast;
        }

        public static int ObtenerEnteroRut(string textRut)
        {
            try
            {
                if (string.IsNullOrEmpty(textRut)) return 0;
                textRut = textRut.Replace(".", "");
                if (textRut.Contains('-'))
                    textRut = textRut.Split('-').ToList().First();
                else
                    textRut = textRut.Substring(0, textRut.ToString().Length - 1);
                return ObtenerEnteroNulable(textRut).HasValue ? ObtenerEnteroNulable(textRut).Value : 0;
            }
            catch (Exception ex)
            {
                Dictionary<String, Object> parameters = new Dictionary<string, object>();
                parameters.Add("textrut", textRut);
                LoggerManager.LogError("Error al obtener el entero rut", TiposCategoryLog.LogWEB, ex, parameters);
                return 0;
            }
        }

        public static string ObtenerEnteroAplicable(string p)
        {
            if (string.IsNullOrEmpty(p))
                return "";

            StringBuilder resultado = new StringBuilder();
            foreach (Char cadaChar in p.ToCharArray())
            {
                if (Char.IsNumber(cadaChar))
                    resultado.Append(cadaChar);
            }
            return resultado.ToString();
        }

        public static string AMayuscula(string texto)
        {
            return string.IsNullOrEmpty(texto) ? string.Empty : texto.ToUpper();
        }
    }
}
