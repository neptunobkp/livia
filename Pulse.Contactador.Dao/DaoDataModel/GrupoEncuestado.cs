using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using Pulse.Contactador.Dto;
using Pulse.Utils.Exceptions;

namespace Pulse.Contactador.Dao.DaoDataModel
{
    public class DaoGrupoEncuestado
    {
        SqlMapper _mapper;
        #region Instacia SqlMapper
        SqlMapper Instance()
        {
            return ((_mapper == null) ? _mapper = MapperFactory.CrearMapper() : _mapper);
        }
        #endregion


        #region Metodos DaoGrupoEncuestado
        public int Create(GrupoEncuestado grupoEncuestado)
        {
            try
            {

                object resultado = Instance().Insert("GrupoEncuestado.Create", grupoEncuestado);
                return Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear el grupo", ex);
            }

        }

        public GrupoEncuestado FindByNombre(String nombre)
        {
            try
            {
                GrupoEncuestado resultado = Instance().QueryForObject<GrupoEncuestado>("GrupoEncuestado.FindByNombre", nombre);
                return resultado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar un grupo por nombre: " + nombre, ex);
            }
        }

        public List<GrupoEncuestado> FindAll()
        {
            try
            {
                List<GrupoEncuestado> resultado = Instance().QueryForList<GrupoEncuestado>("GrupoEncuestado.FindAll", null).ToList();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar los grupos", ex);
            }
        }

        #endregion


    }
}
