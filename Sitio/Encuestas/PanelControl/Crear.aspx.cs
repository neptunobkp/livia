using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Pulse.Contactador.Dto;
using Pulse.Contactador.BusinessLogic;
using System.Threading;

public partial class Encuestas_PanelControl_Crear : PaginaBaseAutenticable
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        radcomboPlantilla.DataSource = new GestionadorPlantilla().ObtenerPlantillas();
        radcomboPlantilla.DataValueField = "Id";
        radcomboPlantilla.DataTextField = "Titulo";
        radcomboPlantilla.DataBind();
    }

    protected void linkGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            GestionadorCreacionEncuesta gestionadorCreacionEncuesta = new GestionadorCreacionEncuesta();
            Encuesta nuevaEncuesta = new Encuesta();
            nuevaEncuesta.Titulo = this.tbTituloEncuesta.Text;
            nuevaEncuesta.Introduccion = this.tbDescripcionEncuesta.Text;
            nuevaEncuesta.DescripcionPiePagina = this.tbDescripcionEncuesta.Text;
            nuevaEncuesta.MensajePiePagina = this.tbMensajePiePagina.Text;
            nuevaEncuesta.DescripcionPiePagina = this.tbDescripcionPiePagina.Text;
            nuevaEncuesta.FechaInicioVigencia = this.tbFechaInicioEncuesta.SelectedDate;
            nuevaEncuesta.FechaTerminoVigencia = this.tbFechaTErminoEncuesta.SelectedDate;
            nuevaEncuesta.CuotaLimiteEncuesta = Convert.ToInt32(this.tbCantidadEncuestasMaximas.Value);
            nuevaEncuesta.PlantillaEncuesta = new Plantilla() { Id = Convert.ToInt32(this.radcomboPlantilla.SelectedValue) };
            nuevaEncuesta.Paginas = new List<Pagina>();
            recogerPaginasConPreguntas(nuevaEncuesta);
            nuevaEncuesta.NumeroPaginas = nuevaEncuesta.Paginas.Count;
            nuevaEncuesta.FechaCreacion = DateTime.Now;
            nuevaEncuesta.FechaModificacion = DateTime.Now;
            nuevaEncuesta.UsuarioCreador = base.SessionUsuarioContactador;
            nuevaEncuesta.UsuarioModificador = base.SessionUsuarioContactador;
            nuevaEncuesta.PrimeraPaginaContenidaEnPresentacion = this.checkMantenerPrimeraPaginaContenida.Checked;
            gestionadorCreacionEncuesta.CrearEncuesta(nuevaEncuesta);
            Response.Redirect("Listar.aspx?mensaje=Se ha agregado con éxito la encuesta de id : " + nuevaEncuesta.Id);
        }
        catch (ThreadAbortException) { }
        catch (Exception ex)
        {
            base.mensajeDialog(ex.Message);
        }
    }

    private void recogerPaginasConPreguntas(Encuesta nuevaEncuesta)
    {
        if (String.IsNullOrEmpty(this.radiButtonListNumeroPaginas.SelectedValue))
        {
            Pagina pagina = new Pagina() { Preguntas = this.paginaEncuesta1.RecogerPreguntasRecargadas(), NumeroPagina = 1 };
            this.paginaEncuesta1.CompletarInfoPagina(pagina);
            nuevaEncuesta.Paginas.Add(pagina);
            return;
        }
        if (Convert.ToInt32(this.radiButtonListNumeroPaginas.SelectedValue) >= 1)
        {
            Pagina pagina = new Pagina() { Preguntas = this.paginaEncuesta1.RecogerPreguntasRecargadas(), NumeroPagina = 1 };
            this.paginaEncuesta1.CompletarInfoPagina(pagina);
            nuevaEncuesta.Paginas.Add(pagina);
        }
        if (Convert.ToInt32(this.radiButtonListNumeroPaginas.SelectedValue) >= 2)
        {
            Pagina pagina = new Pagina() { Preguntas = this.paginaEncuesta2.RecogerPreguntasRecargadas(), NumeroPagina = 2 };
            this.paginaEncuesta2.CompletarInfoPagina(pagina);
            nuevaEncuesta.Paginas.Add(pagina);
        }
        if (Convert.ToInt32(this.radiButtonListNumeroPaginas.SelectedValue) >= 3)
        {
            Pagina pagina = new Pagina() { Preguntas = this.paginaEncuesta3.RecogerPreguntasRecargadas(), NumeroPagina = 3 };
            this.paginaEncuesta3.CompletarInfoPagina(pagina);
            nuevaEncuesta.Paginas.Add(pagina);
        }
        if (Convert.ToInt32(this.radiButtonListNumeroPaginas.SelectedValue) >= 4)
        {
            Pagina pagina = new Pagina() { Preguntas = this.paginaEncuesta4.RecogerPreguntasRecargadas(), NumeroPagina = 4 };
            this.paginaEncuesta4.CompletarInfoPagina(pagina);
            nuevaEncuesta.Paginas.Add(pagina);
        }
    }

}
