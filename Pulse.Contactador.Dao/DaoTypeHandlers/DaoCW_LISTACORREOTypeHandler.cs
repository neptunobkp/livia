using System;
using System.Collections.Generic;
using System.Text;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System.Linq;
using System.Diagnostics;
using Pulse.Contactador.Dao.DaoDataModel;
using Pulse.Contactador.Dto;

namespace Pulse.Contactador.Dao.DaoTypeHandlers
{
    public class DaoCW_LISTACORREOTypeHandler
    {
        public static ListaCorreoDestino CastToDto(DaoCW_LISTACORREO cw_listacorreo)
        {
            ListaCorreoDestino dtoObject = new ListaCorreoDestino()
            {
                Origen = new OrigenListaCorreo(),
                UsuarioCreador = new Usuario(),
                UsuarioModificador = new Usuario()
            };
            dtoObject.Id = cw_listacorreo.IDLISTACORREO;
            dtoObject.Descripcion = cw_listacorreo.DESCRIPCION;
            dtoObject.Codigo = cw_listacorreo.CODIGO;
            dtoObject.Origen.TipoOrigenListaCorreo = (TipoOrigenListaCorreo)cw_listacorreo.TIPOORIGENLISTACORREO;
            dtoObject.Origen.PathArchivoListaCorreos = cw_listacorreo.PATHARCHIVOLISTACORREOS;
            dtoObject.Origen.SentenciaSql = cw_listacorreo.SENTENCIASQL;
            dtoObject.Origen.CadenaConexion = new CadenaConexion() { Id = cw_listacorreo.IDCADENACONEXION };
            dtoObject.Origen.CargarEnDemanda = Convert.ToBoolean(cw_listacorreo.CARGARENDEMANDA);
            dtoObject.IdentificadorPropietario = cw_listacorreo.IDPROPIETARIO;
            dtoObject.TipoPropietario = (TiposPropietario)cw_listacorreo.TIPOPROPIETARIO;
            dtoObject.UsuarioCreador.Id = cw_listacorreo.USUARIOCREADOR;
            dtoObject.FechaCreacion = cw_listacorreo.FECHACREACION;
            dtoObject.UsuarioModificador.Id = cw_listacorreo.USUARIOMODIFICADOR;
            dtoObject.FechaModificacion = cw_listacorreo.FECHAMODIFICACION;
            dtoObject.Origen.RutCargadoConDigitoVerificador = Convert.ToBoolean(cw_listacorreo.RUTCARGACONDV);
            dtoObject.GrupoEncuestado = new GrupoEncuestado();
            dtoObject.GrupoEncuestado.Id = cw_listacorreo.IDGRUPO;
            dtoObject.TipoFormaContacto = (TiposFormaContacto)cw_listacorreo.TIPOFORMACONTACTO;
            return dtoObject;
        }

        public static DaoCW_LISTACORREO CastToDao(ListaCorreoDestino dtoObject)
        {
            DaoCW_LISTACORREO daoObject = new DaoCW_LISTACORREO();
            daoObject.IDLISTACORREO = dtoObject.Id;
            daoObject.DESCRIPCION = dtoObject.Descripcion;
            daoObject.CODIGO = dtoObject.Codigo;
            daoObject.TIPOORIGENLISTACORREO = (int)dtoObject.Origen.TipoOrigenListaCorreo;
            daoObject.PATHARCHIVOLISTACORREOS = dtoObject.Origen.PathArchivoListaCorreos;
            daoObject.SENTENCIASQL = dtoObject.Origen.SentenciaSql;
            if (dtoObject.Origen.CadenaConexion != null)
                daoObject.IDCADENACONEXION = dtoObject.Origen.CadenaConexion.Id;
            daoObject.CARGARENDEMANDA = Convert.ToInt32(dtoObject.Origen.CargarEnDemanda);
            daoObject.IDPROPIETARIO = dtoObject.IdentificadorPropietario;
            daoObject.TIPOPROPIETARIO = (int)dtoObject.TipoPropietario;
            if (dtoObject.UsuarioCreador != null) daoObject.USUARIOCREADOR = dtoObject.UsuarioCreador.Id;
            if (dtoObject.UsuarioModificador != null) daoObject.USUARIOMODIFICADOR = dtoObject.UsuarioModificador.Id;
            daoObject.FECHACREACION = dtoObject.FechaCreacion;
            daoObject.FECHAMODIFICACION = dtoObject.FechaModificacion;
            daoObject.RUTCARGACONDV = Convert.ToInt32(dtoObject.Origen.RutCargadoConDigitoVerificador);
            daoObject.IDGRUPO = dtoObject.GrupoEncuestado.Id;
            daoObject.TIPOFORMACONTACTO = (int)dtoObject.TipoFormaContacto;
            return daoObject;
        }

        public static List<ListaCorreoDestino> CastList(IList<DaoCW_LISTACORREO> listOfDaocw_listacorreo)
        {
            List<ListaCorreoDestino> resultado = new List<ListaCorreoDestino>();
            foreach (var cadacw_listacorreo in listOfDaocw_listacorreo)
            {
                resultado.Add(CastToDto(cadacw_listacorreo));
            }
            return resultado;
        }
    }
}
