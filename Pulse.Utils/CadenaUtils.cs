using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Utils
{
    public class CadenaUtils
    {
        public enum TipoCompletitudCadena
        {
            Indefinido,
            CompletarADerecha,
            CompletarAIzqquierda,
        }



        public static String CompletarCadenaPorLargoYValor(String cadena, Char valorCompletar, int largo, TipoCompletitudCadena tipoComletitud)
        {
            if (tipoComletitud == TipoCompletitudCadena.CompletarADerecha)
                return cadena.PadRight(largo, valorCompletar);
            else if (tipoComletitud == TipoCompletitudCadena.CompletarAIzqquierda)
                return cadena.PadLeft(largo, valorCompletar);
            else
                throw new InvalidOperationException("Debe definir el tipo de completitud");
        }

        public static String CompletarCadenaPorLargoYValor(int cadena, Char valorCompletar, int largo, TipoCompletitudCadena tipoComletitud)
        {
            return CompletarCadenaPorLargoYValor(cadena.ToString(), valorCompletar, largo, tipoComletitud);
        }

        public static String CompletarNombreArchivoFechaHora(String nombreArchivo)
        {
            return String.Format("{0}{1}{2}{3}{4}{5}{6}", nombreArchivo, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Millisecond);
        }

        public static string LimpiarCaracteresHtml(String html)
        {
            html = html.Replace("strong", "b");
            html = html.Replace("&nbsp;", " ");
            html = html.Replace("&aacute;", "á");
            html = html.Replace("&eacute;", "é");
            html = html.Replace("&iacute;", "í");
            html = html.Replace("&oacute;", "ó");
            html = html.Replace("&uacute;", "ú");
            html = html.Replace("&ntilde;", "ñ");
            html = html.Replace("&Aacute;", "Á");
            html = html.Replace("&Eacute;", "É");
            html = html.Replace("&Iacute;", "Í");
            html = html.Replace("&Oacute;", "Ó");
            html = html.Replace("&Uacute;", "Ú");
            html = html.Replace("&Ntilde;", "Ñ");
            html = html.Replace("&quot;", "\"");
            html = html.Replace("&lt;", "<");
            html = html.Replace("&gt;", ">");
            html = html.Replace("&amp;", "&");
            html = html.Replace("&#39;", "'");
            html = html.Replace("&iquest;", "¿");
            html = html.Replace("&iexcl;", "¡");
            html = html.Replace("&uuml;", "ü");
            html = html.Replace("&rdquo;", "”");
            html = html.Replace("&ldquo;", "“");
            html = html.Replace("&acute;", "´");
            html = html.Replace("&emsp;", " ");
            return html;
        }

        public static String LimpiarCerosInicio(string cadena)
        {
            return cadena.TrimStart(new char[]{'0'});
        }
    }
}
