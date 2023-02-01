using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {

       
        public static void Error(this BaseLogger logger, string msg, params string[] args)
        {
            if (msg is null) { 
                throw new ArgumentNullException(msg);
            }
            if (logger is null) {
                throw new ArgumentNullException(logger!.ToString());
            }
            Console.WriteLine(msg);
            String errorMessage = string.Format(null, msg, args);
            logger.Log(LogLevel.Error, errorMessage);
            
        }

        public static void Warning(this BaseLogger logger, string msg, params string[] args)
        {
            if (msg is null)
            {
                throw new ArgumentNullException(msg);
            }
            if (logger is null)
            {
                throw new ArgumentNullException(logger!.ToString());
            }
            String warningMessage = string.Format(null, msg, args);
            logger.Log(LogLevel.Warning, warningMessage);

        }

        public static void Information(this BaseLogger logger, string msg, params string[] args)
        {
            if (msg is null)
            {
                throw new ArgumentNullException(msg);
            }
            if (logger is null)
            {
                throw new ArgumentNullException(logger!.ToString());
            }
            String informationMessage = string.Format(null, msg, args);
            logger.Log(LogLevel.Information, informationMessage);

        }

        public static void Debug(this BaseLogger logger, string msg, params string[] args)
        {
            if (msg is null)
            {
                throw new ArgumentNullException(msg);
            }
            if (logger is null)
            {
                throw new ArgumentNullException(logger!.ToString());
            }
            String debugMessage = string.Format(null, msg, args);
            logger.Log(LogLevel.Debug, debugMessage);

        }
    }
}
