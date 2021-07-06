using System;

namespace Napilnik.OnlineShop
{
  public class OrderItem : IReadOnlyOrderItem
  {
    public OrderItem(Product product, int quantity)
    {
      if (quantity <= 0)
        throw new ArgumentOutOfRangeException(nameof(quantity));

      Product = product ?? throw new ArgumentNullException(nameof(product));
      Quantity = quantity;
    }

    public Product Product { get; }

    public int Quantity { get; private set; }

    public int Price => Quantity * Product.Price;

    public void AddQuantity(int quantity) =>
      Quantity += quantity;

    public string ToPaylinkString() =>
      $"product={Product.Name}&quantity={Quantity}&";

    public override string ToString() =>
      $"Product: {Product.Name} Quantity: {Quantity} Price: {Price}";
  }
}