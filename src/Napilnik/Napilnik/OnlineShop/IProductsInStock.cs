namespace Napilnik.OnlineShop
{
  public interface IProductsInStock
  {
    bool HasEnoughQuantity(string productId, int requiredQuantity);
  }
}