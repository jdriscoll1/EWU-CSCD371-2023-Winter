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
            SetClassName(nameof(FileLogger));
           
        }

        public override void Log(LogLevel logLevel, string message)
        {
            // Gets calling method
            System.Reflection.MethodBase previousMethod = new StackTrace().GetFrame(1).GetMethod();
            string previousClass = previousMethod.ReflectedType.Name;
           
            
            string fullMessage = $" {DateTime.Now} {previousClass} {logLevel}: {message}".Trim();
            
            using (StreamWriter writer = File.AppendText(_Filepath))
            {
                writer.WriteLine(fullMessage);
                writer.Flush();
                writer.Close();
                
            }
            
          
        }
    }
}
