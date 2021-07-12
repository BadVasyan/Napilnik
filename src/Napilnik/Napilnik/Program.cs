using System;
using Napilnik.OnlineShop;

namespace Napilnik
{
  internal static class Program
  {
    public static void Main(string[] args)
    {
      ShopUseCase();
    }

    private static void ShopUseCase()
    {
      Warehouse warehouse = new Warehouse();
      Shop shop = new Shop(warehouse);

      Product iPhone12 = new Product("IPhone 12", 1300);
      Product iPhone11 = new Product("IPhone 11", 999);

      warehouse.Deliver(iPhone12, 10);
      warehouse.Deliver(iPhone11, 1);

      Cart cart = shop.Cart();
      cart.Add(iPhone12, 4);
      cart.Add(iPhone11, 3);

      Console.WriteLine(cart.Order().List);
    }
  }
}