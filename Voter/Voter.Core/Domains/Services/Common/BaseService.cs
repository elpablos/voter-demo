using NLog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voter.Core.Infrastructures.Exceptions;
using Voter.Core.Utils.Results;
using Voter.Core.Utils.Validations;

namespace Voter.Core.Domains.Services.Common
{
    /// <summary>
    /// Abstraktní služba
    /// </summary>
    public abstract class BaseService
    {
        /// <summary>
        /// Logger
        /// </summary>
        public Logger Log { get; private set; }

        /// <summary>
        /// Connection string pro připojení do DB
        /// </summary>
        public string ConnectionStringName { get; set; }

        public BaseService(string connectionString = "ConnectionString")
        {
            ConnectionStringName = connectionString;
            Log = LogManager.GetLogger(GetType().FullName);
        }

        /// <summary>
        /// Získání validací z výjímky
        /// </summary>
        /// <typeparam name="T">vystupni data</typeparam>
        /// <param name="e">vyjimka</param>
        /// <param name="result">result</param>
        protected virtual void TryValidation<T>(Exception e, ModelCoreResult<T> result) where T : class
        {
            if (Validation.IsValidatationResult(e))
            {
                result.ValidationMessages = Validation.GetMessages(e);
                Log.Warn(e, "DB Validation: {0}", e.Message);
            }
            else if (Validation.IsErrorResult(e))
            {
                result.ValidationMessages = Validation.GetErrorMessages(e);
                Log.Info(e, "DB system error: {0}", e.Message);

                throw new VoterException(result.ValidationMessages.FirstOrDefault().DisplayName, e);
            }
            else
            {
                result.Exception = e;
                Log.Error(e, "DB Error: {0}\n{1}", e.Message, e.StackTrace);

                throw new AccessDeniedException(e);
            }
        }

        /// <summary>
        /// Spojení s DB - výchozí
        /// </summary>
        /// <returns></returns>
        protected virtual SqlConnection GetConnection()
        {
            return GetConnection(ConnectionStringName);
        }

        /// <summary>
        /// Spojení s DB - explicitní název ConnectionStringu
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected virtual SqlConnection GetConnection(string name)
        {
            return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[name].ConnectionString);
        }

        /// <summary>
        /// Logování SQL příkazů
        /// </summary>
        /// <param name="command"></param>
        /// <param name="data"></param>
        /// <param name="ignoreParams"></param>
        protected virtual void LogQuery(string command, object data, bool ignoreParams = false)
        {
            // TODO Doladit
            Log.Debug(Utils.Logging.LoggerHelper.QueryAsString(command, (ignoreParams ? null : data)));
        }
    }
}
