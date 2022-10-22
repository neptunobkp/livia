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
    public class DaoCW_USUARIOEXTERNOTypeHandler
    {
        public static Usuario CastToDto(DaoCW_USUARIOEXTERNO cw_usuarioexterno)
        {
            Usuario dtoObject = new Usuario();
            dtoObject.Id = cw_usuarioexterno.IDUSUARIOEXTERNO;
            dtoObject.Rut = cw_usuarioexterno.RUT;
            dtoObject.Nombre = cw_usuarioexterno.NOMBRES;
            dtoObject.Telefono = cw_usuarioexterno.TELEFONO;
            dtoObject.Celular = cw_usuarioexterno.CELULAR;
            dtoObject.NombreIngreso = cw_usuarioexterno.NOMBREINGRESO;
            dtoObject.Clave = cw_usuarioexterno.CLAVE;
            dtoObject.TipoEstadoEntidad = (TiposEstadoEntidad)cw_usuarioexterno.TIPOESTADOENTIDAD;
            dtoObject.Correo = cw_usuarioexterno.CORREO;
            return dtoObject;
        }

        public static DaoCW_USUARIOEXTERNO CastToDao(Usuario dtoObject)
        {
            DaoCW_USUARIOEXTERNO daoObject = new DaoCW_USUARIOEXTERNO();
            daoObject.IDUSUARIOEXTERNO = dtoObject.Id;
            daoObject.RUT = dtoObject.Rut;
            daoObject.NOMBRES = dtoObject.Nombre;
            daoObject.TELEFONO = dtoObject.Telefono;
            daoObject.CELULAR = dtoObject.Celular;
            daoObject.NOMBREINGRESO = dtoObject.NombreIngreso;
            daoObject.CLAVE = dtoObject.Clave;
            daoObject.TIPOESTADOENTIDAD = (int)dtoObject.TipoEstadoEntidad;
            daoObject.CORREO = dtoObject.Correo;
            return daoObject;
        }

        public static List<Usuario> CastList(IList<DaoCW_USUARIOEXTERNO> listOfDaocw_usuarioexterno)
        {
            List<Usuario> resultado = new List<Usuario>();
            foreach (var cadacw_usuarioexterno in listOfDaocw_usuarioexterno)
            {
                resultado.Add(CastToDto(cadacw_usuarioexterno));
            }
            return resultado;
        }
    }
}
