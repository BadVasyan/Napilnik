using System;
using System.Collections.Generic;

namespace Napilnik.OnlineShop
{
  public class Warehouse : IProductsInStock
  {
    private readonly Dictionary<string, ProductCell> _productCells = new Dictionary<string, ProductCell>();

    public void Deliver(Product product, int quantity)
    {
      if (product == null)
        throw new ArgumentNullException(nameof(product));

      if (quantity < 0)
        throw new ArgumentOutOfRangeException(nameof(quantity));

      if (ProductCellExists(product.Id))
        AddProductQuantity(product.Id, quantity);
      else
        AddNewProductCell(product, quantity);
    }

    public bool HasEnoughQuantity(string productId, int requiredQuantity)
    {
      if (ProductCellExists(productId) == false)
        return false;

      return _productCells[productId].AvailableNumber >= requiredQuantity;
    }

    private void AddProductQuantity(string productId, int quantity) =>
      _productCells[productId].AddQuantity(quantity);

    private void AddNewProductCell(Product product, int quantity) =>
      _productCells.Add(product.Id, new ProductCell(product, quantity));

    private bool ProductCellExists(string productId) =>
      _productCells.ContainsKey(productId);
  }
}