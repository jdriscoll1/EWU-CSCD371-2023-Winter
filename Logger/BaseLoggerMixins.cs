using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {

       
        public static void Error(string msg, int id)
        {
            if (msg is null) { 
                throw new ArgumentNullException("msg");
            }
            string fileName = "C:\\Users\\Jordan\\test-folder\\School\\Classes\\371.2\\log.txt"; 
            FileLogger logger = new FileLogger(fileName); 
            String errorMessage = String.Format(msg, id);
            logger.Log(LogLevel.Error, errorMessage);
            
        }

        /*
        public static class StringHelper
        {
            public static string AppendEllipses(this string input)
            {
                return $"{input}...";
            }

        }
        */
    }
}
