using SomeShop.Core.Contracts;
using SomeShop.Core.Models;
using SomeShop.Services;
using System.Web.Mvc;

namespace SomeShop.WebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService basketService;
        private readonly IOrderService orderService;

        public BasketController(IBasketService basketService, IOrderService orderService)
        {
            this.basketService = basketService;
            this.orderService = orderService;
        }
        // GET: Basket
        public ActionResult Index()
        {
            var model = basketService.GetBasketItems(this.HttpContext);
            return View(model);
        }

        public ActionResult AddToBasket(string id)
        {
            this.basketService.AddToBasket(this.HttpContext, id);
            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromBasket(string id)
        {
            this.basketService.RemoveFromBasket(this.HttpContext, id);
            return RedirectToAction("Index");
        }
        public PartialViewResult BasketSummary()
        {
            var basketSummary = basketService.GetBasketSummary(this.HttpContext);

            return PartialView(basketSummary);
        }

        [Authorize]
        public ActionResult Checkout()
        {

            return View();

            //Customer customer = customers.Collection().FirstOrDefault(c => c.Email == User.Identity.Name);

            //if (customer != null)
            //{
            //    Order order = new Order()
            //    {
            //        Email = customer.Email,
            //        City = customer.City,
            //        State = customer.State,
            //        Street = customer.Street,
            //        FirstName = customer.FirstName,
            //        Surname = customer.LastName,
            //        ZipCode = customer.ZipCode
            //    };

            //    return View(order);
            //}
            //else
            //{
            //    return RedirectToAction("Error");
            //}

        }

        [HttpPost]
        [Authorize]
        public ActionResult Checkout(Order order)
        {

            var basketItems = basketService.GetBasketItems(this.HttpContext);
            order.OrderStatus = "Order Created";
            order.Email = User.Identity.Name;

            //process payment

            order.OrderStatus = "Payment Processed";
            orderService.CreateOrder(order, basketItems);
            basketService.ClearBasket(this.HttpContext);

            return RedirectToAction("Thankyou", new { OrderId = order.Id });
        }

        public ActionResult ThankYou(string OrderId)
        {
            ViewBag.OrderId = OrderId;
            return View();
        }
    }
}