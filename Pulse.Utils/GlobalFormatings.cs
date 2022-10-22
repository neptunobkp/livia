using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Utils
{
    public class GlobalFormatings
    {
        public static string Formatear(DateTime fecha)
        {
            return string.Format("{0}/{1}/{2}", fecha.ToString("dd"), fecha.ToString("MM"), fecha.Year);
        }

        public static string Formatear(DateTime? fecha)
        {
            if (fecha.HasValue) return Formatear(fecha.Value);
            else return string.Empty;
        }

        public static string FormatearRut(int p)
        {
            string cuerpoRut = p.ToString(GlobalCastings.SeparadorMiles);
            string dvRut = RutUtils.DigitoVerificador(p);
            return cuerpoRut + "-" + dvRut;
        }

        public static string FormatearUF(Decimal? valor)
        {
            if (!valor.HasValue) return "0";
            valor = decimal.Round(valor.Value, 2);
            return "UF " + valor.ToString();
        }
    }
}
