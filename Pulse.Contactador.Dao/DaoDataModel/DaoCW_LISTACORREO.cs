using System;
using System.Collections.Generic;
using System.Text;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System.Linq;
using System.Diagnostics;
using Pulse.Contactador.Dto;
using Pulse.Contactador.Dao.DaoTypeHandlers;
using Pulse.Utils.Exceptions;

namespace Pulse.Contactador.Dao.DaoDataModel
{
    public class DaoCW_LISTACORREO
    {
        SqlMapper _mapper;
        #region Instacia SqlMapper
        SqlMapper Instance()
        {
            return ((_mapper == null) ? _mapper = MapperFactory.CrearMapper() : _mapper);
        }
        #endregion

        public int IDLISTACORREO { get; set; }
        public String DESCRIPCION { get; set; }
        public String CODIGO { get; set; }
        public int TIPOORIGENLISTACORREO { get; set; }
        public String PATHARCHIVOLISTACORREOS { get; set; }
        public String SENTENCIASQL { get; set; }
        public int IDCADENACONEXION { get; set; }
        public int CARGARENDEMANDA { get; set; }
        public int IDPROPIETARIO { get; set; }
        public int TIPOPROPIETARIO { get; set; }
        public int USUARIOCREADOR { get; set; }
        public DateTime FECHACREACION { get; set; }
        public int USUARIOMODIFICADOR { get; set; }
        public DateTime FECHAMODIFICACION { get; set; }
        public int RUTCARGACONDV { get; set; }
        public int IDGRUPO { get; set; }
        public int TIPOFORMACONTACTO { get; set; }


        #region Metodos DaoCW_LISTACORREO
        public int Create(ListaCorreoDestino daoObject)
        {
            try
            {
                DaoCW_LISTACORREO daocw_listacorreo = DaoCW_LISTACORREOTypeHandler.CastToDao(daoObject);
                object resultado = Instance().Insert("DaoCW_LISTACORREO.CreateDaoCW_LISTACORREO", daocw_listacorreo);
                return Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear daocw_listacorreo", ex);
            }
        }

        public ListaCorreoDestino Find(int id)
        {
            try
            {
                DaoCW_LISTACORREO resultado = Instance().QueryForObject<DaoCW_LISTACORREO>("DaoCW_LISTACORREO.FindDaoCW_LISTACORREO", id);
                ListaCorreoDestino resultadoCasteado = DaoCW_LISTACORREOTypeHandler.CastToDto(resultado);
                return resultadoCasteado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_LISTACORREO", ex);
            }
        }

        public ListaCorreoDestino FindByGrupoId(int id)
        {
            try
            {
                DaoCW_LISTACORREO resultado = Instance().QueryForObject<DaoCW_LISTACORREO>("DaoCW_LISTACORREO.FindByIDGrupo", id);
                ListaCorreoDestino resultadoCasteado = DaoCW_LISTACORREOTypeHandler.CastToDto(resultado);
                return resultadoCasteado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_LISTACORREO", ex);
            }
        }


        public List<ListaCorreoDestino> FindAll()
        {
            try
            {
                return DaoCW_LISTACORREOTypeHandler.CastList(Instance().QueryForList<DaoCW_LISTACORREO>("DaoCW_LISTACORREO.FindAllDaoCW_LISTACORREO", null));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_LISTACORREO", ex);
            }
        }



        public void Update(ListaCorreoDestino daoObject)
        {
            try
            {
                DaoCW_LISTACORREO daocw_listacorreo = DaoCW_LISTACORREOTypeHandler.CastToDao(daoObject);
                Instance().Update("DaoCW_LISTACORREO.UpdateDaoCW_LISTACORREO", daocw_listacorreo);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de actualizar datos de daocw_listacorreo", ex);
            }

        }

        public void Delete(int idStatement)
        {
            try
            {
                Instance().Delete("DaoCW_LISTACORREO.DeleteDaoCW_LISTACORREO", idStatement);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de eliminar daocw_listacorreo", ex);

            }

        }

        #endregion

    }
}
