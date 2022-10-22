using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ManejadorDirectorios
/// </summary>
public class ManejadorDirectorios
{
    public static String PathBandejaEstilos(string raiz)
    {
        return String.Format(@"{0}\App_Themes\PulseTheme\css\styles\", raiz);
    }
}
