using System.Collections.Generic;
using System.Text;

namespace Napilnik.OnlineShop
{
  public class Order
  {
    private readonly IReadOnlyList<IReadOnlyOrderItem> _items;

    public Order(IReadOnlyList<IReadOnlyOrderItem> items)
    {
      _items = items;
    }

    public string List => GetList();

    public string Paylink => GetPaylink();

    private string GetList()
    {
      StringBuilder listBuilder = new StringBuilder();
      int totalPrice = 0;

      foreach (IReadOnlyOrderItem item in _items)
      {
        listBuilder.AppendLine(item.ToString());
        totalPrice += item.Price;
      }

      listBuilder.AppendLine($"\nTotal Price: {totalPrice}");

      return listBuilder.ToString();
    }

    private string GetPaylink()
    {
      StringBuilder paylinkBuilder = new StringBuilder();
      int totalPrice = 0;

      foreach (IReadOnlyOrderItem item in _items)
      {
        paylinkBuilder.Append(item.ToPaylinkString());
        totalPrice += item.Price;
      }

      paylinkBuilder.Append($"total_price={totalPrice}");

      return paylinkBuilder.ToString();
    }
  }
}