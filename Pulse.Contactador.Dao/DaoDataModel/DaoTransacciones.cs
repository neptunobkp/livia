using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using Pulse.Utils.Exceptions;
using Pulse.Contactador.Dao;

namespace Pulse.Contactador.Dao.DaoDataModel
{
    public class DaoTransacciones
    {
        SqlMapper _mapper;

        SqlMapper Instance()
        {
            return ((_mapper == null) ? _mapper = MapperFactory.CrearMapper() : _mapper);
        }

        /// <summary>
        /// Inicia una transaccion. Todas las interacciones con base de datos a travez de Ibatis se 
        /// mantendran en memoria hasta que se realize un Commit o RollBack.
        /// </summary>
        public void IniciarTransaccion()
        {
            if (_mapper != null)
                throw new DaoException("No se puede iniciar una transacción ya que el manejador de transacciones está en estado abierto.");

            _mapper = Instance();
            Instance().BeginTransaction();
        }

        /// <summary>
        /// Hace Commit de todas las consultas en la transaccion (las realiza en la BD).
        /// </summary>
        public void ComprometerTransaccion()
        {
            if (_mapper == null)
                throw new DaoException("Imposible hacer commit: la sesión de transacción no ha sido instanciada.");

            _mapper.CommitTransaction(true);
            _mapper = null;
        }

        /// <summary>
        /// Hace RollBack de todas las consultas en la transaccion (no las realiza en la BD).
        /// </summary>
        public void DeshacerTransaccion()
        {
            if (_mapper == null)
                throw new DaoException("Imposible hacer rollback: la sesión de transacción no ha sido instanciada.");

            try
            {
                _mapper.RollBackTransaction(true);
                _mapper = null;
            }
            catch (Exception)
            {
                _mapper = null;
                throw new DaoException("Imposible hacer rollback: la sesión de transacción no ha sido instanciada.");
            }
        }
    }
}
