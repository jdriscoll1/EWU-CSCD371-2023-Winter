using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO; 

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        public string Filepath { get; set; }
           
        public FileLogger(string filepath) {
            Filepath = filepath;

           
        }

        public override void Log(LogLevel logLevel, string message)
        {
            // Check for null
            string fullMessage = $"{DateTime.Now} {ClassName} {logLevel}: {message}";
            
            using (StreamWriter writer = File.AppendText(Filepath))
            {
                writer.WriteLine(fullMessage);
                writer.Flush();
                
            }
            
          
        }
    }
}
