using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dto;
using Pulse.Contactador.Dto.Agendable;
using Pulse.Contactador.BusinessLogic.EnvioCorreo;
using Pulse.Contactador.BusinessLogic.Recursos;
using Pulse.Contactador.BusinessLogic.EnvioSms;

namespace Pulse.Contactador.BusinessLogic
{
    public class GestionadorEjecucionPlanCampania
    {
        Dao.Implementaciones.DaoEncuestaGateway _daoEncuesta = new Pulse.Contactador.Dao.Implementaciones.DaoEncuestaGateway();
        public String RutaContenedorArchivosAdjuntos { get; set; }
        public GestionadorEjecucionPlanCampania()
        {
            _daoEncuesta = new Pulse.Contactador.Dao.Implementaciones.DaoEncuestaGateway();
        }

        public IConfiguradorCampania ConfiguradorCampania { get; set; }

        public ConfiguracionSalidaCorreo conf()
        {
            return new ConfiguracionSalidaCorreo()
            {
                CorreoCasillaSalida = Pulse.Utils.GestionConfiguracion.RecuperaValorParametroConfiguracion("casilla"),
                ServidorSmtp = Pulse.Utils.GestionConfiguracion.RecuperaValorParametroConfiguracion("smtpserver"),
                NombreCasillaSalda = Pulse.Utils.GestionConfiguracion.RecuperaValorParametroConfiguracion("nombresalida")
            };
            //return new ConfiguracionSalidaCorreo()
            //{
            //    CorreoCasillaSalida = "infozenit@zenitseguros.cl",
            //    ServidorSmtp = "100.1.2.218",
            //    NombreCasillaSalda = "Zenit Seguros"
            //};
            //return new ConfiguracionSalidaCorreo()
            //{
            //    CorreoCasillaSalida = "contacto@bciseguros.cl",
            //    ServidorSmtp = "100.1.1.6",
            //    NombreCasillaSalda = "Nombre Casilla Ejemplo"
            //};
        }

        public void SimularEnvio(Campania campania)
        {
            new ConfiguradorCampaniaCorreoElectronico().SimularConfigurarCampania(campania);
        }

        private void InstanciarConfiguradorCampania(Campania campania)
        {
            if (campania.TipoFormaContacto == TiposFormaContacto.MensajeTexto)
                this.ConfiguradorCampania = new ConfiguradorCampaniaMensajeTexto();
            else
                this.ConfiguradorCampania = new ConfiguradorCampaniaCorreoElectronico();
        }

        public void EjecutarCampania(Campania campania)
        {
            this.InstanciarConfiguradorCampania(campania);
            this.ConfiguradorCampania.ConfigurarCampania(campania);
            new EnvioCorreo.ConfiguradorArchivosAdjuntos().ConfigurarArchivosAdjuntosCampania(campania, this.RutaContenedorArchivosAdjuntos);
            EnvioCorreo.ControladorSuperiorEnvio controladorEnvio = new Pulse.Contactador.BusinessLogic.EnvioCorreo.ControladorSuperiorEnvio();
            foreach (CorreoDestino cadaCorreoDestino in campania.ControladorEnvioCorreo.ListaCorreosDestino.CorreosDestino)
            {
                try
                {
                    configurarCorreoDestinoPorEncuesta(campania);
                    new ConfiguradorMensajeCorreo().ConfigurarMensaje(cadaCorreoDestino, campania.ControladorEnvioCorreo.MensajeCorreoUnico, campania.ControladorEnvioCorreo.TipoEnvioCorreo);
                    configurarLinkEncuesta(campania, cadaCorreoDestino);
                    if (campania.ControladorEnvioCorreo.ListaCorreosDestino.TipoFormaContacto == TiposFormaContacto.MensajeTexto)
                    {
                        cadaCorreoDestino.Mensaje.CuerpoHtml = new Parametrizador().Parametrizar(cadaCorreoDestino.Mensaje.CuerpoHtml,
                            !String.IsNullOrEmpty(cadaCorreoDestino.GlosaParametrosEncadenables) ? cadaCorreoDestino.GlosaParametrosEncadenables : cadaCorreoDestino.ParametrosEncadenables);
                        new ControladorSuperiorEnvioSms().EnviarSms(cadaCorreoDestino.Destinatario.Celular, cadaCorreoDestino.Mensaje.CuerpoHtml);
                    }
                    else
                        controladorEnvio.EnviarEmail(cadaCorreoDestino, this.conf());
                    cadaCorreoDestino.TipoEstadoEnvio = TiposEstadoEnvio.Enviado;
                    cadaCorreoDestino.FechaEnvio = DateTime.Now;
                    cadaCorreoDestino.Anotacion = "Enviado exitosamente!";
                }
                catch (Exception ex)
                {
                    cadaCorreoDestino.Anotacion = ex.Message;
                    cadaCorreoDestino.TipoEstadoEnvio = TiposEstadoEnvio.Fallido;
                }
                finally
                {
                    _daoEncuesta.UpdateCorreoDestino(cadaCorreoDestino);
                }
            }
        }

        private void configurarLinkEncuesta(Campania campania, CorreoDestino cadaCorreoDestino)
        {
            if (campania.CarpetaEncuesta != null && campania.CarpetaEncuesta.Id != 0)
                if (cadaCorreoDestino.Mensaje.CuerpoHtml.Contains("#LINK#"))
                    cadaCorreoDestino.Mensaje.CuerpoHtml = cadaCorreoDestino.Mensaje.CuerpoHtml.Replace("#LINK#", configurarLinkCarpetaEncuesta(cadaCorreoDestino.Id, campania.CarpetaEncuesta.Id, campania.Id));

            if (campania.Encuesta != null && campania.Encuesta.Id != 0)
                if (cadaCorreoDestino.Mensaje.CuerpoHtml.Contains("#LINK#"))
                    cadaCorreoDestino.Mensaje.CuerpoHtml = cadaCorreoDestino.Mensaje.CuerpoHtml.Replace("#LINK#", configurarLink(cadaCorreoDestino.Id, campania.Encuesta.Id, campania.Id));
        }

        private string configurarLinkCarpetaEncuesta(int correoDestinoId, int carpetaEncuestaId, int campaniaId)
        {
            String urlPublica = System.Configuration.ConfigurationManager.AppSettings["urlPublica"];
            return String.Format("{0}Web/Encuesta/ResponderCarpeta.aspx?{1}={2}&{3}={4}&{5}={6}",
                urlPublica,
                RecursoParametros.GetCarpetaId, carpetaEncuestaId.ToString(),
                RecursoParametros.GetItemCorreoDestinoId, correoDestinoId.ToString(),
                RecursoParametros.GetCampaniaId, campaniaId.ToString());
        }

        private string configurarLink(int corredoDestinoId, int encuestaID, int campaniaId)
        {
            String urlPublica = System.Configuration.ConfigurationManager.AppSettings["urlPublica"];
            return String.Format("{0}Web/Encuesta/Responder.aspx?{1}={2}&{3}={4}&{5}={6}",
                urlPublica,
                RecursoParametros.GetEncuestaId, encuestaID.ToString(),
                RecursoParametros.GetItemCorreoDestinoId, corredoDestinoId.ToString(),
                RecursoParametros.GetCampaniaId, campaniaId.ToString());
        }

        private void configurarCorreoDestinoPorEncuesta(Campania campania)
        {
            if (campania.Encuesta == null) return;

        }
    }
}
