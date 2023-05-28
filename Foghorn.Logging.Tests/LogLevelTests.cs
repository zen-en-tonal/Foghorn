using Foghorn.Log;
using Moq;
using Xunit;

namespace Foghorn.Logging.Tests;

public class LogLevelTests
{
    [Fact]
    public void When_LogLevel_sets_None__should_no_output()
    {
        // Given
        var logOutput = new Mock<ILogOutput>();
        logOutput.Setup(o => o.Write(It.IsAny<FoghornLog>()));
        var logOutputProvider = new Mock<ILogOutputProvider>();
        logOutputProvider.Setup(l => l.CreateLogOutput()).Returns(logOutput.Object);

        var logger = new FoghornLoggerBuilder("ident", "host")
            .AddLogOutput(LogLevel.None, logOutputProvider.Object)
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

    [Fact]
    public void When_LogLevel_is_less_than_or_equal_input__should_output()
    {
        // Given
        var logOutput = new Mock<ILogOutput>();
        logOutput.Setup(o => o.Write(It.IsAny<FoghornLog>()));
        var logOutputProvider = new Mock<ILogOutputProvider>();
        logOutputProvider.Setup(l => l.CreateLogOutput()).Returns(logOutput.Object);

        var logger = new FoghornLoggerBuilder("ident", "host")
            .AddLogOutput(LogLevel.Information, logOutputProvider.Object)
            .Build();

        // When
        logger.Debug("debug");
        logger.Info("info"); // should be called
        logger.Warning("warning"); // should be called

        // Then
        logOutput.Verify(o => o.Write(It.IsAny<FoghornLog>()), Times.Exactly(2));
    }
}