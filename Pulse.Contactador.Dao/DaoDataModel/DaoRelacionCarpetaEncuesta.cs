using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using Pulse.Contactador.Dto;
using Pulse.Utils.Exceptions;

namespace Pulse.Contactador.Dao.DaoDataModel
{
    public class DaoRelacionCarpetaEncuesta
    {
        SqlMapper _mapper;
        #region Instacia SqlMapper
        SqlMapper Instance()
        {
            return ((_mapper == null) ? _mapper = MapperFactory.CrearMapper() : _mapper);
        }
        #endregion


        #region Metodos RelacionCarpetaEncuesta
        public int Create(RelacionCarpetaEncuesta relacionCarpetaEncuesta)
        {
            try
            {

                object resultado = Instance().Insert("RelacionCarpetaEncuesta.Create", relacionCarpetaEncuesta);
                return Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear el Relacion Carpeta Encuesta", ex);
            }
        }
        public List<RelacionCarpetaEncuesta> FindByCarpetaId(int id)
        {
            try
            {
                List<RelacionCarpetaEncuesta> resultado = Instance().QueryForList<RelacionCarpetaEncuesta>("RelacionCarpetaEncuesta.FindByCarpetaId", id).ToList();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar Relacion Carpeta Encuesta", ex);
            }
        }
        public void Update(RelacionCarpetaEncuesta relacionCarpetaEncuesta)
        {
            try
            {
                Instance().Update("RelacionCarpetaEncuesta.UpdateRelacionCarpetaEncuesta", relacionCarpetaEncuesta);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de actualizar datos de Relacion Carpeta Encuesta", ex);
            }
        }
        public RelacionCarpetaEncuesta FindRelacionCarpetaEncuesta(int relacionCarpetaEncuestaId)
        {
            try
            {
                return Instance().QueryForObject<RelacionCarpetaEncuesta>("RelacionCarpetaEncuesta.Find", relacionCarpetaEncuestaId);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de obtener los datos de Relacion Carpeta Encuesta", ex);
            }
        }

        public List<RelacionCarpetaEncuesta> FindRelacionesCarpetaEncuesta(int carpetaId)
        {
            return Instance().QueryForList<RelacionCarpetaEncuesta>("RelacionCarpetaEncuesta.FindByCarpetaId", carpetaId).ToList();
        }


        public void Delete(int relacionCarpetaEncuestaId)
        {
            try
            {
                Instance().Delete("RelacionCarpetaEncuesta.Delete", relacionCarpetaEncuestaId);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de eliminar Relacion Carpeta Encuesta", ex);
            }
        }
        #endregion


    }
}
