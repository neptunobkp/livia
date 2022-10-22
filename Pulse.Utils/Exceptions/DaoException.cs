using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Utils.Exceptions
{
    public class DaoException : ActionableException
    {
        /// <summary>
        /// Crea una nueva BciDaoException. Se utiliza para manejar errores en la capa Dao
        /// </summary>
        /// <param name="mensaje">El mensaje de la exception</param>
        public DaoException(string mensaje)
            : base(mensaje)
        {
            LoggerManager.LogError(mensaje, TiposCategoryLog.LogDAO, null);
        }

        /// <summary>
        /// Crea una nueva BciDaoException. Se utiliza para manejar errores en la capa Dao
        /// </summary>
        /// <param name="mensaje">El mensaje de la exception</param>
        /// <param name="interna">Una exception para agragar como innerException</param>
        public DaoException(string mensaje, Exception interna)
            : base(mensaje, interna)
        {
            LoggerManager.LogError(mensaje, TiposCategoryLog.LogDAO, interna);
        }

        public DaoException(string source, string mensaje, Exception interna)
            : base(source, mensaje, interna)
        {
            StringBuilder mensajeBuilder = new StringBuilder(DateTime.Now.ToString());
            mensajeBuilder.AppendLine("source:" + source);
            mensajeBuilder.AppendLine("mensaje:" + mensaje);
            LoggerManager.LogError(mensajeBuilder.ToString(), TiposCategoryLog.LogDAO, interna);
        }

        public DaoException(string source, string mensaje, Exception interna, Dictionary<string, object> parametros)
            : base(source, mensaje, interna)
        {
            StringBuilder mensajeBuilder = new StringBuilder(DateTime.Now.ToString());
            mensajeBuilder.AppendLine("source:" + source);
            mensajeBuilder.AppendLine("mensaje:" + mensaje);
            LoggerManager.LogError(mensajeBuilder.ToString(), TiposCategoryLog.LogDAO, interna, parametros);
        }
    }
}
