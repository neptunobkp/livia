using System;
using Pulse.Contactador.Dto;
namespace Pulse.Contactador.Dao.DaoAccesoDirecto
{
    public interface IDbAccesor
    {
        string _ConeectionString { get; set; }
        System.Collections.Generic.List<Pulse.Contactador.Dto.PersonaDestinatario> ExcuteCommand(string sqlQuery, TiposFormaContacto tipoFormaContacto);
        void TestConection();
    }
}
