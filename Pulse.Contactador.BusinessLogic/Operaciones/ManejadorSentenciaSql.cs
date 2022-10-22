using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Utils.Exceptions;

namespace Pulse.Contactador.BusinessLogic.Operaciones
{
    public class ManejadorSentenciaSql
    {
        public static string Configurar(String sql)
        {
            validar(sql);
            if (sql.EndsWith(";"))
                sql = sql.Substring(0, sql.Length - 1);
            return sql;
        }

        private static void validar(string sql)
        {
            bool queryTieneErrores;
            sql = sql.ToUpper();
            queryTieneErrores = !sql.Contains("SELECT");
            queryTieneErrores = !sql.Contains("FROM");
            if (queryTieneErrores) throw new InvalidOperationException("La sentencia ingresada, no tiene el formato correcto");
        }
    }
}
