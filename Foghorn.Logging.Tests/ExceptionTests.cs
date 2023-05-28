using System;
using System.Threading.Tasks;
using Foghorn.Log;
using Xunit;

namespace Foghorn.Logging.Tests;

public class ExceptionTests
{
    [Fact]
    public void When_SetNoThrow__should_not_throw_exception()
    {
        var logger = new FoghornLoggerBuilder()
            .SetMinLogLevel(LogLevel.Trace)
            .AddOutput(new ThrowableOutput())
            .SetNoThrow()
            .Build();

        logger.Log(
            LogLevel.Debug,
            "ident",
            "host",
            "message",
            LogAttributes.Empty);
        logger.LogAsync(
            LogLevel.Debug,
            "ident",
            "host",
            "message",
            LogAttributes.Empty).Wait();
    }

    [Fact]
    public void When_not_SetNoThrow__should_throw_exception()
    {
        var logger = new FoghornLoggerBuilder()
            .SetMinLogLevel(LogLevel.Trace)
            .AddOutput(new ThrowableOutput())
            .Build();

        Assert.Throws<Exception>(() =>
        {
            logger.Log(
                LogLevel.Debug,
                "ident",
                "host",
                "message",
                LogAttributes.Empty);
        });
        Assert.ThrowsAsync<Exception>(() =>
        {
            return logger.LogAsync(
                LogLevel.Debug,
                "ident",
                "host",
                "message",
                LogAttributes.Empty);
        });
    }

    class ThrowableOutput : IOutput
    {
        public void Write(FoghornLog log)
        {
            throw new System.Exception();
        }

        public Task WriteAsync(FoghornLog log)
        {
            throw new System.Exception();
        }
    }
}
