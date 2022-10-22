using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pulse.Contactador.BusinessLogic;
using Pulse.Contactador.Dto;
using System.Text;

public partial class Encuestas_Resultado_VerRespuesta : PaginaBaseExterna
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        string identificadorEncuesta = Request.Params["encuestaId"];
        string identificadorRespuesta = Request.Params["respuestaId"];
        Encuesta encuesta = new GestionadorEncuesta().ObtenerEncuesta(Convert.ToInt32(identificadorEncuesta));

        configurarComponentesUIDinamicos(encuesta);
        this.repeaterPaginas.DataSource = encuesta.Paginas;
        this.repeaterPaginas.DataBind();

        Respuesta respuesta = new GestionadorEncuesta().ObtenerRespuesta(Convert.ToInt32(identificadorRespuesta));
        establecerRespuestas(respuesta, encuesta);


    }

    private void establecerRespuestas(Respuesta respuesta, Encuesta encuesta)
    {
        foreach (RepeaterItem cadaItem in this.repeaterPaginas.Items)
        {
            Repeater repeaterPreguntas = (Repeater)cadaItem.FindControl("repeaterPreguntas");
            foreach (RepeaterItem cadaItemPregunta in repeaterPreguntas.Items)
            {
                HiddenField hiddenFieldTipoPregunta = (HiddenField)cadaItemPregunta.FindControl("hiddenTipoPregunta");
                HiddenField hiddenFieldIdPregunta = (HiddenField)cadaItemPregunta.FindControl("hiddenIdPregunta");
                if (hiddenFieldTipoPregunta.Value == ((int)TiposPregunta.SeleccionUnica).ToString())
                {
                    Encuestas_Resultado_ResultadoPreguntaOpcionUnica controlOpcionUnica = (Encuestas_Resultado_ResultadoPreguntaOpcionUnica)cadaItemPregunta.FindControl("preguntaSeleccionUnica");
                    if (respuesta.ItemsRespuestas.Any(t => t.PregunaRespondida.Id.ToString() == hiddenFieldIdPregunta.Value))
                        controlOpcionUnica.EstablecerRespuesta(respuesta.ItemsRespuestas.First(t => t.PregunaRespondida.Id.ToString() == hiddenFieldIdPregunta.Value));
                }
                if (hiddenFieldTipoPregunta.Value == ((int)TiposPregunta.SeleccionMultiple).ToString())
                {
                    Encuestas_Resultado_ResultadoPreguntaOpcionMultiple controlOpcionMultiple = (Encuestas_Resultado_ResultadoPreguntaOpcionMultiple)cadaItemPregunta.FindControl("preguntaSeleccionMultiple");
                    if (respuesta.ItemsRespuestas.Any(t => t.PregunaRespondida.Id.ToString() == hiddenFieldIdPregunta.Value))
                        controlOpcionMultiple.EstablecerRespuesta(respuesta.ItemsRespuestas.Where(t => t.PregunaRespondida.Id.ToString() == hiddenFieldIdPregunta.Value).ToList());
                }
                if (hiddenFieldTipoPregunta.Value == ((int)TiposPregunta.TextoSimple).ToString())
                {
                    Encuestas_Resultado_ResultadoPreguntaSimple controlTextoSimple = (Encuestas_Resultado_ResultadoPreguntaSimple)cadaItemPregunta.FindControl("preguntaSeleccionTextoSimple");
                    if (respuesta.ItemsRespuestas.Any(t => t.PregunaRespondida.Id.ToString() == hiddenFieldIdPregunta.Value))
                        controlTextoSimple.EstablecerRespuesta(respuesta.ItemsRespuestas.First(t => t.PregunaRespondida.Id.ToString() == hiddenFieldIdPregunta.Value));
                }
                if (hiddenFieldTipoPregunta.Value == ((int)TiposPregunta.TextoEnsayo).ToString())
                {
                    Encuestas_Resultado_ResultadoPreguntaParrafo controlTextoEnsayo = (Encuestas_Resultado_ResultadoPreguntaParrafo)cadaItemPregunta.FindControl("preguntaSeleccionTextoEnsayo");
                    if (respuesta.ItemsRespuestas.Any(t => t.PregunaRespondida.Id.ToString() == hiddenFieldIdPregunta.Value))
                        controlTextoEnsayo.EstablecerRespuesta(respuesta.ItemsRespuestas.First(t => t.PregunaRespondida.Id.ToString() == hiddenFieldIdPregunta.Value));
                }
                if (hiddenFieldTipoPregunta.Value == ((int)TiposPregunta.Matriz).ToString())
                {
                    Encuestas_Resultado_ResultadoPreguntaMatriz controlMatrizUC = (Encuestas_Resultado_ResultadoPreguntaMatriz)cadaItemPregunta.FindControl("preguntaMatriz");
                    if (respuesta.ItemsRespuestas.Any(t => t.PregunaRespondida.Id.ToString() == hiddenFieldIdPregunta.Value))
                        controlMatrizUC.EstablecerRespuesta(respuesta.ItemsRespuestas.Where(t => t.PregunaRespondida.Id.ToString() == hiddenFieldIdPregunta.Value).ToList());
                }
            }
        }
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
}
