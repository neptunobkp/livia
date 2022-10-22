using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Utils.WebUtils.Helpers
{
    public class NavigationHelper
    {
        public static String ConstruirParametrosGet(Dictionary<String, object> parametros)
        {
            StringBuilder get = new StringBuilder();
            foreach (var cadaParametro in parametros)
            {
                get.Append(String.Format("{0}={1}&", cadaParametro.Key, cadaParametro.Value ?? string.Empty));
            }
            return get.ToString();
        }
    }
}
