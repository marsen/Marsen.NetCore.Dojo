using System;
using Marsen.NetCore.Dojo.E2E.Tests.Kata.ShopMall;
using Marsen.NetCore.Dojo.Kata.ShopMall.Model;
using Newtonsoft.Json;

namespace Marsen.NetCore.Dojo.E2E.Tests
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var result = JsonConvert.SerializeObject(new CartController().Get());
            Console.WriteLine(result);
            /*
            var a = new Money { Value = 7, Symbol = "NTD"};
            var b = new Money { Value = 3, Symbol = "NTD"};
            var c = a * 2;
            Console.WriteLine(c.ToString());
            */
        }
    }
}