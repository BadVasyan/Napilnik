namespace Napilnik.OnlineShop
{
  public interface IReadOnlyOrderItem
  {
    Product Product { get; }
    int Quantity { get; }
    int Price { get; }
    string ToPaylinkString();
  }
}