using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pulse.Contactador.Dto;
using Pulse.Contactador.BusinessLogic;
using System.Text;
using System.Threading;
using Pulse.Utils.Exceptions;
using Pulse.Contactador.BusinessLogic.Recursos;

public partial class Web_Encuesta_Responder : PaginaBaseExterna
{
    public Respuesta ViewStateRespuesta
    {
        get { return (Respuesta)ViewState["ViewStateRespuesta"]; }
        set { ViewState["ViewStateRespuesta"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        try
        {
            if (Request.Params[RecursoParametros.GetItemCorreoDestinoId] == RecursoParametros.ValueVerEncuesta)
            {
                ver(Request.Params[RecursoParametros.GetEncuestaId]);
                this.btnEnviar.Enabled = false;
                return;
            }
            validarSolicitudEncuesta();
            int identificadorEncuesta = Convert.ToInt32(Request.Params[RecursoParametros.GetEncuestaId]);
            int identificadorItemCorreo = Convert.ToInt32(Request.Params[RecursoParametros.GetItemCorreoDestinoId]);
            int identificadorCampania = Convert.ToInt32(Request.Params[RecursoParametros.GetCampaniaId]);
            Encuesta encuesta = new GestionadorEncuesta().ObtenerEncuesta(identificadorEncuesta);
            presentarEncuesta(encuesta);
            configurarRespuesta(identificadorItemCorreo, identificadorCampania, encuesta);
        }
        catch (ThreadAbortException) { }
        catch (Exception ex)
        {
            LoggerManager.LogError("error en encuesta", TiposCategoryLog.LogMAIL, ex);
            Response.Redirect("PanelMensaje.aspx?mensaje=Esta encuesta esta teniendo problemas, esperamos poder resolverlos lo antes posible, vuelva a intentarlo mas tarde.");
        }
    }

    private void configurarRespuesta(int identificadorItemCorreo, int identificadorCampania, Encuesta encuesta)
    {
        Respuesta respuestaRecuperada = new GestionadorEncuesta().RecuperarRespuestaPorItemCorreoCampaniaEncuesta(identificadorItemCorreo, identificadorCampania, encuesta.Id);
        if (respuestaRecuperada != null)
        {
            this.ViewStateRespuesta = respuestaRecuperada;
            switch (this.ViewStateRespuesta.TipoEstadoRespuestaEncuesta)
            {
                case TiposEstadoRespuestaEncuesta.EncuestaAbierta: return;
                case TiposEstadoRespuestaEncuesta.EncuestaTerminada: Response.Redirect("PanelMensaje.aspx?mensaje=Esta encuesta ya ha sido completada.", true); break;
                case TiposEstadoRespuestaEncuesta.EncuestaCerrada: Response.Redirect("PanelMensaje.aspx?mensaje=Lo sentimos, pero esta encuesta ha sido cerrada.", true); break;
                default: break;
            }
        }
        else
            this.ViewStateRespuesta = new Respuesta();
        configurarItemCorreoEnRespuesta(this.ViewStateRespuesta);
        this.ViewStateRespuesta.EncuestaRespondida = encuesta;
        this.ViewStateRespuesta.InicioRespuestaEncuesta = DateTime.Now;
        this.ViewStateRespuesta.Navegador = this.Page.Request.Browser.Browser + " " + this.Page.Request.Browser.Version;
        this.ViewStateRespuesta.DireccionIP = Request.UserHostAddress;
        this.ViewStateRespuesta.NombreUsuarioCliente = this.Page.Request.ServerVariables["LOGON_USER"];
        this.ViewStateRespuesta.ItemsRespuestas = new List<ItemRespuesta>();
        this.ViewStateRespuesta.TipoEstadoRespuestaEncuesta = TiposEstadoRespuestaEncuesta.EncuestaAbierta;
        this.ViewStateRespuesta.CampaniaPropietaria = new Campania() { Id = identificadorCampania };
        this.ViewStateRespuesta.Id = new GestionadorEncuesta().GuardarSemillaRespuestaEncuesta(this.ViewStateRespuesta);
    }



    private void presentarEncuesta(Encuesta encuesta)
    {
        configurarComponentesUIDinamicos(encuesta);
        this.repeaterPaginas.DataSource = encuesta.Paginas;
        this.repeaterPaginas.DataBind();
    }

    private void ver(String identificadorEncuesta)
    {
        Encuesta encuesta = new GestionadorEncuesta().ObtenerEncuesta(Convert.ToInt32(identificadorEncuesta));
        configurarComponentesUIDinamicos(encuesta);
        this.repeaterPaginas.DataSource = encuesta.Paginas;
        this.repeaterPaginas.DataBind();
    }

    private void configurarItemCorreoEnRespuesta(Respuesta respuesta)
    {
        CorreoDestino correoDestino = new GestionadorListaCorreo().ObtenerCorreoDestino(Convert.ToInt32(Request.Params["itemcorreoId"]));
        if (correoDestino == null) Response.Redirect("PanelMensaje.aspx?mensaje=" + "No se encontro la información del encuestado", true);
        respuesta.Encuestado = new PersonaEncuestable();
        respuesta.Encuestado.Rut = correoDestino.Destinatario.Rut;
        respuesta.Encuestado.Id = correoDestino.Id;
        respuesta.Encuestado.Correo = correoDestino.Destinatario.Correo;
    }

    private void validarSolicitudEncuesta()
    {
        String encuestaID = Request.Params[RecursoParametros.GetEncuestaId];
        String itemListaCorreoID = Request.Params[RecursoParametros.GetItemCorreoDestinoId];
        String campaniaId = Request.Params[RecursoParametros.GetCampaniaId];
        if (String.IsNullOrEmpty(encuestaID) || String.IsNullOrEmpty(itemListaCorreoID) || String.IsNullOrEmpty(campaniaId))
            Response.Redirect("PanelMensaje.aspx?mensaje=" + "No se identificaron los datos mínimos para presentar esta encuesta.", true);
    }

    private void configurarComponentesUIDinamicos(Encuesta encuesta)
    {
        StringBuilder jq = new StringBuilder();
        if (!String.IsNullOrEmpty(encuesta.PlantillaEncuesta.RutaArchivoCss))
            jq.AppendLine(string.Format("$(\"link\").attr(\"href\", \"../../App_Themes/PulseTheme/css/styles/{0}/ui.css\");", encuesta.PlantillaEncuesta.NombreCarpetaEstilo));
        jq.AppendLine("$(\"#divpaginas\").formToWizard({ submitButton: 'ctl00_content_body_btnEnviar' })");
        base.executeJqueryScript(jq.ToString());
        this.imageBanner.ImageUrl = imageBanner.ImageUrl + encuesta.PlantillaEncuesta.NombreCarpetaEstilo + "/" + encuesta.PlantillaEncuesta.PathBanner;
        this.literalTituloEncuesta.Text = encuesta.Titulo;
        this.literalDescripcion.Text = encuesta.PlantillaEncuesta.CuerpoHtml;
        this.literalMensajePiePaginaEncuesta.Text = encuesta.MensajePiePagina;
        this.literalDescripcionMensajePiePaginaEncuesta.Text = encuesta.DescripcionPiePagina;
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {

        foreach (RepeaterItem cadaRepeaterPaginaItem in this.repeaterPaginas.Items)
        {
            int numeroPagina = Convert.ToInt32(((HiddenField)cadaRepeaterPaginaItem.FindControl("hiddenNumeroPagina")).Value);
            Repeater repeaterPreguntas = (Repeater)cadaRepeaterPaginaItem.FindControl("repeaterPreguntas");
            foreach (RepeaterItem cadaRepeaterPreguntaItem in repeaterPreguntas.Items)
            {
                int preguntaId = Convert.ToInt32(((HiddenField)cadaRepeaterPreguntaItem.FindControl("hiddenIdPregunta")).Value);
                TiposPregunta tipoPregunta = (TiposPregunta)Convert.ToInt32(((HiddenField)cadaRepeaterPreguntaItem.FindControl("hiddenTipoPregunta")).Value);
                Pregunta preguntaRespondida = this.ViewStateRespuesta.EncuestaRespondida.Paginas.Single(t => t.NumeroPagina == numeroPagina).Preguntas.Single(p => p.Id == preguntaId);
                if (tipoPregunta == TiposPregunta.TextoSimple)
                {
                    ItemRespuesta itemRespuesta = new ItemRespuesta();
                    itemRespuesta.PregunaRespondida = new Pregunta() { Id = preguntaRespondida.Id };
                    itemRespuesta.TipoPreguntaRespondida = tipoPregunta;
                    Web_Encuesta_RespuestaSimple controlRespuestaSimple = (Web_Encuesta_RespuestaSimple)cadaRepeaterPreguntaItem.FindControl("preguntaSeleccionTextoSimple");
                    controlRespuestaSimple.RecogerRespuesta(itemRespuesta);
                    this.ViewStateRespuesta.ItemsRespuestas.Add(itemRespuesta);
                }
                if (tipoPregunta == TiposPregunta.TextoEnsayo)
                {
                    ItemRespuesta itemRespuesta = new ItemRespuesta();
                    itemRespuesta.PregunaRespondida = new Pregunta() { Id = preguntaRespondida.Id };
                    itemRespuesta.TipoPreguntaRespondida = tipoPregunta;
                    Web_Encuesta_RespuestaParrafo controlRespuestaEnsayo = (Web_Encuesta_RespuestaParrafo)cadaRepeaterPreguntaItem.FindControl("preguntaSeleccionTextoEnsayo");
                    controlRespuestaEnsayo.RecogerRespuesta(itemRespuesta);
                    this.ViewStateRespuesta.ItemsRespuestas.Add(itemRespuesta);
                }
                if (tipoPregunta == TiposPregunta.SeleccionUnica)
                {
                    Web_Encuesta_OpcionUnica controlRespuestaUnica = (Web_Encuesta_OpcionUnica)cadaRepeaterPreguntaItem.FindControl("preguntaSeleccionUnica");
                    controlRespuestaUnica.RecogerRespuestas(this.ViewStateRespuesta, preguntaRespondida);
                }
                if (tipoPregunta == TiposPregunta.SeleccionMultiple)
                {
                    Web_Encuesta_OpcionMultiple controlRespuestaMultiple = (Web_Encuesta_OpcionMultiple)cadaRepeaterPreguntaItem.FindControl("preguntaSeleccionMultiple");
                    controlRespuestaMultiple.RecogerRespuestas(this.ViewStateRespuesta, preguntaRespondida);
                }
                if (tipoPregunta == TiposPregunta.Matriz)
                {
                    Web_Encuesta_RespuestaMatriz controlRespuestaMatriz = (Web_Encuesta_RespuestaMatriz)cadaRepeaterPreguntaItem.FindControl("preguntaMatriz");
                    controlRespuestaMatriz.RecogerRespuestas(this.ViewStateRespuesta, preguntaRespondida);
                }
            }
        }
        this.ViewStateRespuesta.TipoEstadoRespuestaEncuesta = TiposEstadoRespuestaEncuesta.EncuestaTerminada;
        this.ViewStateRespuesta.TerminoRespuestaEncuesta = DateTime.Now;
        TimeSpan tiempoTranscurrido = this.ViewStateRespuesta.TerminoRespuestaEncuesta.Value - this.ViewStateRespuesta.InicioRespuestaEncuesta;
        this.ViewStateRespuesta.MinutosParaCompletarEncuesta = tiempoTranscurrido.Minutes;
        this.ViewStateRespuesta.Anotacion = "Encuesta completada";
        new GestionadorEncuesta().ActualizarGuardarRespuestasEncuesta(this.ViewStateRespuesta);
        Response.Redirect("Mensaje.aspx");
    }
}
