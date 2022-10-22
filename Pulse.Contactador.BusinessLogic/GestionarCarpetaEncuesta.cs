using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dao.DaoDataModel;
using Pulse.Contactador.Dto;

namespace Pulse.Contactador.BusinessLogic
{
    public class GestionarCarpetaEncuesta
    {
        DaoCarpetaEncuesta _daoCarpetaEncuesta;
        public GestionarCarpetaEncuesta()
        {
            _daoCarpetaEncuesta = new DaoCarpetaEncuesta();
        }
        public List<CarpetaEncuesta> ObtenerCarpetaEncuestaPorCarpeta(int id)
        {
            try
            {
                return _daoCarpetaEncuesta.Find(id);
            }
            catch (Exception ex)
            {
                throw new Pulse.Utils.Exceptions.ActionableException("Error al obtener Carpetas Encuesta" + ex.Message, ex);
            }
        }
        public int AgregarCarpetaEncuesta(CarpetaEncuesta carpetaEncuesta)
        {
            try
            {
               return _daoCarpetaEncuesta.Create(carpetaEncuesta);
            }
            catch (Exception ex)
            {
                throw new Pulse.Utils.Exceptions.ActionableException("Error al crear Carpetas Encuesta" + ex.Message, ex);
            }
        }
        public void ActualizarCarpetaEncuesta(CarpetaEncuesta carpetaEncuesta)
        {
            try
            {
                _daoCarpetaEncuesta.Update(carpetaEncuesta);
            }
            catch (Exception ex)
            {
                throw new Pulse.Utils.Exceptions.ActionableException("Error al actualizar Carpeta Encuesta" + ex.Message, ex);
            }
        }

        public List<CarpetaEncuesta> ObtenerCarpetasEncuesta()
        {
            try
            {
                return _daoCarpetaEncuesta.FindAll();
            }
            catch (Exception ex)
            {
                throw new Pulse.Utils.Exceptions.ActionableException("Error al buscar Carpetas Encuesta" + ex.Message, ex);
            }
        }
    }
}
