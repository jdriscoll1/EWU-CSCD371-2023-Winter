namespace Logger
{
    public class LogFactory
    {
        private string? _FilePath { get; set; } 


        public void ConfigureFileLogger(string filePath) {
            _FilePath = filePath; 
        }

        public BaseLogger? CreateLogger(string creationClass, string className)
        {
            if (_FilePath is null) {
                return null; 
            }
            return new FileLogger(_FilePath); 

            /*  if (className == "ConsoleLogger")
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
              
            return null!; */
        }

    }
}
