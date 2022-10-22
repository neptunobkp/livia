using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dto;

namespace Pulse.Contactador.BusinessLogic.EnvioCorreo
{
    public class GestionadorMensajeCorreo
    {
        Dao.Implementaciones.DaoEncuestaGateway _daoEncuesta;

        public GestionadorMensajeCorreo()
        {
            _daoEncuesta = new Pulse.Contactador.Dao.Implementaciones.DaoEncuestaGateway();
        }
        public List<ConfiguracionSalidaCorreo> ObtenerConfiguracionesSalida()
        {
            return _daoEncuesta.FindConfiguracionesSalidaCorreo();
        }

        public int AgregarMensajeCorreo(MensajeCorreoDestino mensajeCorreoDestino)
        {
            return _daoEncuesta.CreateMensajeCorreo(mensajeCorreoDestino);
        }


        public object ObtenerMensajesCorreo()
        {
            return _daoEncuesta.FindAllMensajesCorreoDestino();
        }

        public MensajeCorreoDestino ObtenerMensajeCorreo(int mensajeId)
        {
            return _daoEncuesta.FindMensajeCorreoDestino(mensajeId);
        }
    }
}
