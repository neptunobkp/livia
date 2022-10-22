using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pulse.Contactador.BusinessLogic;
using Pulse.Utils.WebUtils.Helpers;
using Pulse.Contactador.Dto;
using Pulse.Contactador.BusinessLogic.Recursos;
using System.Threading;

public partial class Campanias_PanelControl_Crear : PaginaBaseAutenticable
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        GestionadorCreacionCampania gestionadorCreacionCampania = new GestionadorCreacionCampania();
        DropDownListHelper.PoblarDropDownList<MensajeCorreoDestino>(new GestionadorCreacionCampania().ObtenerMensajes(), "Seleccione un tipo de mensaje", "Id", "Titulo", this.ddlMensajesCorreo);
        DropDownListHelper.PoblaDropDonwListConEnumeracion<TiposPeriodosEjecucion>(this.dllPeriodoEjecucion);
        DropDownListHelper.PoblarDropDownList<Encuesta>(gestionadorCreacionCampania.ObtenerEncuestas(), "Seleccione una encuesta", "Id", "Titulo", ddlEncuesta);
        DropDownListHelper.PoblarDropDownList<CarpetaEncuesta>(new GestionadorCarpetaEncuesta().ObtenerCarpetasEncuestas(), "Seleccione una carpeta de encuestas", "Id", "Nombre", ddlCarpetasEncuesta);
        DropDownListHelper.PoblarDropDownList<ListaCorreoDestino>(gestionadorCreacionCampania.ObtenerListasCorreosDestinos(), "Seleccione una lista de correo", "Id", "Descripcion", ddlListaCorreoEnvio);
        DropDownListHelper.PoblaDropDonwListConEnumeracion<TiposEnvioMasivo>(this.ddlTipoEnvioMasivo);
        
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            Campania campania = new Campania();
            leerInformacionCampania(campania, true);
            new GestionadorCreacionCampania().AgregarCampania(campania);
            ControlsHelper.LimpiarFormularioDynamico(this.Controls);
            
            base.mensajeDialog("LA CAMPANIA SE A CREADO DE FORMA EXITOSA");
        }
        catch (ThreadAbortException) { }
        catch (ApplicationException ex)
        {
            base.mensajeDialog(ex.Message);
        }
        catch (Exception ex)
        {
            base.mensajeDialog(RecursoMensajes.errorGeneral);
        }
    }

    protected void btnVistaPrevia_Click(object sender, EventArgs e)
    {
        this.radGridListaCorreo.Visible = true;
        GestionadorEjecucionPlanCampania gestionadorEjecucion = new GestionadorEjecucionPlanCampania();
        Campania camapania = new Campania();
        leerInformacionCampania(camapania, false);
        gestionadorEjecucion.SimularEnvio(camapania);
        if (camapania.ControladorEnvioCorreo.ListaCorreosDestino.CorreosDestino.Count > 10)
        {
            base.mensajeDialog("La lista de correo es demasiado grande para mostrarla, de todas formas puede ejecutar su envío o guardar la campaña.");
            this.radGridListaCorreo.Visible = false;
        }
        else
        {
            this.radGridListaCorreo.DataSource = camapania.ControladorEnvioCorreo.ListaCorreosDestino.CorreosDestino;
            this.radGridListaCorreo.DataBind();
        }

        this.btnEjecutarEnvio.Visible = true;
    }

    protected void btnEjecutarEnvio_Click(object sender, EventArgs e)
    {
        Campania campania = new Campania();
        leerInformacionCampania(campania, true);
        GestionadorEjecucionPlanCampania gestionadorEjecucion = new GestionadorEjecucionPlanCampania();
        gestionadorEjecucion.RutaContenedorArchivosAdjuntos = Server.MapPath("~/Bandeja/ArchivosMensaje/");
        new GestionadorCreacionCampania().AgregarCampania(campania);
        gestionadorEjecucion.EjecutarCampania(campania);
        Response.Redirect("Resultado.aspx?id=" + campania.ControladorEnvioCorreo.ListaCorreosDestino.Id);
    }

    private void leerInformacionCampania(Campania campania, bool guardarControladorEnvio)
    {
        campania.ControladorEnvioCorreo = new ControladorEnvioCorreo();

        if (!string.IsNullOrEmpty(this.ddlEncuesta.SelectedValue))
            campania.Encuesta = new Encuesta() { Id = Convert.ToInt32(this.ddlEncuesta.SelectedValue) };
        if (!String.IsNullOrEmpty(this.ddlCarpetasEncuesta.SelectedValue))
            campania.CarpetaEncuesta = new CarpetaEncuesta() { Id = Convert.ToInt32(this.ddlCarpetasEncuesta.SelectedValue) };
        if (!String.IsNullOrEmpty(this.ddlListaCorreoEnvio.SelectedValue))
            campania.ControladorEnvioCorreo.ListaCorreosDestino = new ListaCorreoDestino() { Id = Convert.ToInt32(this.ddlListaCorreoEnvio.SelectedValue) };
        campania.ControladorEnvioCorreo.MensajeCorreoUnico = new MensajeCorreoDestino() { Id = Convert.ToInt32(this.ddlMensajesCorreo.SelectedValue) };
        campania.ControladorEnvioCorreo.TipoEnvioCorreo = (TiposEnvioCorreo)Convert.ToInt32(this.ddlTipoEnvioMasivo.SelectedValue);
        campania.TipoPeriodoEjecucion = (TiposPeriodosEjecucion)Convert.ToInt32(this.dllPeriodoEjecucion.SelectedValue);
        campania.FechaEnvioEsperado = this.tbFechaProgramadaEnvio.SelectedDate;
        campania.FechaTerminoEsperado = this.tbFechaProgramadaTermino.SelectedDate;
        campania.FechaCreacion = DateTime.Now;
        campania.Motivo = new EntidadParametrizable();
        campania.Motivo.Codigo = this.ddlMotivoCampania.SelectedValue;
        campania.Motivo.Glosa = this.ddlMotivoCampania.SelectedItem.Text;
        campania.IdentificadorPropietario = base.SessionUsuarioContactador.IdentificadorPropietario;
        campania.IdentificadorPropietarioAplicacion = base.SessionUsuarioContactador.IdentificadorPropietarioAplicacion;
        campania.TipoPropietario = base.SessionUsuarioContactador.TipoPropietario;
        campania.UsuarioCreador = base.SessionUsuarioContactador.UsuarioCreador;
        campania.UsuarioModificador = base.SessionUsuarioContactador.UsuarioModificador;
        if (guardarControladorEnvio)
            campania.ControladorEnvioCorreo.Id = new GestionarControladorEnvioCorreo().AgregarControladorEnvioCorreo(campania.ControladorEnvioCorreo);
    }
}
