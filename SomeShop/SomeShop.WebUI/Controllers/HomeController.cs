using SomeShop.Core.Contracts;
using SomeShop.Core.Models;
using SomeShop.Core.ViewModels;
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
        public ActionResult Index(string Category=null)
        {
            ProductListViewModel vm = new ProductListViewModel();
            vm.ProductCategories = productCategoryContext.Collection().ToList();


            vm.Product =Category == null? context.Collection().ToList() :
                context.Collection().Where(p => p.Category == Category).ToList();
            return View(vm);
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