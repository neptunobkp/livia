using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Pulse.Contactador.Dto;
using Pulse.Utils.WebUtils.Helpers;

public class CSVReader
{
    private Stream objStream;
    private StreamReader objReader;
    public CSVReader() {}
    public CSVReader(Stream filestream) : this(filestream, null) {}
    public CSVReader(Stream filestream, Encoding enc)
    {
        this.objStream = filestream;
        if (!filestream.CanRead)
        {
            return;
        }
        objReader = (enc != null) ? new StreamReader(filestream, enc) : new StreamReader(filestream);
    }

    //parse the Line

    public string GetCSVLine()
    {
        string data = objReader.ReadLine();
        if (data == null) return null;
        if (data.Length == 0) return null;
        return data;
    }

    public string[] GetCSVLineArray()
    {
        string data = this.GetCSVLine();
        if (data == null) return null;
        if (data.Contains(';'))
            return string.IsNullOrEmpty(data) ? null : data.Split(';');
        else if (data.Contains(','))
            return string.IsNullOrEmpty(data) ? null : data.Split(',');
        else
            throw new InvalidOperationException("El archivo no contiene la separación adecuada, puede ser ',' o ';'.");
    }

    private void ParseCSVData(ArrayList result, string data)
    {
        int position = -1;
        while (position < data.Length)
            result.Add(ParseCSVField(ref data, ref position));
    }

    private string ParseCSVField(ref string data, ref int StartSeperatorPos)
    {
        if (StartSeperatorPos == data.Length - 1)
        {
            StartSeperatorPos++;
            return "";
        }
        int fromPos = StartSeperatorPos + 1;
        if (data[fromPos] == '"')
        {
            int nextSingleQuote = GetSingleQuote(data, fromPos + 1);
            int lines = 1;
            while (nextSingleQuote == -1)
            {
                data = data + "\n" + objReader.ReadLine();
                nextSingleQuote = GetSingleQuote(data, fromPos + 1);
                lines++;
                if (lines > 20)
                    throw new Exception("lines overflow " + data);
            }
            StartSeperatorPos = nextSingleQuote + 1;
            string tempString = data.Substring(fromPos + 1, nextSingleQuote - fromPos - 1);
            tempString = tempString.Replace("'", "''");
            return tempString.Replace("\"\"", "\"");
        }

        int nextComma = data.IndexOf(',', fromPos);
        if (nextComma == -1)
        {
            StartSeperatorPos = data.Length;
            return data.Substring(fromPos);
        }
        else
        {
            StartSeperatorPos = nextComma;
            return data.Substring(fromPos, nextComma - fromPos);
        }
    }

    private int GetSingleQuote(string data, int SFrom)
    {
        int i = SFrom - 1;
        while (++i < data.Length)
            if (data[i] == '"')
            {
                if (i < data.Length - 1 && data[i + 1] == '"')
                {
                    i++;
                    continue;
                }
                else
                    return i;
            }
        return -1;
    }

    public String[] currentData { get; set; }
    public int NumeroLinea { get; set; }
    public bool ConErrores { get; set; }

    public List<PersonaDestinatario> ExtraerPersonasDestinatarias(String cadena, TiposFormaContacto tipoFormaContacto)
    {
        List<String> lines = cadena.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
        lines = lines.Where(t => !string.IsNullOrEmpty(t)).ToList();
        List<PersonaDestinatario> resultado = new List<PersonaDestinatario>();
        foreach (String cadaLinea in lines)
        {
            this.currentData = cadaLinea.Split(';');
            try
            {
                if (tipoFormaContacto == TiposFormaContacto.MensajeTexto)
                    resultado.Add(procesarLineaMensajeTexto(currentData));
                else
                    resultado.Add(procesarLinea(this.currentData));
            }
            catch (Exception ex)
            {
                this.ConErrores = true;
                throw new ApplicationException("Ha ocurrido un error al procesar los datos.", ex);
            }
        }
        return resultado;
    }

    public List<PersonaDestinatario> ExtraerPersonasDestinatarias(TiposFormaContacto tipoformaContacto)
    {
        this.NumeroLinea = 1;
        List<PersonaDestinatario> resultado = new List<PersonaDestinatario>();
        while ((currentData = this.GetCSVLineArray()) != null)
        {
            try
            {
                if (tipoformaContacto == TiposFormaContacto.MensajeTexto)
                    resultado.Add(procesarLineaMensajeTexto(currentData));
                else
                    resultado.Add(procesarLinea(currentData));
            }
            catch (Exception ex)
            {
                this.ConErrores = true;
                throw new ApplicationException("Ha ocurrido un error al procesar los datos.", ex);
            }
        }
        return resultado;
    }

