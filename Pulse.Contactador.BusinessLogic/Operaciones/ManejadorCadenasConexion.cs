using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dto;

namespace Pulse.Contactador.BusinessLogic.Operaciones
{
    public class ManejadorCadenasConexion
    {
        public static String ParaOracle(CadenaConexion cadenaConexion)
        {
            return String.Format("Server=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = {0})(PORT = {1}))(CONNECT_DATA =(SID = {2})));user id={3}; password={4};",
                cadenaConexion.Servidor, cadenaConexion.Puerto, cadenaConexion.IdentificadorServidor, cadenaConexion.NombreUsuario, cadenaConexion.Contrasenia);
        }

        public static String ParaSqlServer(CadenaConexion cadenaConexion)
        {
            return String.Format("Database={0};Server={1};User={2};Password={3};Integrated Security=;", cadenaConexion.BaseDatos, cadenaConexion.Servidor,
                cadenaConexion.NombreUsuario, cadenaConexion.Contrasenia);
        }

        public static String ParaDb2(CadenaConexion cadenaConexion)
        {
            return String.Format("DataSource={0};Connect Timeout=620;UserID={1};Password={2}; DataCompression=True;", cadenaConexion.Servidor,
                cadenaConexion.NombreUsuario, cadenaConexion.Contrasenia);
        }
    }
}
