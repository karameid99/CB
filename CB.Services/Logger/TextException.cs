using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace CB.Infrastructure.Logger
{

    internal class TextException : ObeLogger
    {
        internal protected TextException(LogOption logOption) : base(logOption)
        {
            if (!Directory.Exists(logOption.LogPath))
                Directory.CreateDirectory(logOption.LogPath);
        }

        public override void Info(string method, string data)
        {

        }
        public override void Debug(string ip, string url, string httpMethod, string client, string username, string data)
        {

        }
        public override void Debug(Func<LogDebugModel> func)
        {

        }
        public override void LogException(Exception e, string caption = "", Action<string> ExceptionFinalMessage = null)
        {

            try
            {
                LogModelException model = new LogModelException()
                {
                    Time = DateTime.Now.AddHours(LogOption.AdditinalHour),
                };
                StringBuilder message = new StringBuilder();
                Exception temp = e;
                StackTrace st = new StackTrace(temp, true);
                do
                {
                    message.Append(temp.Message);
                    if (temp.InnerException == null)
                    {
                        // Create a StackDebug that captures
                        // filename, line number, and column
                        // information for the current thread.
                        GetMethodInfo(model, temp, st);

                        break;
                    }
                    temp = temp.InnerException;

                } while (temp != null);
                if (string.IsNullOrEmpty(model.Method))
                {
                    GetMethodInfo(model, temp, st);
                }
                model.Data = message.ToString();
                model.Caption = caption;
                ExceptionFinalMessage?.Invoke(model.Data);
                WritetoDiskAsync($"StringTime: {model.StringTime} |  Caption: {model.Caption} |  Message: {model.Data} |  FileName: {model.FileName} |  Method: {model.Method} |  LineNumber: {model.LineNumber}", "Exception");
            }
            catch { }

        }

        private static void GetMethodInfo(LogModelException model, Exception temp, StackTrace st)
        {
            if (st.FrameCount == 0)
            {
                model.FileName = "";
                model.Method = "";
                model.LineNumber = -1;
                return;
            }
            for (int i = 0; i < st.FrameCount; i++)
            {
                StackFrame sf = st.GetFrame(i);
                if (sf != null && sf.GetFileName() != null)
                {
                    model.FileName = string.Join(" => ", sf.GetFileName().Split('\\').Skip(2));
                    var method = sf.GetMethod();
                    if (method.Name == "MoveNext")
                    {

                        model.Method = method.ReflectedType.Name;
                        if (model.Method.Contains('>'))
                            model.Method = model.Method.Substring(1, model.Method.IndexOf('>') - 1);
                    }
                    else
                    {
                        model.Method = method.Name;
                    }
                    model.LineNumber = sf.GetFileLineNumber();
                    break;
                }
            }
        }

        public override void LogError(string error, string method, string caption = "")
        {

            try
            {
                LogModelException model = new LogModelException()
                {
                    Time = DateTime.Now.AddHours(LogOption.AdditinalHour),
                    Caption = caption,
                    Data = error,
                    Method = method
                };
                WritetoDiskAsync($"StringTime: {model.StringTime} |  Caption: {model.Caption} |  Message: {model.Data} |  Method: {model.Method}", "Error");
            }
            catch { }
        }
        private void WritetoDiskAsync(string text, string logLevel)
        {
            try
            {
                var lines = new List<string>() { text };
                File.AppendAllLines($"{Path.Combine(LogOption.LogPath, LogOption.LogName)} {DateTime.Now.AddHours(LogOption.AdditinalHour).ToString("yyyy-MM-dd")} - {logLevel}.txt", lines);
            }
            catch { }
        }

    }
}
