using System;
using System.Globalization;

namespace CB.Infrastructure.Logger
{

    /// <summary>
    /// Info log model.
    /// </summary>
    public class LogModel
    {
        /// <summary>
        /// Method (function) name.
        /// </summary>
        public string Method { get; set; }
        private static CultureInfo culture = new CultureInfo("en-US");

        /// <summary>
        /// Information data.
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Time for this log.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// time in "yyyy-MM-dd HH:mm:ss:ff" to log in text file.
        /// </summary>
        public string StringTime
        {
            get
            {
                if (Time != null)
                {
                    return Time.ToString("HH:mm:ss:ff", culture);
                }
                return string.Empty;
            }
        }
    }

    /// <summary>
    /// Exception log model.
    /// </summary>
    public class LogModelException : LogModel
    {
        /// <summary>
        /// Caption message for exception.
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Line number where exception happend in file.
        /// </summary>
        public int LineNumber { get; set; }

        /// <summary>
        /// File name where exception happend.
        /// </summary>
        public string FileName { get; set; }

    }

    /// <summary>
    /// Debug log model
    /// </summary>
    public class LogModelDebug : LogModel
    {
        /// <summary>
        /// Request Ip address.
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// Request device name
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// Login username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Client name.
        /// </summary>
        public string Client { get; set; }

        /// <summary>
        /// Request url.
        /// </summary>
        public string URL { get; set; }
    }


    public class LogDebugModel
    {
        /// <summary>
        /// Request Ip address.
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// Request device name
        /// </summary>
        public string HttpMethod { get; set; }

        /// <summary>
        /// Login username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Client name.
        /// </summary>
        public string Client { get; set; }

        /// <summary>
        /// Request url.
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// Debug data
        /// </summary>
        public string Data { get; set; }
    }

    public class LogOption
    {
        public int LogLevel { get; set; }
        public string LogPath { get; set; }
        public string LogName { get; set; }
        public int AdditinalHour { get; set; }
    }
}