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
    public class DaoCW_PAGINAENCUESTA
    {
        SqlMapper _mapper;
        #region Instacia SqlMapper
        SqlMapper Instance()
        {
            return ((_mapper == null) ? _mapper = MapperFactory.CrearMapper() : _mapper);
        }
        #endregion

        public int IDPAGINAENCUESTA { get; set; }
        public String TITULO { get; set; }
        public String INTRODUCCIONPAGINA { get; set; }
        public String MENSAJEPIEPAGINA { get; set; }
        public String DESCRIPCIONPIEPAGINA { get; set; }
        public int NUMEROPAGINA { get; set; }
        public int IDENCUESTA { get; set; }


        #region Metodos DaoCW_PAGINAENCUESTA
        public int Create(Pagina daoObject)
        {
            try
            {
                DaoCW_PAGINAENCUESTA daocw_paginaencuesta = DaoCW_PAGINAENCUESTATypeHandler.CastToDao(daoObject);
                object resultado = Instance().Insert("DaoCW_PAGINAENCUESTA.CreateDaoCW_PAGINAENCUESTA", daocw_paginaencuesta);
                return Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear daocw_paginaencuesta", ex);
            }

        }

        public Pagina Find<T>(int id)
        {
            try
            {
                DaoCW_PAGINAENCUESTA resultado = Instance().QueryForObject<DaoCW_PAGINAENCUESTA>("DaoCW_PAGINAENCUESTA.Find", id);
                Pagina resultadoCasteado = DaoCW_PAGINAENCUESTATypeHandler.CastToDto(resultado);
                return resultadoCasteado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_PAGINAENCUESTA", ex);
            }
        }

        public List<Pagina> FindAll()
        {
            try
            {
                return DaoCW_PAGINAENCUESTATypeHandler.CastList(Instance().QueryForList<DaoCW_PAGINAENCUESTA>("DaoCW_PAGINAENCUESTA.FindAllDaoCW_PAGINAENCUESTA", null));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_PAGINAENCUESTA", ex);
            }
        }

        public void Update(Pagina daoObject)
        {
            try
            {
                DaoCW_PAGINAENCUESTA daocw_paginaencuesta = DaoCW_PAGINAENCUESTATypeHandler.CastToDao(daoObject);
                Instance().Update("DaoCW_PAGINAENCUESTA.UpdateDaoCW_PAGINAENCUESTA", daocw_paginaencuesta);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de actualizar datos de daocw_paginaencuesta", ex);
            }

        }

        public void Delete(int idStatement)
        {
            try
            {
                Instance().Delete("DaoCW_PAGINAENCUESTA.DeleteDaoCW_PAGINAENCUESTA", idStatement);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de eliminar daocw_paginaencuesta", ex);

            }

        }

        #endregion


        internal List<Pagina> FindByEncuestaId(int id)
        {
            try
            {
                return DaoCW_PAGINAENCUESTATypeHandler.CastList(Instance().QueryForList<DaoCW_PAGINAENCUESTA>("DaoCW_PAGINAENCUESTA.FindDaoCW_PAGINAENCUESTAByIDENCUESTA", id));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_PAGINAENCUESTA", ex);
            }
        }
    }
}
