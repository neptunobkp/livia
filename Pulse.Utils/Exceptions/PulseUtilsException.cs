using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Utils.Exceptions
{
    public class PulseUtilsException : ActionableException
    {
        /// <summary>
        /// Crea una nueva PulseUtilsException. Se utiliza para manejar errores en la capa Dao
        /// </summary>
        /// <param name="mensaje">El mensaje de la exception</param>
        public PulseUtilsException(string mensaje)
            : base(mensaje)
        {
        }

        /// <summary>
        /// Crea una nueva PulseUtilsException. Se utiliza para manejar errores en la capa Dao
        /// </summary>
        /// <param name="mensaje">El mensaje de la exception</param>
        /// <param name="interna">Una exception para agragar como innerException</param>
        public PulseUtilsException(string mensaje, Exception interna)
            : base(mensaje, interna)
        {
        }

        public PulseUtilsException(string source, string mensaje, Exception interna)
            : base(source, mensaje, interna)
        {
        }
    }
}
