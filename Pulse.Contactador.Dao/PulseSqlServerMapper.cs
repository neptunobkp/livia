using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper.Configuration;
using System.Collections.Specialized;
using System.Xml;
using IBatisNet.Common.Utilities;
using IBatisNet.DataMapper;
using IBatisNet.Common;
using System.Diagnostics;
using System.Configuration;
using Pulse.Utils;
using Pulse.Utils.Exceptions;
using System.Data;
using System.Data.Common;
using Microsoft.SqlServer.Server;

namespace Pulse.Contactador.Dao
{
    public sealed class PulseSqlServerMapper
    {
        private static volatile SqlMapper _Mapper = null;


        private static void InitMapper()
        {
            try
            {
                string cadenaConexion = GestionConfiguracion.RecuperaCadenaConexionEnCurso("contactadorDB");
                NameValueCollection properties = new NameValueCollection();
                properties.Add("connectionString", cadenaConexion);
                DomSqlMapBuilder builder = new DomSqlMapBuilder();
                builder.Properties = properties;
                XmlDocument sqlMapConfig = Resources.GetEmbeddedResourceAsXmlDocument("Config.sqlMapSqlServer.config, Pulse.Contactador.Dao");
                _Mapper = builder.Configure(sqlMapConfig) as SqlMapper;
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un problema en la configuración de ibatis", ex);
            }
        }
        public static SqlMapper Instance()
        {
            if (_Mapper == null)
            {
                lock (typeof(SqlMapper))
                {
                    if (_Mapper == null)
                    {
                        InitMapper();
                    }
                }
            }
            return _Mapper;
        }

        public static ISqlMapper Get()
        {
            return Instance();
        }
    }
}
