using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Utils
{
    public class GlobalCastings
    {
        public static readonly string SeparadorMiles = "#,##0";

        public static decimal? ToDecimal(string input)
        {
            decimal dummyDecimal = 10.123m;
            char separadorDecimalesInferido = dummyDecimal.ToString().Contains('.') ? '.' : ',';

            if (string.IsNullOrEmpty(input)) return null;
            if (input.Contains('.') && input.Contains(','))
                throw new InvalidCastException(string.Format("El dato {0} no puede ser convertido a decimal, ya que presenta '.' y ','", input));
            input = input.Replace('.', separadorDecimalesInferido);
            input = input.Replace(',', separadorDecimalesInferido);

            decimal retorno = 0;
            if (decimal.TryParse(input, out retorno))
                return retorno;
            else
                return null;
        }

       

        public static DateTime? ToNullDateTime(string texto)
        {
            if (texto.Contains("/"))
                return ToNullDateTime(texto, '/');
            else if (texto.Contains("-"))
                return ToNullDateTime(texto, '-');
            else
                return null;
        }

        public static DateTime? ToNullDateTime(string texto, Char spliter)
        {
            int dia = 0; int mes = 0; int anio = 0;
            string[] valoresFecha = texto.Split(spliter);
            if (valoresFecha.Count() == 3)
            {
                dia = Convert.ToInt32(valoresFecha.First());
                mes = Convert.ToInt32(valoresFecha[1]);
                anio = Convert.ToInt32(valoresFecha.Last());
                return new DateTime(anio, mes, dia);
            }
            else
            {
                return null;
            }
        }


        public static DateTime? ToNullDateTimeFromNumber(string texto)
        {
            try
            {
                string anio = texto.Substring(0, 4);
                string mes = texto.Substring(4, 2);
                string dia = texto.Substring(6, 2);
                return new DateTime(
                    Convert.ToInt32(anio),
                    Convert.ToInt32(mes),
                    Convert.ToInt32(dia));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
