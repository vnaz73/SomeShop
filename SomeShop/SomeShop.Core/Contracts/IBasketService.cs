using SomeShop.Core.ViewModels;
using System.Collections.Generic;
using System.Web;

namespace SomeShop.Services
{
    public interface IBasketService
    {
        void AddToBasket(HttpContextBase httpContext, string productId);
        IEnumerable<BasketItemViewModel> GetBasketItems(HttpContextBase httpContext);
        BasketSummaryViewModel GetBasketSummary(HttpContextBase httpContext);
        void RemoveFromBasket(HttpContextBase httpContext, string productId);
        void ClearBasket(HttpContextBase httpContext);
        
    }
}