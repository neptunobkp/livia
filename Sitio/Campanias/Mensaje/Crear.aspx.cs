using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pulse.Contactador.BusinessLogic.EnvioCorreo;
using Pulse.Contactador.Dto;
using System.Threading;
using System.Text;
using System.IO;

public partial class Campanias_Mensaje_Crear : PaginaBaseAutenticable
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

    }

    private string configurarCarpetaArchivoMensaje(int id)
    {
        return String.Format("{0}{1}", Server.MapPath("~/Bandeja/ArchivosMensaje/"), id.ToString());
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            MensajeCorreoDestino mensajeCorreoDestino = new MensajeCorreoDestino();
            mensajeCorreoDestino.CuerpoHtml = CKEditor1.Text;
            mensajeCorreoDestino.Titulo = this.tbTituloEmail.Text;
            mensajeCorreoDestino.FechaCreacion = DateTime.Now;
            mensajeCorreoDestino.FechaModificacion = DateTime.Now;
            cargarArchivosAdjuntos(mensajeCorreoDestino);
            GestionadorMensajeCorreo gestionador = new GestionadorMensajeCorreo();
            mensajeCorreoDestino.Id = gestionador.AgregarMensajeCorreo(mensajeCorreoDestino);
            if (!String.IsNullOrEmpty(mensajeCorreoDestino.ReferenciaArchivoAdjuntos)) guardarArchivos(mensajeCorreoDestino.Id);
            Response.Redirect("Listar.aspx?mensaje=Se ha creado con éxito el mensaje", true);
        }
        catch (ThreadAbortException)
        { }
        catch (Exception ex)
        {
            base.mensajeDialog(ex.Message);
        }
    }

    private void guardarArchivos(int id)
    {
        String dir = configurarCarpetaArchivoMensaje(id);
        Directory.CreateDirectory(dir);
        if (fileUpload1.HasFile) fileUpload1.SaveAs(Path.Combine(dir, fileUpload1.PostedFile.FileName));
        if (fileUpload2.HasFile) fileUpload1.SaveAs(Path.Combine(dir, fileUpload2.PostedFile.FileName));
        if (fileUpload3.HasFile) fileUpload1.SaveAs(Path.Combine(dir, fileUpload3.PostedFile.FileName));
        if (fileUpload4.HasFile) fileUpload1.SaveAs(Path.Combine(dir, fileUpload4.PostedFile.FileName));
        if (fileUpload5.HasFile) fileUpload1.SaveAs(Path.Combine(dir, fileUpload5.PostedFile.FileName));
        if (fileUpload6.HasFile) fileUpload1.SaveAs(Path.Combine(dir, fileUpload6.PostedFile.FileName));
    }



    private void cargarArchivosAdjuntos(MensajeCorreoDestino mensajeCorreoDestino)
    {
        StringBuilder builderArchivosAdjuntos = new StringBuilder();
        if (fileUpload1.HasFile) builderArchivosAdjuntos.Append(fileUpload1.PostedFile.FileName + "|");
        if (fileUpload2.HasFile) builderArchivosAdjuntos.Append(fileUpload2.PostedFile.FileName + "|");
        if (fileUpload3.HasFile) builderArchivosAdjuntos.Append(fileUpload3.PostedFile.FileName + "|");
        if (fileUpload4.HasFile) builderArchivosAdjuntos.Append(fileUpload4.PostedFile.FileName + "|");
        if (fileUpload5.HasFile) builderArchivosAdjuntos.Append(fileUpload5.PostedFile.FileName + "|");
        if (fileUpload6.HasFile) builderArchivosAdjuntos.Append(fileUpload6.PostedFile.FileName + "|");
        if (builderArchivosAdjuntos.Length > 0)
            mensajeCorreoDestino.ReferenciaArchivoAdjuntos = builderArchivosAdjuntos.ToString().Substring(0, builderArchivosAdjuntos.Length - 1);
    }


}
