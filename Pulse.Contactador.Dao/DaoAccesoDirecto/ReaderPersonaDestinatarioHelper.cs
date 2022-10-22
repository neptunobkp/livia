using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dto;
using System.Data.Common;
using System.Data;

namespace Pulse.Contactador.Dao.DaoAccesoDirecto
{
    public class ReaderPersonaDestinatarioHelper
    {
        private const int INDEX_RUT = 0;
        private const int INDEX_DATOENVIO = 1;
        private const int INDEX_IDENTIFICADOR = 2;
        private const int INDEX_PARAMETROS = 3;
        private const int INDEX_ARCHIVOSADJUNTOS = 4;

        public static PersonaDestinatario Read(IDataReader datareader, TiposFormaContacto tipoFormaContacto)
        {
            int cantidadColumnas = datareader.FieldCount;
            PersonaDestinatario result = new PersonaDestinatario();
            result.RutOrigen = getValueOrDefault(datareader, INDEX_RUT);

            if (tipoFormaContacto == TiposFormaContacto.MensajeTexto)
            {
                int celularParse = 0;
                if (!Int32.TryParse(getValueOrDefault(datareader, INDEX_DATOENVIO), out celularParse))
                    throw new InvalidCastException("El celular no es un numero válido");
                result.Celular = celularParse;
            }
            else
                result.CorreosOrigen = getValueOrDefault(datareader, INDEX_DATOENVIO);
            

            result.IdentificadorContextoOrigen = getValueOrDefault(datareader, INDEX_IDENTIFICADOR);
            if (cantidadColumnas >= 4) result.GlosaParametros = getValueOrDefault(datareader, INDEX_PARAMETROS);
            if (cantidadColumnas >= 5) result.ReferenciaArchivosAdjuntoOrigen = getValueOrDefault(datareader, INDEX_ARCHIVOSADJUNTOS);
            return result;
        }

        public static String getValueOrDefault(IDataReader datareader, int i)
        {
            if (datareader.GetValue(i) != null)
                return datareader.GetValue(i).ToString();
            else
                return string.Empty;
        }


    }
}
