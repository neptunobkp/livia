using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dto;
using Pulse.Contactador.BusinessLogic.EnvioCorreo;
using Pulse.Contactador.BusinessLogic.Operaciones;
using Pulse.Utils;
using Pulse.Utils.WebUtils.Helpers;
using Pulse.Utils.Exceptions;

namespace Pulse.Contactador.BusinessLogic
{
    public class ConfiguradorCampaniaCorreoElectronico : Pulse.Contactador.BusinessLogic.IConfiguradorCampania
    {
        Dao.Implementaciones.DaoEncuestaGateway _daoEncuesta;
        public ConfiguradorCampaniaCorreoElectronico()
        {
            _daoEncuesta = new Pulse.Contactador.Dao.Implementaciones.DaoEncuestaGateway();
        }

        public void SimularConfigurarCampania(Campania campania)
        {
            validarInformacionMinima(campania);
            if (campania.Encuesta != null && campania.Encuesta.Id != 0)
                campania.ControladorEnvioCorreo.ListaCorreosDestino = new GestionadorListaCorreo().ObtenerListaCorreo(campania.ControladorEnvioCorreo.ListaCorreosDestino.Id);
            else if (campania.CarpetaEncuesta != null && campania.CarpetaEncuesta.Id != 0)
                campania.ControladorEnvioCorreo.ListaCorreosDestino = new GestionadorListaCorreo().ObtenerListasCorreosPorCarpetaEncuesta(campania.CarpetaEncuesta.Id);
            else
                campania.ControladorEnvioCorreo.ListaCorreosDestino = new GestionadorListaCorreo().ObtenerListaCorreo(campania.ControladorEnvioCorreo.ListaCorreosDestino.Id);
            campania.ControladorEnvioCorreo.MensajeCorreoUnico = new GestionadorMensajeCorreo().ObtenerMensajeCorreo(campania.ControladorEnvioCorreo.MensajeCorreoUnico.Id);
            if (campania.ControladorEnvioCorreo.ListaCorreosDestino.Origen.TipoOrigenListaCorreo == TipoOrigenListaCorreo.SentenciaSql)
            {
                GestionadorAccesador gestionadorAccesador = new GestionadorAccesador();
                campania.ControladorEnvioCorreo.ListaCorreosDestino.Origen.CadenaConexion = gestionadorAccesador.ObtenerCadenaConexion(campania.ControladorEnvioCorreo.ListaCorreosDestino.Origen.CadenaConexion.Id);
                var personasDestinatarias = gestionadorAccesador.EjecutarSentencia(campania.ControladorEnvioCorreo.ListaCorreosDestino);
                campania.ControladorEnvioCorreo.ListaCorreosDestino.CorreosDestino = new List<CorreoDestino>();
                campania.ControladorEnvioCorreo.ListaCorreosDestino.CorreosDestino.AddRange(new GestionadorListaCorreo().ConfigurarItemListaCorreoPorPersonasDestinatarias(personasDestinatarias, campania.ControladorEnvioCorreo.ListaCorreosDestino.Origen.RutCargadoConDigitoVerificador));
            }
        }

        public void ConfigurarCampania(Campania campania)
        {
            validarInformacionMinima(campania);
            if (campania.Encuesta != null && campania.Encuesta.Id != 0)
                campania.ControladorEnvioCorreo.ListaCorreosDestino = new GestionadorListaCorreo().ObtenerListaCorreo(campania.ControladorEnvioCorreo.ListaCorreosDestino.Id);
            else if (campania.CarpetaEncuesta != null && campania.CarpetaEncuesta.Id != 0)
                campania.ControladorEnvioCorreo.ListaCorreosDestino = new GestionadorListaCorreo().ObtenerListasCorreosPorCarpetaEncuesta(campania.CarpetaEncuesta.Id);
            else
                campania.ControladorEnvioCorreo.ListaCorreosDestino = new GestionadorListaCorreo().ObtenerListaCorreo(campania.ControladorEnvioCorreo.ListaCorreosDestino.Id);
            campania.ControladorEnvioCorreo.MensajeCorreoUnico = new GestionadorMensajeCorreo().ObtenerMensajeCorreo(campania.ControladorEnvioCorreo.MensajeCorreoUnico.Id);
            if (campania.ControladorEnvioCorreo.ListaCorreosDestino.Origen.TipoOrigenListaCorreo == TipoOrigenListaCorreo.SentenciaSql)
            {
                GestionadorAccesador gestionadorAccesador = new GestionadorAccesador();
                campania.ControladorEnvioCorreo.ListaCorreosDestino.Origen.CadenaConexion = gestionadorAccesador.ObtenerCadenaConexion(campania.ControladorEnvioCorreo.ListaCorreosDestino.Origen.CadenaConexion.Id);
                var personasDestinatarias = gestionadorAccesador.EjecutarSentencia(campania.ControladorEnvioCorreo.ListaCorreosDestino);
                campania.ControladorEnvioCorreo.ListaCorreosDestino.CorreosDestino = new List<CorreoDestino>();
                campania.ControladorEnvioCorreo.ListaCorreosDestino.CorreosDestino.AddRange(new GestionadorListaCorreo().ConfigurarItemListaCorreoPorPersonasDestinatarias(personasDestinatarias, campania.ControladorEnvioCorreo.ListaCorreosDestino.Origen.RutCargadoConDigitoVerificador));
                if (campania.ControladorEnvioCorreo.ListaCorreosDestino.Origen.CargarEnDemanda)
                {
                    foreach (var cadaCorreoDestino in campania.ControladorEnvioCorreo.ListaCorreosDestino.CorreosDestino)
                    {
                        cadaCorreoDestino.IdentificadorPropietario = campania.ControladorEnvioCorreo.ListaCorreosDestino.Id;
                        cadaCorreoDestino.Id = _daoEncuesta.CreateItemCorreoDestino(cadaCorreoDestino);
                    }
                }
            }
        }




        private void validarInformacionMinima(Campania campania)
        {
            if (campania == null) throw new ArgumentNullException("camapania");
            if (campania.ControladorEnvioCorreo == null) throw new ArgumentNullException("controlador de envio");
            //if (campania.ControladorEnvioCorreo.ListaCorreosDestino == null) throw new ArgumentNullException("lista correo");
        }
    }
}
