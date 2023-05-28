using System;
using System.Threading.Tasks;
using Foghorn.Log;
using Moq;
using Xunit;

namespace Foghorn.Logging.Tests;

public class ExceptionTests
{
    [Fact]
    public void When_NoThrow_called__should_not_throw_exception()
    {
        var logger = new FoghornLoggerBuilder("ident", "host")
            .AddLogOutput(LogLevel.Trace, new ThrowableOutputProvider())
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
            .AddLogOutput(LogLevel.Trace, new ThrowableOutputProvider())
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

    [Fact]
    public void When_throws_on_output__next_output_is_not_called()
    {
        var logOutput = new Mock<ILogOutput>();
        logOutput.Setup(o => o.Write(It.IsAny<FoghornLog>()));
        var logOutputProvider = new Mock<ILogOutputProvider>();
        logOutputProvider.Setup(l => l.CreateLogOutput()).Returns(logOutput.Object);

        var logger = new FoghornLoggerBuilder("ident", "host")
            .AddLogOutput(LogLevel.Trace, new ThrowableOutputProvider())
            .AddLogOutput(LogLevel.Trace, logOutputProvider.Object)
            .Build();

        Assert.Throws<Exception>(() =>
        {
            logger.Log(
                LogLevel.Debug,
                "message",
                LogAttributes.Empty);
        });
        logOutput.Verify(l => l.Write(It.IsAny<FoghornLog>()), Times.Never);
        Assert.ThrowsAsync<Exception>(() =>
        {
            return logger.LogAsync(
                LogLevel.Debug,
                "message",
                LogAttributes.Empty);
        });
        logOutput.Verify(l => l.WriteAsync(It.IsAny<FoghornLog>()), Times.Never);
    }

    class ThrowableOutput : ILogOutput
    {
        public void Dispose()
        {
            // no-op
        }

        public void Write(FoghornLog log)
        {
            throw new System.Exception();
        }

        public Task WriteAsync(FoghornLog log)
        {
            throw new System.Exception();
        }
    }

    class ThrowableOutputProvider : ILogOutputProvider
    {
        public ILogOutput CreateLogOutput()
        {
            return new ThrowableOutput();
        }
    }
}
