using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using IBM.Data.DB2.iSeries;
using System.Data;
using Pulse.Utils.Exceptions;
using Pulse.Contactador.Dto;


namespace Pulse.Contactador.Dao.DaoAccesoDirecto
{
    public class DbDb2Accesor : IDbAccesor
    {
        public String _ConeectionString { get; set; }

        public DbDb2Accesor(String connectectionString)
        {
            this._ConeectionString = connectectionString;
        }

        public void TestConection()
        {
            //try
            //{
            //    using (iDB2Connection connection = new iDB2Connection())
            //    {
            //        connection.ConnectionString = this._ConeectionString;
            //        using (iDB2Command command = new iDB2Command())
            //        {
            //            command.Connection = connection;
            //            connection.Open();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public List<Dto.PersonaDestinatario> ExcuteCommand(string sqlQuery, TiposFormaContacto tipoFormaContacto)
        {
            List<Dto.PersonaDestinatario> destinatarios = new List<Pulse.Contactador.Dto.PersonaDestinatario>();
            //try
            //{
            //    using (iDB2Connection connection = new iDB2Connection())
            //    {
            //        connection.ConnectionString = this._ConeectionString;
            //        using (iDB2Command command = new iDB2Command())
            //        {
            //            command.Connection = connection;
            //            command.CommandType = CommandType.Text;
            //            command.CommandText = sqlQuery;

            //            connection.Open();
            //            iDB2DataReader reader = command.ExecuteReader();
            //            while (reader.Read())
            //            {
            //                destinatarios.Add(ReaderPersonaDestinatarioHelper.Read(reader, tipoFormaContacto));
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new DaoException("ha ocurrido un error al ejecutar la query", ex);
            //}
            return destinatarios;
        }
    }
}
