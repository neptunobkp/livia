using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dao.DaoDataModel;
using Pulse.Contactador.Dto;

namespace Pulse.Contactador.BusinessLogic
{
    public class GestionarControladorEnvioCorreo
    {
        DaoCW_CONTROLADORENVIO _daoControladorEnvioCorreo;
        public GestionarControladorEnvioCorreo()
        {
            _daoControladorEnvioCorreo = new DaoCW_CONTROLADORENVIO();
        }

        public int AgregarControladorEnvioCorreo(Pulse.Contactador.Dto.ControladorEnvioCorreo controladorEnvioCorreo)
        {
            try
            {
                return _daoControladorEnvioCorreo.Create(controladorEnvioCorreo);
            }
            catch (Exception ex)
            {
                throw new Pulse.Utils.Exceptions.ActionableException("Error al crear controlador envio correo" + ex.Message, ex);
            }
        }

        public ControladorEnvioCorreo ObtenerControladorEnvioCorreoPorControladorEnvioCorreoId(int controladorEnvioCorreoId)
        {
            try
            {
                return _daoControladorEnvioCorreo.Find(controladorEnvioCorreoId);
            }
            catch (Exception ex)
            {
                throw new Pulse.Utils.Exceptions.ActionableException("Error al crear controlador envio correo" + ex.Message, ex);
            }
        }
    }
}
