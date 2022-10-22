using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pulse.Contactador.BusinessLogic.Operaciones;
using Pulse.Contactador.Dto;
using Pulse.Contactador.BusinessLogic;
using Telerik.Web.UI;
using Pulse.Utils.Exceptions;

public partial class Mantenedores_CarpetaEncuesta_Crear : PaginaBaseAutenticable
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        LlenarListaEncuestas();
    }
    private void LlenarListaEncuestas()
    {
        try
        {
            List<Encuesta> encuestas = new List<Encuesta>();
            encuestas = new GestionadorEncuesta().ObtenerTodasLasEncuestas();
            radGridEncuestas.DataSource = encuestas;
            radGridEncuestas.DataBind();
            if (encuestas.Count > 0)
                this.btnGuardar.Visible = true;
        }
        catch (ActionableException ex)
        {
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            CarpetaEncuesta carpeta = new CarpetaEncuesta();
            carpeta.Nombre = this.tbNombre.Text;
            int carpetaId = new GestionarCarpetaEncuesta().AgregarCarpetaEncuesta(carpeta);
            foreach (GridItem item in radGridEncuestas.Items)
            {
                CheckBox checkboxSeleccionable = item.FindControl("checkSeleccionar") as CheckBox;
                if (checkboxSeleccionable.Checked)
                {
                    RelacionCarpetaEncuesta relacionCarpetaEncuesta = new RelacionCarpetaEncuesta();
                    relacionCarpetaEncuesta.CarpetaEncuesta = new CarpetaEncuesta() { Id = carpetaId };
                    relacionCarpetaEncuesta.Encuesta = new Encuesta() { Id = Convert.ToInt32(checkboxSeleccionable.CssClass) };
                    new GestionarRelacionCarpetaEncuesta().AgregarRelacionCarpetaEncuesta(relacionCarpetaEncuesta);
                }
            }
            Response.Redirect("ConfigurarEncuestas.aspx?carpetaId=" + carpetaId + "&mensaje=Se ha guardado con éxito la Carpeta Encuesta.", true);

        }
        catch (Exception ex)
        {
            base.mensajeDialog(ex.Message);
        }
    }
}
