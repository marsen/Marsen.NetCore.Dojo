using System;
using Marsen.NetCore.Dojo.E2E.Tests.Kata.ShopMall;
using Newtonsoft.Json;

namespace Marsen.NetCore.Dojo.E2E.Tests
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var result = JsonConvert.SerializeObject(new CartController().Get());
            Console.WriteLine(result);
        }
    }
}