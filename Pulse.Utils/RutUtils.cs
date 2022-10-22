using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Utils.WebUtils.Helpers;

namespace Pulse.Utils
{
    public class RutUtils
    {
        public static readonly int LIMITE_RUT_EMPRESA = 50000000;

        public static bool EsRutPersonaNatural(string rut)
        {
            int rutEntero = TextBoxHelper.ObtenerEnteroRut(rut);
            return EsRutPersonaNatural(rutEntero);
        }

        public static bool EsRutPersonaNatural(int rut)
        {
            return rut < LIMITE_RUT_EMPRESA;
        }

        public static string DigitoVerificador(String rut)
        {
            return DigitoVerificador(Convert.ToInt32(rut));
        }


        public static string FormatearRut(Int32 rut)
        {
            string dv = DigitoVerificador(rut);
            return rut.ToString(GlobalCastings.SeparadorMiles) + "-" + dv;
        }

        public static string DigitoVerificador(Int64 rut)
        {
            double T = rut;
            double M = 0, S = 1;
            while (T != 0)
            {
                S = (S + T % 10 * (9 - M++ % 6)) % 11;
                T = Math.Floor(T / 10);
            }
            string dv = S != 0 ? (S - 1).ToString() : "K";
            return dv;
        }

        public static string DigitoVerificador(Int32 rut)
        {
            double T = rut;
            double M = 0, S = 1;
            while (T != 0)
            {
                S = (S + T % 10 * (9 - M++ % 6)) % 11;
                T = Math.Floor(T / 10);
            }
            string dv = S != 0 ? (S - 1).ToString() : "K";
            return dv;
        }
    }
}
