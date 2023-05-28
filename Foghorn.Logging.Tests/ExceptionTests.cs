using System;
using System.Threading.Tasks;
using Foghorn.Log;
using Xunit;

namespace Foghorn.Logging.Tests;

public class ExceptionTests
{
    [Fact]
    public void When_NoThrow_called__should_not_throw_exception()
    {
        var logger = new FoghornLoggerBuilder("ident", "host")
            .MinLogLevel(LogLevel.Trace)
            .AddLogOutput(new ThrowableOutput())
            .NoThrow()
            .Build();

        logger.Log(
            LogLevel.Debug,
            "message",
            LogAttributes.Empty);
        logger.LogAsync(
            LogLevel.Debug,
            "message",
            LogAttributes.Empty).Wait();
    }

    [Fact]
    public void When_not_NoThrow__should_throw_exception()
    {
        var logger = new FoghornLoggerBuilder("ident", "host")
            .MinLogLevel(LogLevel.Trace)
            .AddLogOutput(new ThrowableOutput())
            .Build();

        Assert.Throws<Exception>(() =>
        {
            logger.Log(
                LogLevel.Debug,
                "message",
                LogAttributes.Empty);
        });
        Assert.ThrowsAsync<Exception>(() =>
        {
            return logger.LogAsync(
                LogLevel.Debug,
                "message",
                LogAttributes.Empty);
        });
    }

    class ThrowableOutput : ILogOutput
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
