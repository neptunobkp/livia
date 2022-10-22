using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Pulse.Contactador.BusinessLogic.Operaciones;
using Pulse.Utils.WebUtils.Helpers;
using Pulse.Contactador.Dto;
using Pulse.Contactador.BusinessLogic;
using System.Collections.Generic;
using System.Threading;

public partial class Campanias_ListaCorreo_Editar : PaginaBaseAutenticable
{
    public ListaCorreoDestino ViewStatesListaCorreoDestino
    {
        get { return (ListaCorreoDestino)ViewState["ViewStatesListaCorreoDestino"]; }
        set { ViewState["ViewStatesListaCorreoDestino"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        string cadenaListaId = Request["Id"].ToString();
        if (string.IsNullOrEmpty(cadenaListaId))
            throw new ApplicationException("La lista no existe, por favor inténtelo nuevamente");

        int listaId = 0;

        try
        {
            listaId = Int32.Parse(cadenaListaId);
        }
        catch (Exception)
        {
            throw new ApplicationException("La lista no existe, por favor inténtelo nuevamente");
        }

        DropDownListHelper.PoblarDropDownList<GrupoEncuestado>(new GestionarGruposEncuestado().ObtenerGrupos(), "Seleccione un grupo", "Id", "Nombre", this.ddlGrupo);

        try
        {
            GestionadorListaCorreo gestionador = new GestionadorListaCorreo();
            ListaCorreoDestino listaCorreo = gestionador.ObtenerListaCorreo(listaId);

            if (listaCorreo.Origen.TipoOrigenListaCorreo != TipoOrigenListaCorreo.SentenciaSql)
            {
                Response.Redirect("Listar.aspx?mensaje=Esta lista tiene un origen de datos que no es sentencia sql, no se permite su edición");
                return;
            }

            tbNombreListaCorreo.Text = listaCorreo.Descripcion;
            tbCodigoListaCorreo.Text = listaCorreo.Codigo;
            tbSentenciaSql.Text = listaCorreo.Origen.SentenciaSql;
            ddlGrupo.SelectedValue = listaCorreo.GrupoEncuestado.Id.ToString();

            if (listaCorreo.TipoFormaContacto == TiposFormaContacto.Indefinido)
                ddlFormaContacto.SelectedValue = TiposFormaContacto.CorreoElectronico.ToString();
            else
                ddlFormaContacto.SelectedValue = listaCorreo.TipoFormaContacto.ToString();

            this.ViewStatesListaCorreoDestino = listaCorreo;
        }
        catch (Exception)
        {
            Response.Redirect("Listar.aspx?mensaje=Ha ocurrido un problema al cargar los datos de la lista, por favor inténtelo más tarde.");
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            ListaCorreoDestino listaCorreoDestino = this.ViewStatesListaCorreoDestino;         
            listaCorreoDestino.Origen.TipoOrigenListaCorreo = TipoOrigenListaCorreo.SentenciaSql;
            listaCorreoDestino.Origen.SentenciaSql = this.tbSentenciaSql.Text;

            listaCorreoDestino.Descripcion = this.tbNombreListaCorreo.Text;
            listaCorreoDestino.Codigo = this.tbCodigoListaCorreo.Text;
            listaCorreoDestino.FechaModificacion = DateTime.Now;
            listaCorreoDestino.UsuarioModificador = base.SessionUsuarioContactador;
            GestionadorListaCorreo gestionador = new GestionadorListaCorreo();
            listaCorreoDestino.GrupoEncuestado = new GrupoEncuestado();
            try
            {
                listaCorreoDestino.GrupoEncuestado.Id = Convert.ToInt32(this.ddlGrupo.SelectedValue);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Por favor debe seleccionar un grupo", ex);
            }
            listaCorreoDestino.TipoFormaContacto = this.ObtenerTipoFormaContactoSeleccionado();
            gestionador.ActualizaListaCorreo(listaCorreoDestino);
            Response.Redirect("Listar.aspx?mensaje=Se ha modificado con éxito la lista de correo destino");
        }
        catch (ThreadAbortException) { }
        catch (Exception ex)
        {
            base.mensajeDialog(ex.Message);
        }
    }

    private TiposFormaContacto ObtenerTipoFormaContactoSeleccionado()
    {
        if (ddlFormaContacto.SelectedValue == "2") // SMS
            return TiposFormaContacto.MensajeTexto;
        else
            return TiposFormaContacto.CorreoElectronico;
    }
}
