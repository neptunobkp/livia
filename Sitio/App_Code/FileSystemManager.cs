using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

/// <summary>
/// Summary description for FileSystemManager
/// </summary>
public class FileSystemManager
{
    public FileSystemManager()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static void CrearArchivo(string pathFile, StringBuilder inputBuilder, string fileName)
    {
        using (StreamWriter outfile = new StreamWriter(pathFile + @"\" + fileName))
        {
            outfile.Write(inputBuilder.ToString());
        }
    }
}
