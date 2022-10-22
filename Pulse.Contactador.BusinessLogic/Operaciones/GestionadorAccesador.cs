using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dao.DaoAccesoDirecto;
using Pulse.Contactador.Dto;

namespace Pulse.Contactador.BusinessLogic.Operaciones
{
    public class GestionadorAccesador
    {
        public IDbAccesor _dbAccesor { get; set; }

        public List<CadenaConexion> ObtenerCadenasConexion()
        {
            return new Dao.Implementaciones.DaoOperacionGateway().FindAllCadenasConexion().ToList();
        }

        public CadenaConexion ObtenerCadenaConexion(int cadenaConexionId)
        {
            return new Dao.Implementaciones.DaoOperacionGateway().FindCadenaConexion(cadenaConexionId);
        }

        public void GuardarCadenaConexion(CadenaConexion cadenaCodenexion)
        {
            configurarAccesorYCadenaConexion(cadenaCodenexion);
            new Dao.Implementaciones.DaoOperacionGateway().AgregarCadenaConexion(cadenaCodenexion);
        }

        public void ProbarConexion(CadenaConexion cadenaCodenexion)
        {
            configurarAccesorYCadenaConexion(cadenaCodenexion);
            _dbAccesor.TestConection();
        }

        //public List<PersonaDestinatario> EjecutarSentencia(CadenaConexion cadenaConexion, String sentenciaSql)
        //{
        //    configurarAccesorYCadenaConexion(cadenaConexion);
        //    sentenciaSql = ManejadorSentenciaSql.Configurar(sentenciaSql);
        //    return _dbAccesor.ExcuteCommand(sentenciaSql);
        //}

        public List<PersonaDestinatario> EjecutarSentencia(ListaCorreoDestino listaCorreoDestino)
        {
            configurarAccesorYCadenaConexion(listaCorreoDestino.Origen.CadenaConexion);
            listaCorreoDestino.Origen.SentenciaSql = ManejadorSentenciaSql.Configurar(listaCorreoDestino.Origen.SentenciaSql);
            return _dbAccesor.ExcuteCommand(listaCorreoDestino.Origen.SentenciaSql, listaCorreoDestino.TipoFormaContacto);
        }


        private void configurarAccesorYCadenaConexion(CadenaConexion cadenaCodenexion)
        {
            switch (cadenaCodenexion.TipoMotorBaseDatos)
            {
                case TiposMotorBaseDatos.SqlServer:
                    cadenaCodenexion.CadenaConfigurada = ManejadorCadenasConexion.ParaSqlServer(cadenaCodenexion);
                    _dbAccesor = new DbSqlServerAccesor(cadenaCodenexion.CadenaConfigurada);
                    break;
                case TiposMotorBaseDatos.Oracle:
                    cadenaCodenexion.CadenaConfigurada = ManejadorCadenasConexion.ParaOracle(cadenaCodenexion);
                    _dbAccesor = new DbOracleAccesor(cadenaCodenexion.CadenaConfigurada);
                    break;
                case TiposMotorBaseDatos.Db2:
                    cadenaCodenexion.CadenaConfigurada = ManejadorCadenasConexion.ParaDb2(cadenaCodenexion);
                    _dbAccesor = new DbDb2Accesor(cadenaCodenexion.CadenaConfigurada);
                    break;
                default:
                    break;
            }
        }




    }
}
