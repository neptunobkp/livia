using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dto;
using Pulse.Utils;
using Pulse.Utils.WebUtils.Helpers;

namespace Pulse.Contactador.BusinessLogic
{
    public class GestionadorListaCorreo
    {
        Dao.Implementaciones.DaoEncuestaGateway _daoEncuesta;

        public GestionadorListaCorreo()
        {
            _daoEncuesta = new Pulse.Contactador.Dao.Implementaciones.DaoEncuestaGateway();
        }

        public List<PersonaDestinatario> ObtenerPersonasDestinatarioPorQuery(String query)
        {
            Dao.DaoAccesoDirecto.Db dbdirecto = new Dao.DaoAccesoDirecto.Db();
            return dbdirecto.ExcuteCommand(query);
        }

        public void AgregarListaCorreo(ListaCorreoDestino listaCorreoDestino)
        {
            listaCorreoDestino.Id = _daoEncuesta.CreateListaCorreo(listaCorreoDestino);
            foreach (CorreoDestino cadaCorreoDestino in listaCorreoDestino.CorreosDestino)
            {
                cadaCorreoDestino.IdentificadorPropietario = listaCorreoDestino.Id;
                _daoEncuesta.CreateItemCorreoDestino(cadaCorreoDestino);
            }
        }

        public void ActualizaListaCorreo(ListaCorreoDestino listaCorreoDestino)
        {
            _daoEncuesta.UpdateListaCorreo(listaCorreoDestino);
        }

        public object ObtenerListasCorreo()
        {
            return _daoEncuesta.FindAllListaCorreo();
        }

        public ListaCorreoDestino ObtenerListaCorreo(int id)
        {
            ListaCorreoDestino resultado = _daoEncuesta.FindListaCorreo(id);
            resultado.CorreosDestino = _daoEncuesta.FindCorreosDestionByListaCorreoId(id).ToList();
            return resultado;
        }

        public List<CorreoDestino> ConfigurarItemListaCorreoPorPersonasDestinatarias(List<PersonaDestinatario> destinatarios)
        {
            List<CorreoDestino> resultado = new List<CorreoDestino>();
            foreach (PersonaDestinatario cadaPersonaDestintario in destinatarios)
            {
                CorreoDestino correoDestino = new CorreoDestino();
                correoDestino.Destinatario = new PersonaDestinatario();
                correoDestino.Destinatario.Rut = TextBoxHelper.ObtenerEnteroRut(cadaPersonaDestintario.RutOrigen);
                correoDestino.Destinatario.Correo = cadaPersonaDestintario.CorreosOrigen;
                correoDestino.IdentificadorRelacionalOrigen = cadaPersonaDestintario.IdentificadorContextoOrigen;
                correoDestino.GlosaParametrosEncadenables = cadaPersonaDestintario.GlosaParametros;
                correoDestino.ArchivosAdjuntosEnviable = cadaPersonaDestintario.ReferenciaArchivosAdjuntoOrigen;
                correoDestino.TipoEstadoEnvio = Pulse.Contactador.Dto.Agendable.TiposEstadoEnvio.Pendiente;
                correoDestino.Destinatario.Celular = cadaPersonaDestintario.Celular;
                resultado.Add(correoDestino);
            }
            return resultado;
        }

        public CorreoDestino ObtenerCorreoDestino(int id)
        {
            return _daoEncuesta.FindCorreoDestino(id);
        }

        public List<CorreoDestino> ConfigurarItemListaCorreoPorPersonasDestinatarias(List<PersonaDestinatario> destinatarios, bool rutVieneConDV)
        {
            List<CorreoDestino> resultado = new List<CorreoDestino>();
            foreach (PersonaDestinatario cadaPersonaDestintario in destinatarios)
            {
                CorreoDestino correoDestino = new CorreoDestino();
                correoDestino.Destinatario = new PersonaDestinatario();
                correoDestino.Destinatario.Rut = configurarRut(cadaPersonaDestintario.RutOrigen, rutVieneConDV);
                correoDestino.Destinatario.Correo = cadaPersonaDestintario.CorreosOrigen;
                correoDestino.IdentificadorRelacionalOrigen = cadaPersonaDestintario.IdentificadorContextoOrigen;
                correoDestino.GlosaParametrosEncadenables = cadaPersonaDestintario.GlosaParametros;
                correoDestino.ArchivosAdjuntosEnviable = cadaPersonaDestintario.ReferenciaArchivosAdjuntoOrigen;
                correoDestino.TipoEstadoEnvio = Pulse.Contactador.Dto.Agendable.TiposEstadoEnvio.Pendiente;
                correoDestino.Destinatario.Celular = cadaPersonaDestintario.Celular;
                resultado.Add(correoDestino);
            }
            return resultado;
        }

        private int configurarRut(string rutOrigen, bool rutYaTieneDV)
        {
            try
            {
                if (rutYaTieneDV)
                    return TextBoxHelper.ObtenerEnteroRut(rutOrigen);
                else
                    return Convert.ToInt32(rutOrigen);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("El rut ingresado, no corresponde al formato especificado", ex);
            }
        }


        internal ListaCorreoDestino ObtenerListasCorreosPorCarpetaEncuesta(int carpetaEncuestaId)
        {
            var itemsCarpetaEncuesta = new Dao.DaoDataModel.DaoItemCarpetaEncuesta().FindByCarpetaId(carpetaEncuestaId);
            ListaCorreoDestino resultado = _daoEncuesta.FindListaCorreoDestinoByGrupoId(itemsCarpetaEncuesta.First().GrupoEncuestado.Id);
            resultado.CorreosDestino = new List<CorreoDestino>();
            var gruposDistintos = itemsCarpetaEncuesta.Select(t => t.GrupoEncuestado.Id).Distinct();
            foreach (var cadaGrupo in gruposDistintos)
            {
                ListaCorreoDestino corroDestionActual = _daoEncuesta.FindListaCorreoDestinoByGrupoId(cadaGrupo);
                corroDestionActual = this.ObtenerListaCorreo(corroDestionActual.Id);
                resultado.CorreosDestino.AddRange(corroDestionActual.CorreosDestino);
            }
            return resultado;
        }
    }
}
