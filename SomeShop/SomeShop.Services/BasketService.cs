using SomeShop.Core.Contracts;
using SomeShop.Core.Models;
using SomeShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SomeShop.Services
{
    public class BasketService : IBasketService
    {
        public const string BasketSessionName = "eCommerceBasket";
        private readonly IRepository<Basket> basketContext;
        private readonly IRepository<Product> productContext;

        public BasketService(IRepository<Basket> BasketContext, IRepository<Product> productConetxt)
        {
            this.basketContext = BasketContext;
            this.productContext = productConetxt;
        }
        private Basket GetBasket(HttpContextBase httpContext, bool createIfNull)
        {
            HttpCookie cookie = httpContext.Request.Cookies.Get(BasketSessionName);

            Basket basket = new Basket();

            if (cookie != null)
            {
                string basketId = cookie.Value;
                if (!string.IsNullOrEmpty(basketId))
                {
                    basket = basketContext.Find(basketId);
                }
                else
                {
                    if (createIfNull)
                    {
                        basket = CreateBasket(httpContext);
                    }
                }
            }
            else
            {
                if (createIfNull)
                {
                    basket = CreateBasket(httpContext);
                }
            }

            return basket;

        }

        private Basket CreateBasket(HttpContextBase httpContext)
        {
            Basket basket = new Basket();
            basketContext.Insert(basket);
            basketContext.Commit();

            HttpCookie cookie = new HttpCookie(BasketSessionName);
            cookie.Value = basket.Id;
            cookie.Expires = DateTime.Now.AddDays(1);
            httpContext.Response.Cookies.Add(cookie);

            return basket;

        }

        public void AddToBasket(HttpContextBase httpContext, string productId)
        {

            Basket basket = GetBasket(httpContext, true);
            BasketItem item = basket.BasketItems.FirstOrDefault(i => i.productId == productId);

            if (item == null)
            {
                item = new BasketItem();
                item.BasketId = basket.Id;
                item.productId = productId;
                item.Quantity = 1;

                basket.BasketItems.Add(item);
            }
            else
            {
                item.Quantity++;
            }

            basketContext.Commit();
        }

        public void RemoveFromBasket(HttpContextBase httpContext, string productId)
        {

            Basket basket = GetBasket(httpContext, true);
            BasketItem item = basket.BasketItems.FirstOrDefault(i => i.Id == productId);

            if (item != null)
            {
                basket.BasketItems.Remove(item);
            }

            basketContext.Commit();
        }

        public IEnumerable<BasketItemViewModel> GetBasketItems(HttpContextBase httpContext)
        {
            Basket basket = GetBasket(httpContext, false);

            if (basket == null) return new List<BasketItemViewModel>();

            return (from b in basket.BasketItems
                    join p in productContext.Collection() on b.productId equals p.Id
                    select new BasketItemViewModel()
                    {
                        Id = b.Id,
                        Quantity = b.Quantity,
                        Price = p.Price,
                        Image = p.Image,
                        ProductName = p.Name

                    }

                ).ToList();

        }
        public BasketSummaryViewModel GetBasketSummary(HttpContextBase httpContext)
        {
            Basket basket = GetBasket(httpContext, false);
            BasketSummaryViewModel model = new BasketSummaryViewModel(0, 0);
            if (basket == null)
            {
                return model;
            }
            int? basketCount = (from i in basket.BasketItems
                                select i.Quantity).Sum();
            decimal? basketTotal = (from item in basket.BasketItems
                                    join p in productContext.Collection() on item.productId equals p.Id
                                    select p.Price * item.Quantity).Sum();
            model.BasketCount = basketCount ?? 0;
            model.BasketTotal = basketTotal ?? decimal.Zero;

            return model;
        }
        public void ClearBasket(HttpContextBase httpContext)
        {
            Basket basket = GetBasket(httpContext, false);
            basket.BasketItems.Clear();
            basketContext.Commit();
        }
    }
}
