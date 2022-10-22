using System;
using Pulse.Contactador.Dto;
namespace Pulse.Contactador.BusinessLogic.EnvioCorreo
{
    public interface IEmailing
    {
        void EnviarEmail(CorreoDestino correoDestino, ConfiguracionSalidaCorreo config);
    }
}

