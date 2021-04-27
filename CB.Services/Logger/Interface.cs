using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CB.Infrastructure.Logger
{
    public interface IObeLogger
    {
        IObeLogger GetLogger();

        /// <summary>
        /// Log exception with filename, method and line number.
        /// </summary>
        /// <param name="e">The exception to be logged</param>
        /// <param name="caption">If you want to add title message for this exception</param>
        /// <param name="ExceptionFinalMessage">Delegate on final exception message</param>
        void LogException(Exception e, string caption = "", Action<string> ExceptionFinalMessage = null);

        void LogError(string error, string method, string caption = "");

        /// <summary>
        /// Write Info or information log.
        /// </summary>
        /// <param name="method">Method name or caption</param>
        /// <param name="data">The information to be logged</param>
        void Info(string method, string data);

        /// <summary>
        /// Write http request web Debug log.
        /// </summary>
        /// <param name="client">Client name</param>
        /// <param name="username">Login username</param>
        /// <param name="data">request data</param>
        void Debug(string ip, string url, string httpMethod, string client, string username, string data);

        void Debug(Func<LogDebugModel> func);

    }
    /// <summary>
    /// Write log fast in text file or Sql database.
    /// </summary>
    public class ObeLogger : IObeLogger
    {
        protected LogOption LogOption;

        /// <summary>
        /// Get Instance based on configuration.
        /// </summary>
        public IObeLogger GetLogger()
        {
            return new TextException(LogOption);
            //switch (LogOption.LogLevel)
            //{
            //    case 1:
            //        return new TextException(LogOption);
            //    case 2:
            //        return new TextInfo(LogOption);
            //    case 3:
            //        return new TextDebug(LogOption);
            //}
            //return new EmptyLog(LogOption);
        }

        public virtual void LogException(Exception e, string caption = "", Action<string> ExceptionFinalMessage = null)
        {
            throw new NotImplementedException();
        }
        public virtual void LogError(string error, string method, string caption = "")
        {
            throw new NotImplementedException();
        }
        public virtual void Info(string method, string data)
        {
            throw new NotImplementedException();
        }

        public virtual void Debug(string ip, string url, string httpMethod, string client, string username, string data)
        {
            throw new NotImplementedException();
        }
        public virtual void Debug(Func<LogDebugModel> func)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Simple constructor.
        /// </summary>
        public ObeLogger(LogOption logOption)
        {
            LogOption = logOption;
        }
        private ObeLogger()
        {

        }

    }
}
