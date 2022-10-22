using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dto;

namespace Pulse.Contactador.BusinessLogic
{
    public class GestionadorCreacionCampania
    {
        Dao.Implementaciones.DaoEncuestaGateway _daoEncuesta;



        public GestionadorCreacionCampania()
        {
            _daoEncuesta = new Pulse.Contactador.Dao.Implementaciones.DaoEncuestaGateway();

        }

        public List<Encuesta> ObtenerEncuestas()
        {
            return new GestionadorEncuesta().ObtenerTodasLasEncuestas();
        }

        public List<MensajeCorreoDestino> ObtenerMensajes()
        {
            return _daoEncuesta.FindAllMensajesCorreoDestino();
        }

        public List<ListaCorreoDestino> ObtenerListasCorreosDestinos()
        {
            return _daoEncuesta.FindAllListaCorreo();
        }

        public void AgregarCampania(Campania campania)
        {
            campania.Id = _daoEncuesta.CreateCampania(campania);
        }
    }
}
