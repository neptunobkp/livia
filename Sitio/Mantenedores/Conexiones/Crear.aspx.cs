using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pulse.Contactador.BusinessLogic.Operaciones;
using Pulse.Contactador.Dto;

public partial class Mantenedores_Conexiones_Crear : PaginaBaseAutenticable
{
    protected void Page_Load(object sender, EventArgs e)
    {
        tbContrasenia.Attributes.Add("value", tbContrasenia.Text);
        if (IsPostBack) return;
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            GestionadorAccesador gestioandorAccesador = new GestionadorAccesador();
            CadenaConexion cadena = new CadenaConexion();
            leerCadena(cadena);
            gestioandorAccesador.ProbarConexion(cadena);
            gestioandorAccesador.GuardarCadenaConexion(cadena);
            Response.Redirect("Listar.aspx?mensaje=Se ha guardado con éxito la cadena de conexión", true);
        }
        catch (Exception ex)
        {
            base.mensajeDialog(ex.Message);
        }
    }

    protected void btnTestearConexion_Click(object sender, EventArgs e)
    {
        try
        {
            this.btnGuardar.Visible = false;
            GestionadorAccesador gestioandorAccesador = new GestionadorAccesador();
            CadenaConexion cadena = new CadenaConexion();
            leerCadena(cadena);
            gestioandorAccesador.ProbarConexion(cadena);
            base.mensajeDialog("Prueba de conexión exitosa!");
            this.btnGuardar.Visible = true;
        }
        catch (Exception ex)
        {
            base.mensajeDialog(ex.Message);
        }
    }

    private void leerCadena(CadenaConexion cadenaConexion)
    {
        if (String.IsNullOrEmpty(radioListBaseDatos.SelectedValue)) throw new ApplicationException("Debe seleccionar un motor de base de datos");
        cadenaConexion.Alias = this.tbAlias.Text;
        cadenaConexion.BaseDatos = this.tbNombreBaseDatos.Text;
        cadenaConexion.IdentificadorServidor = this.tbNombreBaseDatos.Text;
        cadenaConexion.Servidor = this.tbServidor.Text;
        cadenaConexion.NombreUsuario = this.tbUsuario.Text;
        cadenaConexion.Contrasenia = this.tbContrasenia.Text;
        cadenaConexion.Puerto = this.tbPuerto.Text;
        cadenaConexion.TipoMotorBaseDatos = (TiposMotorBaseDatos)Convert.ToInt32(radioListBaseDatos.SelectedValue);

    }
}
