using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dto;
using Pulse.Contactador.Dao.Implementaciones;

namespace Pulse.Contactador.BusinessLogic.Operaciones
{
    public class GestionadorIngreso
    {
        DaoOperacionGateway _daoOperaciones;
        public GestionadorIngreso() { _daoOperaciones = new DaoOperacionGateway(); }

        public Usuario Autenticar(String nombreIngreso, String contrasenia)
        {
            Usuario resultadoUsuario = _daoOperaciones.FindUsuarioByNombreIngreso(nombreIngreso);
            if (resultadoUsuario == null) throw new ApplicationException("El usuario ingresado no existe en nuestros registros.");
            if (resultadoUsuario.Clave.ToUpper() != contrasenia.ToUpper()) throw new ApplicationException("La contraseña ingresada es incorrecta.");
            return resultadoUsuario;
        }
    }
}
