using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;
using Pulse.Utils.Exceptions;

namespace Pulse.Contactador.Dao.DaoAccesoDirecto
{
    public class Db
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["contactadorDB"].ConnectionString;


        public List<Dto.PersonaDestinatario> ExcuteCommand(string sqlQuery)
        {
            List<Dto.PersonaDestinatario> destinatarios = new List<Pulse.Contactador.Dto.PersonaDestinatario>();
            try
            {
                using (OracleConnection connection = new OracleConnection())
                {
                    connection.ConnectionString = connectionString;
                    using (OracleCommand command = new OracleCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = sqlQuery;

                        connection.Open();
                        OracleDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            destinatarios.Add(new Pulse.Contactador.Dto.PersonaDestinatario()
                            {
                                RutOrigen = reader.GetString(0),
                                CorreosOrigen = reader.GetString(1),
                                IdentificadorEncuesta = reader.GetString(2),
                                GlosaParametros = reader.GetString(3)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DaoException("ha ocurrido un error al ejecutar la query", ex);
            }
            return destinatarios;
        }
    }
}
