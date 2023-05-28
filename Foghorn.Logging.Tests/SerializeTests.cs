using System;
using Foghorn.Log;
using Xunit;
using Newtonsoft.Json;

namespace Foghorn.Logging.Tests;

public class SerializeTests
{
    [Fact]
    public void SerializeTest()
    {
        // Given
        var attr = new LogAttributes();
        attr.Add("key1", "value1");
        var log = new FoghornLog(
            "ident",
            LogLevel.Debug,
            "message",
            "host",
            DateTime.Parse("2020/01/01 00:00:00"),
            attr
        );

        // When
        var jsonString = log.SerializeJson();

        // Then
        var expectType = new
        {
            Id = "",
            Ident = "",
            LogLevel = "",
            Message = "",
            Host = "",
            PublishedAt = "",
            Attributes = new
            {
                Key1 = ""
            }
        };
        var jsonObject = JsonConvert.DeserializeAnonymousType(jsonString, expectType);

        Assert.NotEmpty(jsonObject!.Id);
        Assert.Equal("ident", jsonObject!.Ident);
        Assert.Equal("Debug", jsonObject!.LogLevel);
        Assert.Equal("message", jsonObject!.Message);
        Assert.Equal("host", jsonObject!.Host);
        Assert.Equal("2020-01-01T00:00:00", jsonObject!.PublishedAt);
        Assert.Equal("value1", jsonObject!.Attributes.Key1);
    }
}