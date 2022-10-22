using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using Pulse.Contactador.Dto;
using Pulse.Utils.Exceptions;
using System.Collections;

namespace Pulse.Contactador.Dao.DaoDataModel
{
    public class DaoItemCarpetaEncuesta
    {
        SqlMapper _mapper;
        #region Instacia SqlMapper
        SqlMapper Instance()
        {
            return ((_mapper == null) ? _mapper = MapperFactory.CrearMapper() : _mapper);
        }
        #endregion


        #region Metodos ItemCarpetaEncuesta
        public int Create(ItemCarpetaEncuesta itemCarpetaEncuesta)
        {
            try
            {

                object resultado = Instance().Insert("ItemCarpetaEncuesta.Create", itemCarpetaEncuesta);
                return Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear el Item Carpeta Encuesta", ex);
            }
        }
        public List<ItemCarpetaEncuesta> FindByCarpetaId(int id)
        {
            try
            {
                List<ItemCarpetaEncuesta> resultado = Instance().QueryForList<ItemCarpetaEncuesta>("ItemCarpetaEncuesta.FindByCarpetaId", id).ToList();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar Item Carpeta Encuesta", ex);
            }
        }
        public void Update(ItemCarpetaEncuesta itemCarpetaEncuesta)
        {
            try
            {
                Instance().Update("ItemCarpetaEncuesta.UpdateItemCarpetaEncuesta", itemCarpetaEncuesta);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de actualizar datos de Item Carpeta Encuesta", ex);
            }
        }
        public ItemCarpetaEncuesta FindItemCarpetaEncuesta(int itemCarpetaEncuestaId)
        {
            try
            {
                return Instance().QueryForObject<ItemCarpetaEncuesta>("ItemCarpetaEncuesta.Find", itemCarpetaEncuestaId);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de obtener los datos de Item Carpeta Encuesta", ex);
            }
        }
        public void Delete(int itemCarpetaEncuestaId)
        {
            try
            {
                Instance().Delete("ItemCarpetaEncuesta.Delete", itemCarpetaEncuestaId);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de eliminar Item Carpeta Encuesta", ex);
            }
        }
        public void DeleteByGrupoYCarpeta(string grupoId, string carpetaId)
        {
            try
            {
                Hashtable hashTable = new Hashtable();
                hashTable.Add("grupo", grupoId);
                hashTable.Add("carpeta", carpetaId);
                Instance().Delete("ItemCarpetaEncuesta.DeleteByGrupoYCarpeta", hashTable);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de eliminar Item Carpeta Encuesta", ex);
            }
        }
        #endregion



    }
}
