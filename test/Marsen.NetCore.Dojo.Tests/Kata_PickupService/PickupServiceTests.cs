using System;
using System.Collections.Generic;
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
        public void Case1_Just_Run()
        {
            var target = new PickupService();
            long storeId = 0;
            List<string> waybillNo = new List<string>();
            target.GetUpdateStatus(storeId, waybillNo);
        }
    }
}