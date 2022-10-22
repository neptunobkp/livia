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
using Pulse.Utils;

namespace Pulse.Contactador.Dao.DaoDataModel
{
    public class DaoCW_CAMPANIAS
    {
        SqlMapper _mapper;
        #region Instacia SqlMapper
        SqlMapper Instance()
        {
            return ((_mapper == null) ? _mapper = MapperFactory.CrearMapper() : _mapper);
        }
        #endregion

        public int IDCAMPANIA { get; set; }
        public int IDENCUESTA { get; set; }
        public DateTime? FECHAENVIOESPERADO { get; set; }
        public int IDCONTROLADORENVIO { get; set; }
        public String GLOSAMOTIVOENVIO { get; set; }
        public int VALORMOTIVOENVIO { get; set; }
        public String NOMBRE { get; set; }
        public int IDPROPIETARIO { get; set; }
        public int TIPOPROPIETARIO { get; set; }
        public int USUARIOCREADOR { get; set; }
        public int USUARIOMODIFICADOR { get; set; }
        public DateTime FECHACREACION { get; set; }
        public DateTime FECHAMODIFICACION { get; set; }
        public String URLENCUESTA { get; set; }
        public DateTime? FECHATERMINOESPERADO { get; set; }
        public int PERIODOEJECUCION { get; set; }



        #region Metodos DaoCW_CAMPANIAS
        public int Create(Campania daoObject)
        {
            try
            {
                DaoCW_CAMPANIAS daocw_campanias = DaoCW_CAMPANIASTypeHandler.CastToDao(daoObject);
                object resultado = Instance().Insert("DaoCW_CAMPANIAS.CreateDaoCW_CAMPANIAS", daocw_campanias);
                return Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear daocw_campanias", ex);
            }
        }

        public Campania Find<T>(int id)
        {
            try
            {
                DaoCW_CAMPANIAS resultado = Instance().QueryForObject<DaoCW_CAMPANIAS>("DaoCW_CAMPANIAS.Find", id);
                Campania resultadoCasteado = DaoCW_CAMPANIASTypeHandler.CastToDto(resultado);
                return resultadoCasteado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_CAMPANIAS", ex);
            }
        }

        public List<Campania> FindAll()
        {
            try
            {
                return DaoCW_CAMPANIASTypeHandler.CastList(Instance().QueryForList<DaoCW_CAMPANIAS>("DaoCW_CAMPANIAS.FindAllDaoCW_CAMPANIAS", null));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_CAMPANIAS", ex);
            }
        }

        public void Update(Campania daoObject)
        {
            try
            {
                DaoCW_CAMPANIAS daocw_campanias = DaoCW_CAMPANIASTypeHandler.CastToDao(daoObject);
                Instance().Update("DaoCW_CAMPANIAS.UpdateDaoCW_CAMPANIAS", daocw_campanias);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de actualizar datos de daocw_campanias", ex);
            }

        }

        public void Delete(int idStatement)
        {
            try
            {
                Instance().Delete("DaoCW_CAMPANIAS.DeleteDaoCW_CAMPANIAS", idStatement);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de eliminar daocw_campanias", ex);

            }

        }

        #endregion

    }
}
