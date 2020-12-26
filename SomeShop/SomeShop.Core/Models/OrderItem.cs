using System;

namespace SomeShop.Core.Models
{
    public class OrderItem
    {
        public OrderItem()
        {
            this.OrderItemId = Guid.NewGuid().ToString();
        }
        public string OrderItemId { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int Quanity { get; set; }
    }
}