    private PersonaDestinatario procesarLineaMensajeTexto(string[] linea)
    {
        this.ValidarData(this.currentData);
        PersonaDestinatario cadaResultado = new PersonaDestinatario();
        cadaResultado.RutOrigen = this.currentData[0].Trim();
        cadaResultado.Celular = Convert.ToInt32(this.currentData[1].Trim());
        cadaResultado.IdentificadorContextoOrigen = this.currentData[2];
        if (this.currentData.Length >= 4)
            cadaResultado.GlosaParametros = this.currentData[3];
        if (this.currentData.Length >= 5)
            cadaResultado.ReferenciaArchivosAdjuntoOrigen = this.currentData[4];
        this.NumeroLinea++;
        return cadaResultado;
    }

    private PersonaDestinatario procesarLinea(string[] linea)
    {
        this.ValidarData(this.currentData);
        PersonaDestinatario cadaResultado = new PersonaDestinatario();
        cadaResultado.RutOrigen = this.currentData[0].Trim();
        cadaResultado.CorreosOrigen = this.currentData[1].Trim();
        cadaResultado.IdentificadorContextoOrigen = this.currentData[2];
        if (this.currentData.Length >= 4)
            cadaResultado.GlosaParametros = this.currentData[3];
        if (this.currentData.Length >= 5)
            cadaResultado.ReferenciaArchivosAdjuntoOrigen = this.currentData[4];
        this.NumeroLinea++;
        return cadaResultado;
    }




    public void ValidarData(String[] data)
    {
        StringBuilder builderErrores = new StringBuilder();
        if (data.Length < 3)
            throw new ApplicationException("esta línea solo contiene " + data.Length + " campos");

        if (!data[0].ToString().Contains('-'))
            builderErrores.Append("falta dv,");

        //if (!IsAlpha(data[1])) builderErrores.Append("nombre inválido,");
        //if (!IsAlpha(data[2])) builderErrores.Append("apellido paterno inválido,");
        //if (!IsAlpha(data[3])) builderErrores.Append("apellido materno inválido,");
        //if (!IsNumber(data[4])) builderErrores.Append("fecha nacimiento inválida,");
        //if (data[4].ToString().Length != 8) builderErrores.Append("largo fecha invalido");
        //if (data[5] != "M" && data[5] != "F") builderErrores.Append("sexo inválido,");

        //if (builderErrores.ToString().Length > 1)
        //    throw new ApplicationException(builderErrores.ToString());
    }

    public void ValidarArchivoPosteado(FileUpload fileUploadArchivoEntrada)
    {
        if (!fileUploadArchivoEntrada.HasFile)
            throw new ApplicationException("Debe adjuntar el archivo de carga");
        if (fileUploadArchivoEntrada.PostedFile.ContentLength == 0)
            throw new ApplicationException("El archivo debe contener al menos 1 registro, para poder realizar la carga");
        if (fileUploadArchivoEntrada.FileName.Split('.').Last().ToUpper() != "CSV")
            throw new ApplicationException("El archivo no tiene la extensión solicitada, este debe ser 'csv'");
    }

    public bool IsNumber(string strNumber)
    {
        Regex objNotNumberPattern = new Regex("[^0-9.-]");
        Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
        Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
        String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
        String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
        Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");
        return !objNotNumberPattern.IsMatch(strNumber) &&
         !objTwoDotPattern.IsMatch(strNumber) &&
         !objTwoMinusPattern.IsMatch(strNumber) &&
         objNumberPattern.IsMatch(strNumber);
    }

    // Function To test for Alphabets.

    public bool IsAlpha(string strToCheck)
    {
        Regex objAlphaPattern = new Regex("[^a-zA-Z]");

        return !objAlphaPattern.IsMatch(strToCheck);
    }

    // Function to Check for AlphaNumeric.

    public bool IsAlphaNumeric(string strToCheck)
    {
        Regex objAlphaNumericPattern = new Regex("[^a-zA-Z0-9]");

        return !objAlphaNumericPattern.IsMatch(strToCheck);
    }

}
