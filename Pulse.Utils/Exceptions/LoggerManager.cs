using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Diagnostics;

namespace Pulse.Utils.Exceptions
{
    public class LoggerManager
    {
        public static void LogError(string mensaje, TiposCategoryLog category, Exception ex, Dictionary<string, object> parametros, string titulo)
        {
            try
            {
                string explicitCategory = _resultCategory(category);
                Logger.Write(mensaje + " " + ex.ToString() ?? "", explicitCategory, 0, 0, System.Diagnostics.TraceEventType.Error, titulo, parametros);
            }
            catch (Exception)
            {
                return;
            }
        }

        public static void LogError(string mensaje, TiposCategoryLog category, Exception ex, Dictionary<string, object> parametros)
        {
            try
            {
                string explicitCategory = _resultCategory(category);
                Logger.Write(mensaje + " " + ex.ToString() ?? "", explicitCategory, 0, 0, System.Diagnostics.TraceEventType.Error, "", parametros);
            }
            catch (Exception)
            {
                return;
            }
        }

        public static void LogError(string mensaje, TiposCategoryLog category, Exception ex)
        {
            try
            {
                string explicitCategory = _resultCategory(category);
                Logger.Write(mensaje + " " + ex.ToString() ?? "", explicitCategory, 0, 0, System.Diagnostics.TraceEventType.Error);
            }
            catch (Exception)
            {
                return;
            }
        }

        private static string _resultCategory(TiposCategoryLog category)
        {
            switch (category)
            {
                case TiposCategoryLog.General: return "General";
                case TiposCategoryLog.LogBL: return "LogBL";
                case TiposCategoryLog.LogDAO: return "LogDAO";
                case TiposCategoryLog.LogMAIL: return "LogMAIL";
                case TiposCategoryLog.LogWEB: return "LogWEB";
                default: return "General";
            }
        }

        internal static void LoggerError(Exception e)
        {
            Logger.Write(e.ToString(), "General", 0, 0, TraceEventType.Error);
        }
    }

    public enum TiposCategoryLog
    {
        General,
        LogBL,
        LogDAO,
        LogMAIL,
        LogWEB,
    }
}
