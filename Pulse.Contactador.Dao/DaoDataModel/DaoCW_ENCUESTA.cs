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
    public class DaoCW_ENCUESTA
    {
        SqlMapper _mapper;
        #region Instacia SqlMapper
        SqlMapper Instance()
        {
            return ((_mapper == null) ? _mapper = MapperFactory.CrearMapper() : _mapper);
        }
        #endregion

        public int IDENCUESTA { get; set; }
        public int IDPLANTILLAENCUESTA { get; set; }
        public int NUMEROPAGINAS { get; set; }
        public String TITULO { get; set; }
        public String INTRODUCCION { get; set; }
        public String MENSAJEPIEPAGINA { get; set; }
        public String DESCRIPCIONPIEPAGINA { get; set; }
        public DateTime? FECHAINICIOVIGENCIA { get; set; }
        public DateTime? FECHATERMINOVIGENCIA { get; set; }
        public int? CUOTALIMITEENCUESTA { get; set; }
        public int PRIMERAPAGINACONTENIDA { get; set; }
        public int USUARIOCREADOR { get; set; }
        public DateTime FECHACREACION { get; set; }
        public int USUARIOMODIFICADOR { get; set; }
        public DateTime FECHAULTIMAMODIFICACION { get; set; }
        public int IDPROPIETARIO { get; set; }
        public int TIPOPROPIETARIO { get; set; }
        public String TIPOSERVICIO { get; set; }

        #region Metodos DaoCW_ENCUESTA
        public int Create(Encuesta daoObject)
        {
            try
            {
                DaoCW_ENCUESTA daocw_encuesta = DaoCW_ENCUESTATypeHandler.CastToDao(daoObject);
                object resultado = Instance().Insert("DaoCW_ENCUESTA.CreateDaoCW_ENCUESTA", daocw_encuesta);
                return Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear daocw_encuesta", ex);
            }
        }

        public Encuesta Find(int id)
        {
            try
            {
                DaoCW_ENCUESTA resultado = Instance().QueryForObject<DaoCW_ENCUESTA>("DaoCW_ENCUESTA.FindDaoCW_ENCUESTA", id);
                Encuesta resultadoCasteado = DaoCW_ENCUESTATypeHandler.CastToDto(resultado);
                return resultadoCasteado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_ENCUESTA", ex);
            }
        }

        public List<Encuesta> FindAll()
        {
            try
            {
                return DaoCW_ENCUESTATypeHandler.CastList(Instance().QueryForList<DaoCW_ENCUESTA>("DaoCW_ENCUESTA.FindAllDaoCW_ENCUESTA", null));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_ENCUESTA", ex);
            }
        }

        public void Update(Encuesta daoObject)
        {
            try
            {
                DaoCW_ENCUESTA daocw_encuesta = DaoCW_ENCUESTATypeHandler.CastToDao(daoObject);
                Instance().Update("DaoCW_ENCUESTA.UpdateDaoCW_ENCUESTA", daocw_encuesta);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de actualizar datos de daocw_encuesta", ex);
            }

        }

        public void Delete(int idStatement)
        {
            try
            {
                Instance().Delete("DaoCW_ENCUESTA.DeleteDaoCW_ENCUESTA", idStatement);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de eliminar daocw_encuesta", ex);
            }
        }

        #endregion


    }
}
