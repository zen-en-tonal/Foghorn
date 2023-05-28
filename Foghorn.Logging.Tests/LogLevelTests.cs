using Foghorn.Log;
using Moq;
using Xunit;

namespace Foghorn.Logging.Tests;

public class LogLevelTests
{
    [Fact]
    public void When_MinLogLevel_sets_None__should_no_output()
    {
        // Given
        var logOutput = new Mock<ILogOutput>();
        logOutput.Setup(o => o.Write(It.IsAny<FoghornLog>()));
        var logOutputProvider = new Mock<ILogOutputProvider>();
        logOutputProvider.Setup(l => l.CreateLogOutput()).Returns(logOutput.Object);

        var logger = new FoghornLoggerBuilder("ident", "host")
            .MinLogLevel(LogLevel.None)
            .AddLogOutput(logOutputProvider.Object)
            .Build();

        // When
        logger.Debug("debug");
        logger.Info("info");
        logger.Warning("warning");
        logger.Error("error");
        logger.Critical("critical");

        // Then
        logOutput.Verify(o => o.Write(It.IsAny<FoghornLog>()), Times.Never);
    }
}