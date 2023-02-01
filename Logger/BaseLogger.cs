using System;
using System.Dynamic;

namespace Logger
{
    public abstract class BaseLogger
    {
        // Based on the assignment description, this is also considered valid
        // Although lines 11-23 is a better way to do it
        public string? ClassName { get; set; }

        //private string? _ClassName;
        //// Default for non-nullable ref type is still null
        //public required string ClassName
        //{
        //    get
        //    {
        //        return _ClassName!;
        //    }
        //    set
        //    {
        //        _ClassName = value ?? throw new ArgumentNullException(nameof(value));
        //    }
        //}

        public abstract void Log(LogLevel logLevel, string message);

    }
}
