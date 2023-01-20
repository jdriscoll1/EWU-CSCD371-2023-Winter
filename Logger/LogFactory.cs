namespace Logger
{
    public class LogFactory
    {
        private string _FactoryName { get; set; }
        private string _FilePath { get; set; }

        public string getFactoryName() {
            return _FactoryName;
        }
        public void setFactoryName(string factoryName) {
            _FactoryName = factoryName;
        }

        public void ConfigureFileLogger(string fileLogger) {
            _FilePath = fileLogger; 
        }

        public string GetFileLoggerPath() {
            return _FilePath; 
        }

        public BaseLogger CreateLogger(string className)
        {

            if (className == "FileLogger") {
                return new FileLogger(_FilePath);
            }
            return null; 
        }

    }
}
