using Dapper;
using System;
using System.Reflection;
using System.Text;

namespace Voter.Core.Utils.Logging
{
    /// <summary>
    /// Helper pro usnadnění práce s logováním
    /// </summary>
    public static class LoggerHelper
    {
        /// <summary>
        /// Pomocna fce pro sestaveni volaneho dotazu
        /// </summary>
        /// <param name="proc"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string QueryAsString(string proc, object data)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("exec {0}", proc);

            int length = sb.ToString().Length;

            if (data is DynamicParameters)
            {
                var param = (DynamicParameters)data;
                foreach (var name in param.ParameterNames)
                {
                    var pValue = param.Get<dynamic>(name);
                    if (pValue != null)
                    {
                        Type type = pValue.GetType();
                        AppendParam(sb, name, pValue, type);
                    }
                    else
                    {
                        sb.AppendFormat(" @{0}=@{0},", name);
                    }
                }
            }
            else if (data != null)
            {
                Type type = data.GetType();
                foreach (var prop in type.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                {
                    AppendParam(sb, prop.Name, prop.GetValue(data), prop.PropertyType);
                }
            }

            // odstraneni posledni carky
            if (sb.ToString().Length > length)
            {
                sb.Remove(sb.ToString().Length - 1, 1);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Přidej parametr k logu
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        private static void AppendParam(StringBuilder sb, string name, object value, Type type)
        {
            if (value == null)
            {
                sb.AppendFormat(" @{0}=null,", name);
            }
            else
            {
                if (type == typeof(DateTime))
                    sb.AppendFormat(" @{0}='{1}',", name, ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss.fff"));
                else if (type == typeof(bool))
                    sb.AppendFormat(" @{0}={1},", name, (bool)value ? 1 : 0);
                else if (type == typeof(int))
                    sb.AppendFormat(" @{0}={1},", name, value);
                else if (type == typeof(Guid))
                    sb.AppendFormat(" @{0}='{1}',", name, value);
                else
                    sb.AppendFormat(" @{0}=N'{1}',", name, value.ToString());

            }
        }
    }
}
