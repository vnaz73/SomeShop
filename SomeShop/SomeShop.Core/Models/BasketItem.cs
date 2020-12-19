namespace SomeShop.Core.Models
{
    public class BasketItem : BaseEntity
    {
        public string BasketId { get; set; }
        public string productId { get; set; }
        public int Quantity { get; set; }
    }
}
