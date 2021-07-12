using System;

namespace Napilnik.OnlineShop
{
  public class ProductCell
  {
    private readonly Product _product;

    private int _availableNumber;

    public ProductCell(Product product, int availableNumber)
    {
      if (availableNumber < 0)
        throw new ArgumentOutOfRangeException(nameof(availableNumber));

      _product = product ?? throw new ArgumentNullException(nameof(product));
      _availableNumber = availableNumber;
    }

    public int AvailableNumber => _availableNumber;

    public void AddQuantity(int quantity)
    {
      if (quantity <= 0)
        throw new ArgumentOutOfRangeException(nameof(quantity));

      _availableNumber += quantity;
    }
  }
}