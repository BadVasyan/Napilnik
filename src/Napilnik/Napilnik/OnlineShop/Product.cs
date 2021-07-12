using System;

namespace Napilnik.OnlineShop
{
  public class Product
  {
    public string Id => Name;
    public string Name { get; }
    public int Price { get; }

    public Product(string name, int price)
    {
      if (price < 0)
        throw new ArgumentOutOfRangeException(nameof(price));

      if (WrongNameFormat(name))
        throw new FormatException(nameof(name));

      Name = name;
      Price = price;
    }

    private static bool WrongNameFormat(string name) =>
      SuperDuperFormatCheck(name);

    private static bool SuperDuperFormatCheck(string name) =>
      name.Length == 0;
  }
}