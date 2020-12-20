using SomeShop.Services;
using System.Web.Mvc;

namespace SomeShop.WebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService basketService;

        public BasketController(IBasketService basketService)
        {
            this.basketService = basketService;
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
    }
}