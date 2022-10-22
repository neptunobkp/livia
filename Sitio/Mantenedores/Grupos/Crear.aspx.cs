using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pulse.Contactador.BusinessLogic.Operaciones;
using Pulse.Contactador.BusinessLogic;
using Pulse.Contactador.Dto;

public partial class Mantenedores_Grupos_Crear : PaginaBaseAutenticable
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        GrupoEncuestado grupoEncuestado = new GrupoEncuestado();
        grupoEncuestado.Nombre = this.tbNombreGrupo.Text;
        new GestionarGruposEncuestado().AgregarGrupoEncuestado(grupoEncuestado);
    }

}