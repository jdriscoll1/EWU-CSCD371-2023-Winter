﻿namespace Logger
{
    public class LogFactory
    {
        private string _FilePath { get; set; } = null!; 


        public void ConfigureFileLogger(string fileLogger) {
            _FilePath = fileLogger; 
        }

        public string GetFileLoggerPath() {
            return _FilePath; 
        }

        public BaseLogger CreateLogger(string creationClass, string className)
        {


            if (className == "ConsoleLogger")
            {
                return new ConsoleLogger(creationClass);
            }
            if (_FilePath is null) {
                return null!; 
            }

            if (className == "FileLogger")
            {
                return new FileLogger(creationClass, _FilePath);
            }
            
            return null!; 
        }

    }
}