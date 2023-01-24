namespace Logger
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

        public BaseLogger CreateLogger(string className)
        {
        
            if (_FilePath is null) {
                return null!; 
            }

            if (className == "FileLogger") {
                return new FileLogger(_FilePath);
            }
            return null!; 
        }

    }
}
