using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    //single instance of a class -- singleton design
    public class LogHelper
    {
        public static LogHelper logger => new LogHelper();

        public void Log(LogLevel logLevel, string message)
        {
            Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")} : {logLevel} - {message}");
        }
    }
    public enum LogLevel
    {
        Error = 0,
        Info = 1,
        Debug = 2
    }
}
