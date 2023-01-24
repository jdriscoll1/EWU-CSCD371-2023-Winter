using System.Dynamic;

namespace Logger
{
    public abstract class BaseLogger
    {
        private string _ClassName { get; set; } = null!;

        public void SetClassName(string className) {
            _ClassName = className; 
        }

        public string GetClassName() {
            return _ClassName; 
        }
        public abstract void Log(LogLevel logLevel, string message);

    }
}
