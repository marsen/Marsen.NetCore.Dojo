using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata.ShopMall;

public class CartService
{
    public int TotalPrice => ProductList.Sum(x => x.SubTotal);
    public List<CartProduct> ProductList { get; } = new();
}