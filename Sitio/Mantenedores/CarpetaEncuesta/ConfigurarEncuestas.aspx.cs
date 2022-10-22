using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pulse.Contactador.Dto;
using Pulse.Contactador.BusinessLogic;
using Pulse.Utils.Exceptions;
using Telerik.Web.UI;
using Pulse.Utils.WebUtils.Helpers;
using Pulse.Contactador.Dao.DaoDataModel;

public partial class Mantenedores_CarpetaEncuesta_ConfigurarEncuestas : PaginaBaseAutenticable
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        if (!String.IsNullOrEmpty(Request.QueryString["mensaje"]))
            base.mensajeDialog(Request.QueryString["mensaje"]);
        LlenarGrupos();
        LlenarListaEncuestasSeleccionadas();
    }
    private void LlenarGrupos()
    {
        try
        {
            DropDownListHelper.PoblarDropDownList<GrupoEncuestado>(new GestionarGruposEncuestado().ObtenerGrupos(), "Seleccione Grupo", "Id", "Nombre", this.ddlGrupo);
        }
        catch (Exception)
        {
            throw;
        }
    }
    private void LlenarListaEncuestasSeleccionadas()
    {
        try
        {
            List<Encuesta> encuestas = new List<Encuesta>();
            List<Encuesta> encuestasListas = new List<Encuesta>();
            List<RelacionCarpetaEncuesta> relacionEncuestaCarpeta = new List<RelacionCarpetaEncuesta>();
            encuestas = new GestionadorEncuesta().ObtenerTodasLasEncuestas();
            string carpetaId = Request.QueryString["carpetaId"];
            relacionEncuestaCarpeta = new GestionarRelacionCarpetaEncuesta().ObtenerRelacionCarpetaEncuestaPorCarpeta(Convert.ToInt32(carpetaId));
            encuestas = encuestas.Where(t => relacionEncuestaCarpeta.Any(p => p.Encuesta.Id == t.Id)).ToList();
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
        DaoTransacciones transacciones = new DaoTransacciones();
        try
        {
            transacciones.IniciarTransaccion();
            new GestionarItemCarpetaEncuesta().EliminarItemsCarpetaEncuestaPorGrupoYCarpeta(this.ddlGrupo.SelectedValue, Request.QueryString["carpetaId"]);
            foreach (GridItem item in radGridEncuestas.Items)
            {
                HiddenField id = item.FindControl("hfId") as HiddenField;
                string itemencuestaId = id.Value;
                ItemCarpetaEncuesta itemCarpeta = new ItemCarpetaEncuesta();
                RadioButtonList rbList = item.FindControl("rblEstados") as RadioButtonList;
                int estadoId = Convert.ToInt32(rbList.SelectedValue);
                if (estadoId != (int)TiposEstadoCarpetaEncuesta.Indefinido)
                {
                    itemCarpeta.Encuesta = new Encuesta() { Id = Convert.ToInt32(itemencuestaId) };
                    itemCarpeta.TipoEstadoCarpetaEncuesta = (TiposEstadoCarpetaEncuesta)estadoId;
                    itemCarpeta.GrupoEncuestado = new GrupoEncuestado() { Id = Convert.ToInt32(this.ddlGrupo.SelectedValue) };
                    itemCarpeta.CarpetaEncuesta = new CarpetaEncuesta() { Id = Convert.ToInt32(Request.QueryString["carpetaId"]) };
                    new GestionarItemCarpetaEncuesta().AgregarItemCarpetaEncuesta(itemCarpeta);
                }
            }
            base.mensajeDialog("Se ha guardado la configuracion seleccionada");
            transacciones.ComprometerTransaccion();
        }
        catch (Exception ex)
        {
            transacciones.DeshacerTransaccion();
            base.mensajeDialog(ex.Message);
        }
    }
}
