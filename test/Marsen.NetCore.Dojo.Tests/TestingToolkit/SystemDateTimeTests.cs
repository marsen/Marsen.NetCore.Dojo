using System;
using Marsen.NetCore.TestingToolkit;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.TestingToolkit;

public class SystemDateTimeTests
{
    [Fact]
    public void MockUtcNow()
    {
        //arrange
        var forgottenDay = new DateTime(1989, 6, 4 , 0,0,0);
        SystemDateTime.Now = forgottenDay;
        //act
        var timestamp = new DateTimeOffset(SystemDateTime.UtcNow).ToUnixTimeSeconds();
        //assert
        Assert.Equal(612921600,timestamp);
    }
}