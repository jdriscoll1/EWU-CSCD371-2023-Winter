using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO; 

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        
        private string _CreationClass { get; set; } = null!; 

        string _Filepath { get; set; }
           
        public FileLogger(string creationClass, string filepath) {
            _CreationClass = creationClass;
            _Filepath = filepath;
            SetClassName(nameof(FileLogger));
           
        }

        public override void Log(LogLevel logLevel, string message)
        {
            
            string fullMessage = $" {DateTime.Now} {_CreationClass} {logLevel}: {message}".Trim();
            
            using (StreamWriter writer = File.AppendText(_Filepath))
            {
                writer.WriteLine(fullMessage);
                writer.Flush();
                writer.Close();
                
            }
            
          
        }
    }
}
