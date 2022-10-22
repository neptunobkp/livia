using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using Pulse.Utils;

namespace Pulse.Contactador.Dao.DaoDataModel
{
    public class MapperFactory
    {

        public static SqlMapper CrearMapper()
        {
            string tipoBaseDatos = GestionConfiguracion.RecuperaValorParametroConfiguracion("BaseDatos");
            if (tipoBaseDatos.Equals("Oracle"))
                return PulseOracleMapper.Instance();
            if (tipoBaseDatos.Equals("SqlServer"))
                return PulseSqlServerMapper.Instance();
            throw new ApplicationException("El parametro BaseDatos se encuentra mal configurado en el archivo Web.Config");
        }
    }
}
