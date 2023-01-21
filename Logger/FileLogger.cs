using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO; 

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        string _Filepath { get; set; }
           
        public FileLogger(string filepath) {
            _Filepath = filepath;
            SetClassName("FileLogger");
           
        }

        public override void Log(LogLevel logLevel, string message)
        {
            // Gets calling method
            System.Reflection.MethodBase previousMethod = new StackTrace().GetFrame(1).GetMethod();
            string previousClass = previousMethod.ReflectedType.Name;
           
            
            string fullMessage = $" {DateTime.Now} {previousClass} {logLevel.ToString()}: {message}".Trim();
            
            using (StreamWriter writer = new StreamWriter(_Filepath))
            {
                writer.WriteLine(fullMessage);
                
            }
          
        }
    }
}
