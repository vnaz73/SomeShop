using SomeShop.Core.Contracts;
using SomeShop.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SomeShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Product> context;
        IRepository<ProductCategory> productCategoryContext;
        public HomeController(IRepository<Product> Productcontext, IRepository<ProductCategory> ProductCategoryContext)
        {
            context = Productcontext;
            productCategoryContext = ProductCategoryContext;
        }
        public ActionResult Index()
        {
            List<Product> p = context.Collection().ToList();
            return View(p);
        }

        public ActionResult Details(string id)
        {
            var p = context.Find(id);
            if (p == null) return HttpNotFound();

            return View(p);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}