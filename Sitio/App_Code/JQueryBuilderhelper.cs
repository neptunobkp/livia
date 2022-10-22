using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;


public class JQueryBuilderHelper
{
    public static string windowopener(string url)
    {
        string scriptOpener;
        scriptOpener = "<script language='javascript' type='text/jscript'>";
        scriptOpener += "window.open('" + url + "');";
        scriptOpener += "</script>";
        return scriptOpener;
    }

    public static string windowopener(string[] urls)
    {
        string scriptOpener;
        scriptOpener = "<script language='javascript' type='text/jscript'>";
        foreach (string url in urls)
            scriptOpener += "window.open('" + url + "');";
        scriptOpener += "</script>";
        return scriptOpener;
    }

    public static string getjQueryCode(string jsCodetoRun)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("$(document).ready(function() {");
        sb.AppendLine(jsCodetoRun);
        sb.AppendLine(" });");
        return sb.ToString();
    }

    public static string configureMessageDialog(string mensaje)
    {
        string codeToRun = " $('#ctl00_ContentCotizarBody_panelmensaje').html('" + cleanHtmlParaMensaje(mensaje) + "').dialog('open');";
        return codeToRun;
    }

    private static string configureMessageDialog(string mensaje, string divcontainer)
    {
        string codeToRun = " $('#" + divcontainer + "').html('" + cleanHtmlParaMensaje(mensaje) + "').dialog('open');";
        return codeToRun;
    }

    private static string cleanHtmlParaMensaje(string mensaje)
    {
        mensaje = HttpUtility.HtmlEncode(mensaje);
        mensaje = mensaje.Replace("'", "");
        Regex regexBR = new Regex(@"\r");
        mensaje = regexBR.Replace(mensaje, "<br />");
        Regex regex = new Regex(@"(\r\n|\r|\n)+");
        mensaje = regex.Replace(mensaje, "<br />");
        return mensaje;
    }

    public static string jquerydialog(string mensaje)
    {
        string lineDialog = configureMessageDialog(mensaje);
        return getjQueryCode(lineDialog);
    }

    public static string jquerydialog(string mensaje, string div_id_panelmensaje)
    {
        string lineDialog = configureMessageDialog(mensaje, div_id_panelmensaje);
        return getjQueryCode(lineDialog);
    }
}
