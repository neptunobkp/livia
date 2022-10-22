using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pulse.Contactador.BusinessLogic.Operaciones;
using Pulse.Contactador.Dto;
using System.Threading;
using System.Globalization;
using Pulse.Contactador.BusinessLogic.Recursos;

public partial class Web_Autenticacion_Login : PaginaBaseAutenticable
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        try
        {
            GestionadorIngreso gestionadorIngreso = new GestionadorIngreso();
            Usuario usuario = gestionadorIngreso.Autenticar(this.tbNombreIngreso.Text, this.tbContrasenia.Text);
            if (usuario != null)
            {
                this.SessionUsuarioContactador = new Usuario();
                this.SessionUsuarioContactador.IdentificadorPropietarioAplicacion = usuario.IdentificadorPropietarioAplicacion;
                this.SessionUsuarioContactador.IdentificadorPropietario = usuario.IdentificadorPropietario;
                this.SessionUsuarioContactador.Id = usuario.Id;
                this.SessionUsuarioContactador.UsuarioCreador = new Usuario();
                this.SessionUsuarioContactador.UsuarioModificador = new Usuario();
                this.SessionUsuarioContactador.UsuarioCreador = usuario;
                this.SessionUsuarioContactador.UsuarioModificador = usuario;
            }
            Response.Redirect("../Interno/Inicio.aspx");
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
}
