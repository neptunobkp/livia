using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

/// <summary>
/// Summary description for ManejadorArchivos
/// </summary>
public class ManejadorArchivos
{
    public ManejadorArchivos()
    {
    }

    public static void CrearArchivo(String ruta, String contenido)
    {
        using (StreamWriter writer = new StreamWriter(ruta))
        {
            writer.Write(contenido);
        }
    }
}
