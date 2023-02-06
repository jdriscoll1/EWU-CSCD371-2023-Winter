namespace Logger.Tests;

public class TestLogger<T> : BaseLogger, ILogger<T>
{
    public TestLogger(string logSource) : base(logSource) { }

#pragma warning disable CA1002 // Do not expose generic lists
    public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();
#pragma warning restore CA1002 // Do not expose generic lists

    public ILogger<T> CreateLogger(in TestLoggerConfiguration configuration) => 
        new TestLogger<T>((configuration ?? throw new ArgumentNullException(nameof(configuration))).LogSource);

    ILogger<T> ILogger<T>.CreateLogger(in ILoggerConfiguration configuration) => 
        configuration is TestLoggerConfiguration testLoggerConfiguration
            ? CreateLogger(testLoggerConfiguration)
            : throw new ArgumentException("Invalid configuration type", nameof(configuration));

    public override void Log(LogLevel logLevel, string message) => LoggedMessages.Add((logLevel, message));
}

public class TestLoggerConfiguration : BaseLoggerConfiguration, ILoggerConfiguration
{
    public TestLoggerConfiguration(string logSource) : base(logSource) { }

}
