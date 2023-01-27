using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class ConsoleLogger : BaseLogger
    {
        private string _CreationClass { get; set; } = null!;

        public ConsoleLogger(string creationClass)
        {
            _CreationClass = creationClass;
            SetClassName(nameof(ConsoleLogger));

        }

        public override void Log(LogLevel logLevel, string message)
        {
            string fullMessage = $" {DateTime.Now} {_CreationClass} {logLevel}: {message}".Trim();
            Console.WriteLine(fullMessage);

        }
    }
}
