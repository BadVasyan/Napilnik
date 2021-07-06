using System;
using System.Collections.Generic;
using System.Linq;

namespace Napilnik.OnlineShop
{
  public class Cart
  {
    private readonly Dictionary<string, OrderItem> _orderItems = new Dictionary<string, OrderItem>();
    private readonly IProductsInStock _productsInStock;

    public Cart(IProductsInStock productsInStock)
    {
      _productsInStock = productsInStock;
    }

    public void Add(Product product, int quantity)
    {
      if (product == null)
        throw new ArgumentNullException(nameof(product));

      if (quantity <= 0)
        throw new ArgumentOutOfRangeException(nameof(quantity));

      if (NotEnoughProductInStock(product.Id, quantity))
      {
        DisplayNotEnoughProductMessage(product.Name);
        return;
      }

      if (OrderItemExists(product.Id))
        AddProductQuantity(product.Id, quantity);
      else
        AddNewOrderItem(product, quantity);
    }

    public Order Order()
    {
      if (IsEmpty())
        throw new InvalidOperationException("Unable to create an order: Cart is empty");

      return new Order(_orderItems.Values.ToList());
    }

    private void AddNewOrderItem(Product product, int quantity) =>
      _orderItems.Add(product.Id, new OrderItem(product, quantity));

    private void AddProductQuantity(string productId, int quantity) =>
      _orderItems[productId].AddQuantity(quantity);

    private bool OrderItemExists(string productId) =>
      _orderItems.ContainsKey(productId);

    private bool NotEnoughProductInStock(string productId, int requiredQuantity) =>
      _productsInStock.HasEnoughQuantity(productId, requiredQuantity) == false;

    private bool IsEmpty() =>
      _orderItems.Count == 0;

    private static void DisplayNotEnoughProductMessage(string productName) =>
      Console.WriteLine($"{productName} is not available in required quantity.");
  }
}