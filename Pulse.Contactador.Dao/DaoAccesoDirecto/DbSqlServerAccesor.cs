using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Pulse.Utils.Exceptions;
using Pulse.Contactador.Dto;

namespace Pulse.Contactador.Dao.DaoAccesoDirecto
{
    public class DbSqlServerAccesor : IDbAccesor
    {
        public String _ConeectionString { get; set; }

        public DbSqlServerAccesor(String connectectionString)
        {
            this._ConeectionString = connectectionString;
        }

        public void TestConection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = this._ConeectionString;
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        connection.Open();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Dto.PersonaDestinatario> ExcuteCommand(string sqlQuery, TiposFormaContacto tipoFormaContacto)
        {
            List<Dto.PersonaDestinatario> destinatarios = new List<Pulse.Contactador.Dto.PersonaDestinatario>();
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = this._ConeectionString;
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = sqlQuery;

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            destinatarios.Add(ReaderPersonaDestinatarioHelper.Read(reader, tipoFormaContacto));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DaoException("Ocurrio un problema al ejecutar la sentencia: " + ex.Message);
            }
            return destinatarios;
        }
    }
}
