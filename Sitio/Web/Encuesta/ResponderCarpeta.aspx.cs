using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pulse.Contactador.Dto;
using Pulse.Contactador.BusinessLogic;
using Pulse.Contactador.BusinessLogic.Recursos;
using System.Drawing;
using System.Text;

public partial class Web_Encuesta_ResponderCarpeta : PaginaBaseExterna
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        if (Request.Params[RecursoParametros.GetItemCorreoDestinoId] == RecursoParametros.ValueVerEncuesta)
        {
            ver(Request.Params[RecursoParametros.GetCarpetaId]);
            return;
        }

        int carpetaId = Convert.ToInt32(Request.QueryString[RecursoParametros.GetCarpetaId]);
        int correoDestinoId = Convert.ToInt32(Request.QueryString[RecursoParametros.GetItemCorreoDestinoId]);
        int campaniaId = Convert.ToInt32(Request.QueryString[RecursoParametros.GetCarpetaId]);
        CarpetaEncuesta carpetaEncuesta = new GestionadorCarpetaEncuesta().ObtenerCarpetaEncuesta(carpetaId);
        CorreoDestino correoDestino = new GestionadorListaCorreo().ObtenerCorreoDestino(correoDestinoId);
        ListaCorreoDestino listaCorreoDstino = new GestionadorListaCorreo().ObtenerListaCorreo(correoDestino.IdentificadorPropietario);

        var itemsDisponiblesPorGrupo = carpetaEncuesta.ItemsCarpetaEncuesta.Where(t => t.GrupoEncuestado.Id == listaCorreoDstino.GrupoEncuestado.Id);

        List<PresentadorCarpetaEncuesta> presentadores = new List<PresentadorCarpetaEncuesta>();
        foreach (var cadaitem in itemsDisponiblesPorGrupo)
        {
            PresentadorCarpetaEncuesta presentador = new PresentadorCarpetaEncuesta();
            presentador.NombreEncuesta = cadaitem.Encuesta.Titulo;
            presentador.UrlEncuesta = String.Format("~/Web/Encuesta/Responder.aspx?{0}={1}&{2}={3}&{4}={5}",
                RecursoParametros.GetEncuestaId, cadaitem.Encuesta.Id,
                 RecursoParametros.GetItemCorreoDestinoId, correoDestinoId,
                 RecursoParametros.GetCampaniaId, campaniaId);

            presentador.TipoCategoria = cadaitem.TipoEstadoCarpetaEncuesta.ToString();
            presentador.Disponible = verificarSiEncuestaEsDisponible(correoDestinoId, campaniaId, cadaitem.Encuesta);
            presentador.PathImagenEstado = String.Format("../../App_Themes/PulseTheme/images/icons/encuesta_{0}.png", presentador.Disponible ? "falta" : "lista");
            presentador.ToolTipIcon = presentador.Disponible ? "Esta encuesta esta pendiente" : "Esta encuesta ya fue cerrada";
            presentadores.Add(presentador);
        }

        int porcentajeAvanceEstadoEncuesta = calcularPorcentajeAvanceEncuesta(itemsDisponiblesPorGrupo);
        int porcentajeAvanceGeneral = calcularPorcentajeAvanceEncuestaGeneral(itemsDisponiblesPorGrupo);
        presentarPorcentajeAvane(porcentajeAvanceEstadoEncuesta, porcentajeAvanceGeneral);
        this.repeaterEncuestas.DataSource = presentadores;
        this.repeaterEncuestas.DataBind();
    }

    private void presentarPorcentajeAvane(int porcentajeAvanceEstadoEncuesta, int porcentajeAvanceGeneral)
    {
        this.literalPorcentajeAvance.Text = porcentajeAvanceEstadoEncuesta.ToString() + "%";
        this.literalPorcentajeAvanceOtras.Text = porcentajeAvanceGeneral.ToString() + "%";
        StringBuilder progressBarsBuilder = new StringBuilder();
        progressBarsBuilder.AppendLine(String.Format("$('#status').animate({{ width: '{0}%' }}, 500);", porcentajeAvanceEstadoEncuesta.ToString()));
        progressBarsBuilder.AppendLine(String.Format("$('#status2').animate({{ width: '{0}%' }}, 500);", porcentajeAvanceGeneral.ToString()));
        base.executeJqueryScript(progressBarsBuilder.ToString());
    }

    private void presentarPorcentajeAvane(int porcentajeAvanceEstadoEncuesta)
    {
        this.literalPorcentajeAvance.Text = porcentajeAvanceEstadoEncuesta.ToString() + "%";
        base.executeJqueryScript(String.Format("$('#status').animate({{ width: '{0}%' }}, 500);", porcentajeAvanceEstadoEncuesta.ToString()));
    }


    private int calcularPorcentajeAvanceEncuestaGeneral(IEnumerable<ItemCarpetaEncuesta> itemsDisponiblesPorGrupo)
    {
        int totalEncuestas = itemsDisponiblesPorGrupo.Count();
        if (totalEncuestas == 0) return 100;
        int encuestasCompletadas = itemsDisponiblesPorGrupo.Count(t => t.Encuesta.TipoEstaRespuestaEncuesta == TiposEstadoRespuestaEncuesta.EncuestaTerminada);
        return ((encuestasCompletadas * 100) / totalEncuestas);
    }


    private int calcularPorcentajeAvanceEncuesta(IEnumerable<ItemCarpetaEncuesta> itemsDisponiblesPorGrupo)
    {
        int totalEncuestas = itemsDisponiblesPorGrupo.Count();
        var encuestasObligatorias = itemsDisponiblesPorGrupo.Where(t => t.TipoEstadoCarpetaEncuesta == TiposEstadoCarpetaEncuesta.Obligatoria);
        if (encuestasObligatorias.Count() == 0) return 100;
        int encuestasCompletadasObligatorias = encuestasObligatorias.Count(t => t.Encuesta.TipoEstaRespuestaEncuesta == TiposEstadoRespuestaEncuesta.EncuestaTerminada);
        return ((encuestasCompletadasObligatorias * 100) / totalEncuestas);
    }



    private bool verificarSiEncuestaEsDisponible(int correoDestinoId, int campaniaId, Encuesta encuesta)
    {
        int encuestaId = encuesta.Id;
        Respuesta respuestaRecuperada = new GestionadorEncuesta().RecuperarRespuestaPorItemCorreoCampaniaEncuesta(correoDestinoId, campaniaId, encuestaId);
        if (respuestaRecuperada != null)
        {
            encuesta.TipoEstaRespuestaEncuesta = respuestaRecuperada.TipoEstadoRespuestaEncuesta;
            switch (respuestaRecuperada.TipoEstadoRespuestaEncuesta)
            {
                case TiposEstadoRespuestaEncuesta.EncuestaAbierta: return true;
                case TiposEstadoRespuestaEncuesta.EncuestaTerminada: return false;
                case TiposEstadoRespuestaEncuesta.EncuestaCerrada: return false;
                default: return true;
            }
        }
        return true;
    }

    private void ver(string carpetaId)
    {
    }
}

