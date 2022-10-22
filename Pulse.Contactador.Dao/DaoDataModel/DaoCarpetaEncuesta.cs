using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using Pulse.Contactador.Dto;
using Pulse.Utils.Exceptions;

namespace Pulse.Contactador.Dao.DaoDataModel
{
    public class DaoCarpetaEncuesta
    {
        SqlMapper _mapper;
        #region Instacia SqlMapper
        SqlMapper Instance()
        {
            return ((_mapper == null) ? _mapper = MapperFactory.CrearMapper() : _mapper);
        }
        #endregion


        #region Metodos CarpetaEncuesta
        public int Create(CarpetaEncuesta CarpetaEncuesta)
        {
            try
            {
                object resultado = Instance().Insert("CarpetaEncuesta.Create", CarpetaEncuesta);
                return Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear el Carpeta Encuesta", ex);
            }
        }
        public List<CarpetaEncuesta> Find(int id)
        {
            try
            {
                List<CarpetaEncuesta> resultado = Instance().QueryForList<CarpetaEncuesta>("CarpetaEncuesta.FindCarpetaEncuesta", id).ToList();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar Carpetas Encuesta", ex);
            }
        }
        public void Update(CarpetaEncuesta carpetaEncuesta)
        {
            try
            {
                Instance().Update("CarpetaEncuesta.UpdateCarpetaEncuesta", carpetaEncuesta);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de actualizar datos de Carpeta Encuesta", ex);
            }
        }
        public List<CarpetaEncuesta> FindAll()
        {
            try
            {
                List<CarpetaEncuesta> resultado = Instance().QueryForList<CarpetaEncuesta>("CarpetaEncuesta.FindAll", null).ToList();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de buscar Carpetas Encuesta", ex);
            }
        }
        #endregion

    }
}
