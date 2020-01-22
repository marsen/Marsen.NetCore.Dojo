using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata_Api_Pay
{
    public class PaymentServiceTests
    {
        [Fact]
        public void pay_should_Get_requestId()
        {
            var target = new PaymentService();
            target.Pay();
            httpClient.Received().GetAsync("https://testing.url/api/v1/requestId");
        }
    }

    public class PaymentService
    {
        public void Pay()
        {
            throw new NotImplementedException();
        }
    }
}