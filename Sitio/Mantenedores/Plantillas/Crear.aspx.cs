using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pulse.Contactador.Dto;
using Pulse.Contactador.BusinessLogic;
using System.IO;
using System.Web.DynamicData;
using System.Text;
using System.Threading;

public partial class Mantenedores_Plantillas_Crear : PaginaBaseAutenticable
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
    }

    public bool ValidateFileDimensions()
    {
        using (System.Drawing.Image myImage = System.Drawing.Image.FromStream(uploadImagenBanner.PostedFile.InputStream))
        {
            return (myImage.Height < 200 && myImage.Width < 950);
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            validarFormulario();
            Plantilla plantilla = new Plantilla();
            plantilla.Nombre = tbNombrePlantilla.Text;
            plantilla.PathBanner = uploadImagenBanner.FileName;
            plantilla.Titulo = tbTituloPlantilla.Text;
            plantilla.CuerpoHtml = CKEditorControl1.Text;
            plantilla.PiePaginaHtml = CKEditorControl2.Text;
            plantilla.RutaArchivoCss = uploadArchivoCss.FileName;
            plantilla.FechaCreacion = DateTime.Now;
            plantilla.FechaModificacion = DateTime.Now;
            GestionadorPlantilla gestionador = new GestionadorPlantilla();
            plantilla.NombreCarpetaEstilo = this.tbNombrePlantilla.Text.Replace(" ", "_");
            gestionador.AgregarNuevaPlantilla(plantilla);
            String directorioNuevoEstilo = Path.Combine(ManejadorDirectorios.PathBandejaEstilos(Server.MapPath("~/")), plantilla.NombreCarpetaEstilo);
            Directory.CreateDirectory(directorioNuevoEstilo);
            this.uploadImagenBanner.SaveAs(Path.Combine(directorioNuevoEstilo, this.uploadImagenBanner.FileName));
            Response.Redirect("Listar.aspx?mensaje=Se ha agregado con éxito la plantilla.");
        }
        catch (ThreadAbortException) { }
        catch (Exception ex)
        {
            base.mensajeDialog(ex.Message);
        }
    }

    private void validarFormulario()
    {
        StringBuilder mensajesError = new StringBuilder();
        if (!ValidateFileDimensions()) mensajesError.AppendLine("Debe ingresar una imagen entre los rangos permitidos (950px x 200px).");
        if (string.IsNullOrEmpty(this.tbNombrePlantilla.Text)) mensajesError.AppendLine("El nombre de la plantilla es obligatorio y debe ser único.");
        if (mensajesError.Length > 1) throw new ApplicationException(mensajesError.ToString());
    }
}
