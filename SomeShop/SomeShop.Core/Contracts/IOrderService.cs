using SomeShop.Core.Models;
using SomeShop.Core.ViewModels;
using System.Collections.Generic;

namespace SomeShop.Core.Contracts
{
    public interface IOrderService
    {
        void CreateOrder(Order order, IEnumerable<BasketItemViewModel> basketItemViewModels);
        List<Order> GetOrderList();
        Order GetOrder(string Id);
        void UpdateOrder(Order updatedOrder);
    }
}
