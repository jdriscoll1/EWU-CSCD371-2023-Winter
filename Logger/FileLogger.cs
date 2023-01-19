using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        string _Filepath { get; set; }
        public DateTime _DateTime { get; set; }
        public FileLogger(string filepath) {
            _Filepath = filepath;
            _DateTime = new DateTime(); 
        }
        

        public override void Log(LogLevel logLevel, string message)
        {
            throw new NotImplementedException();
        }
    }
}
