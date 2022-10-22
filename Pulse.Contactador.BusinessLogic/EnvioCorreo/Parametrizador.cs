using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.BusinessLogic.EnvioCorreo
{
    public class Parametrizador
    {
        public String Parametrizar(String origen, String parametrosGet)
        {
            return parametrizarTexto(origen, parametrosGet);
        }

        private string parametrizarTexto(string origen, string parametrosGet)
        {
            string remplazosMail = origen;
            if (!string.IsNullOrEmpty(parametrosGet))
                remplazosMail = RemplazarParametrosConfigurados(configurarParametros(parametrosGet), remplazosMail);
            return remplazosMail;
        }

        private string RemplazarParametrosConfigurados(Dictionary<string, string> dictionary, string remplazoCuerpo)
        {
            foreach (var cadaParametro in dictionary)
            {
                if (!string.IsNullOrEmpty(cadaParametro.Key))
                    remplazoCuerpo = remplazoCuerpo.Replace("#" + cadaParametro.Key.ToUpper() + "#", cadaParametro.Value);
            }
            return remplazoCuerpo;
        }

        private Dictionary<string, string> configurarParametros(string parametrosGet)
        {
            parametrosGet = parametrosGet.Replace("[P]", "&");
            parametrosGet = parametrosGet.Replace("[p]", "&");
            Dictionary<string, string> parametrosConfigurados = new Dictionary<string, string>();
            List<string> parametros = parametrosGet.Split('&').ToList();
            foreach (string cadaParametro in parametros)
                if (cadaParametro.Contains("="))
                    parametrosConfigurados.Add(cadaParametro.Split('=').First(), cadaParametro.Split('=').Last());

            return parametrosConfigurados;
        }

        private bool esParametroConfigurable(string param)
        {
            bool esValido = true;
            if (!param.Contains("#") || !param.Contains("#"))
                esValido = false;
            return esValido;
        }
    }
}
