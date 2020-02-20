using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Marsen.NetCore.Dojo.Kata_JsonParser;
using Marsen.NetCore.Dojo.Kata_PickupService;
using Marsen.NetCore.TestingToolkit;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata_PickupService
{
    public class PickupServiceTests
    {
        [Fact]
        public void Case1_Query_Done_waybillNo()
        {
            var target = new PickupService();
            long storeId = 1;
            List<string> waybillNo = new List<string> {"TEST2002181800010"};
            var actual = target.GetUpdateStatus(storeId, waybillNo).FirstOrDefault().Status;
            actual.Should().Be(StatusEnum.Finish);
        }
    }
}