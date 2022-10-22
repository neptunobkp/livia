using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using Pulse.Utils.Exceptions;
using Pulse.Contactador.Dto;

namespace Pulse.Contactador.Dao.DaoAccesoDirecto
{
    public class DbOracleAccesor : Pulse.Contactador.Dao.DaoAccesoDirecto.IDbAccesor
    {
        public String _ConeectionString { get; set; }

        public DbOracleAccesor(String connectectionString)
        {
            this._ConeectionString = connectectionString;
        }

        public void TestConection()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection())
                {
                    connection.ConnectionString = this._ConeectionString;
                    using (OracleCommand command = new OracleCommand())
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
                using (OracleConnection connection = new OracleConnection())
                {
                    connection.ConnectionString = this._ConeectionString;
                    using (OracleCommand command = new OracleCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = sqlQuery;

                        connection.Open();
                        OracleDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            try
                            {
                                destinatarios.Add(ReaderPersonaDestinatarioHelper.Read(reader, tipoFormaContacto));
                            }
                            catch (InvalidCastException ex)
                            {
                                LoggerManager.LogError(ex.Message, TiposCategoryLog.LogDAO, ex);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DaoException("Ups, lo sentimos pero ha ocurrido un problema al ejecutar la sentencia ingresada, este mensaje puede servir de ayuda! => " + ex.Message, ex);
            }
            return destinatarios;
        }
    }
}
