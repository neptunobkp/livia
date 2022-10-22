using System;
namespace Pulse.Contactador.BusinessLogic
{
    public interface IConfiguradorCampania
    {
        void ConfigurarCampania(Pulse.Contactador.Dto.Campania campania);
        void SimularConfigurarCampania(Pulse.Contactador.Dto.Campania campania);
    }
}
