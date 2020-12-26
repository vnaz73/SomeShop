using SomeShop.Core.Contracts;
using SomeShop.Core.Models;
using SomeShop.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SomeShop.Services
{
    public class OrderService :IOrderService
    {
        private readonly IRepository<Order> orderContext;

        public OrderService(IRepository<Order> orderContext)
        {
            this.orderContext = orderContext;
        }

        public void CreateOrder(Order baseOrder, IEnumerable<BasketItemViewModel> basketItems)
        {
            foreach (var item in basketItems)
            {
                baseOrder.OrderItems.Add(new OrderItem()
                {
                    ProductId = item.Id,
                    Image = item.Image,
                    Price = item.Price,
                    ProductName = item.ProductName,
                    Quanity = item.Quantity
                });
            }

            orderContext.Insert(baseOrder);
            orderContext.Commit();
        }

        public List<Order> GetOrderList()
        {
            return orderContext.Collection().ToList();
        }

        public Order GetOrder(string Id)
        {
            return orderContext.Find(Id);
        }

        public void UpdateOrder(Order updatedOrder)
        {
            orderContext.Update(updatedOrder);
            orderContext.Commit();
        }
    }
    
}
