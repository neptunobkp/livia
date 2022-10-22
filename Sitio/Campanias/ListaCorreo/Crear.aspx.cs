using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pulse.Contactador.BusinessLogic;
using Pulse.Contactador.Dto;
using Pulse.Contactador.BusinessLogic.Operaciones;
using System.Threading;
using Resources;
using Pulse.Utils.WebUtils.Helpers;

public partial class Campanias_ListaCorreo_Crear : PaginaBaseAutenticable
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        GestionadorAccesador gestionador = new GestionadorAccesador();
        DropDownListHelper.PoblarDropDownList<GrupoEncuestado>(new GestionarGruposEncuestado().ObtenerGrupos(), "Seleccione un grupo", "Id", "Nombre", this.ddlGrupo);
        this.ddlCadenaConexion.DataSource = gestionador.ObtenerCadenasConexion();
        this.ddlCadenaConexion.DataBind();
    }

    protected void btnCargar_Click(object sender, EventArgs e)
    {
        GestionadorAccesador gestionador = new GestionadorAccesador();
        try
        {
            GestionadorListaCorreo gestionadorListaCorreo = new GestionadorListaCorreo();
            ListaCorreoDestino listaCorreoDestino = new ListaCorreoDestino();
            listaCorreoDestino.TipoFormaContacto = ObtenerTipoFormaContactoSeleccionado();
            listaCorreoDestino.Origen = new OrigenListaCorreo();
            listaCorreoDestino.Origen.CadenaConexion = gestionador.ObtenerCadenaConexion(Convert.ToInt32(this.ddlCadenaConexion.SelectedValue));
            listaCorreoDestino.Origen.SentenciaSql = this.tbSentenciaSql.Text;

            var personas = gestionador.EjecutarSentencia(listaCorreoDestino);
            mostrarDataPersonas(personas);
            base.mensajeDialog(personas.Count > 0 ? RecursoMensajesWeb.SentenciaExcelente : RecursoMensajesWeb.SentenciaCorrectaSinRegistros);
            btnGuardar.Focus();
        }
        catch (Exception ex)
        {
            base.mensajeDialog(ex.Message);
        }
    }

    private void mostrarDataPersonas(List<PersonaDestinatario> personas)
    {
        this.gridPersonas.DataSource = personas;
        this.gridPersonas.DataBind();
    }

    private TiposFormaContacto ObtenerTipoFormaContactoSeleccionado()
    {
        if (ddlFormaContacto.SelectedValue == "2") // SMS
            return TiposFormaContacto.MensajeTexto;
        else
            return TiposFormaContacto.CorreoElectronico;
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            ListaCorreoDestino listaCorreoDestino = new ListaCorreoDestino();
            listaCorreoDestino.Origen = new OrigenListaCorreo();
            listaCorreoDestino.CorreosDestino = new List<CorreoDestino>();
            listaCorreoDestino.Origen.TipoOrigenListaCorreo = inferirTipoOrigenListaCorreo();
            completarInformacionCargaPorTipo(listaCorreoDestino);
            listaCorreoDestino.Origen.SentenciaSql = this.tbSentenciaSql.Text;
            listaCorreoDestino.Descripcion = this.tbNombreListaCorreo.Text;
            listaCorreoDestino.Codigo = this.tbCodigoListaCorreo.Text;
            listaCorreoDestino.FechaCreacion = DateTime.Now;
            listaCorreoDestino.FechaModificacion = DateTime.Now;
            listaCorreoDestino.UsuarioModificador = base.SessionUsuarioContactador;
            listaCorreoDestino.UsuarioCreador = base.SessionUsuarioContactador;
            GestionadorListaCorreo gestionador = new GestionadorListaCorreo();
            listaCorreoDestino.GrupoEncuestado = new GrupoEncuestado();
            if (!String.IsNullOrEmpty(this.ddlGrupo.SelectedValue)) listaCorreoDestino.GrupoEncuestado.Id = Convert.ToInt32(this.ddlGrupo.SelectedValue);
            listaCorreoDestino.TipoFormaContacto = this.ObtenerTipoFormaContactoSeleccionado();
            gestionador.AgregarListaCorreo(listaCorreoDestino);
            Response.Redirect("Listar.aspx?mensaje=Se ha creado con éxito la lista de correo destino");
        }
        catch (ThreadAbortException) { }
        catch (Exception ex)
        {
            base.mensajeDialog(ex.Message);
        }
    }

    private void completarInformacionCargaPorTipo(ListaCorreoDestino listaCorreoDestino)
    {
        var origenListaCorreo = listaCorreoDestino.Origen;
        if (origenListaCorreo.TipoOrigenListaCorreo == TipoOrigenListaCorreo.SentenciaSql)
        {
            origenListaCorreo.SentenciaSql = this.tbSentenciaSql.Text;
            origenListaCorreo.CadenaConexion = new CadenaConexion() { Id = Convert.ToInt32(this.ddlCadenaConexion.SelectedValue) };
            origenListaCorreo.CargarEnDemanda = this.checkEjecutarAhora.Checked;
            origenListaCorreo.RutCargadoConDigitoVerificador = this.checkRutsContieneDigitoVerificador.Checked;
        }
        else if (origenListaCorreo.TipoOrigenListaCorreo == TipoOrigenListaCorreo.ArchivoCargaCsv)
        {
            String nombreArchivo = Guid.NewGuid().ToString() + ".csv";
            String pathBandejaConArchivo = Server.MapPath("~/Bandeja/ArchivosCarga" + nombreArchivo);
            CSVReader reader = new CSVReader(fuArchivoCarga.PostedFile.InputStream);
            var destintarios = reader.ExtraerPersonasDestinatarias(this.ObtenerTipoFormaContactoSeleccionado());
            listaCorreoDestino.CorreosDestino.AddRange(new GestionadorListaCorreo().ConfigurarItemListaCorreoPorPersonasDestinatarias(destintarios));
            origenListaCorreo.PathArchivoListaCorreos = pathBandejaConArchivo;
            fuArchivoCarga.SaveAs(pathBandejaConArchivo);
        }
        else if (origenListaCorreo.TipoOrigenListaCorreo == TipoOrigenListaCorreo.Manual)
        {
            CSVReader reader = new CSVReader();
            var destinatarios = reader.ExtraerPersonasDestinatarias(this.tbDatos.Text, this.ObtenerTipoFormaContactoSeleccionado());
            listaCorreoDestino.CorreosDestino.AddRange(new GestionadorListaCorreo().ConfigurarItemListaCorreoPorPersonasDestinatarias(destinatarios));
        }
    }

    private TipoOrigenListaCorreo inferirTipoOrigenListaCorreo()
    {
        if (!string.IsNullOrEmpty(this.tbDatos.Text))
            return TipoOrigenListaCorreo.Manual;

        if (this.fuArchivoCarga.HasFile)
            return TipoOrigenListaCorreo.ArchivoCargaCsv;

        if (!string.IsNullOrEmpty(this.tbSentenciaSql.Text))
            return TipoOrigenListaCorreo.SentenciaSql;

        throw new ApplicationException("Debe completar algunas de las formas de carga.");
    }

}
