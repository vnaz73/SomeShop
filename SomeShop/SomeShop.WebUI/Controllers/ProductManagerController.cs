using SomeShop.Core.Contracts;
using SomeShop.Core.Models;
using SomeShop.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SomeShop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        IRepository<Product> context;
        IRepository<ProductCategory> productCategoryContext;
        public ProductManagerController(IRepository<Product> Productcontext, IRepository<ProductCategory> ProductCategoryContext)
        {
            context = Productcontext;
            productCategoryContext = ProductCategoryContext;
        }
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }
        public ActionResult Create()
        {
            ProductManagerViewModel vm = new ProductManagerViewModel();

            vm.Product = new Product();
            vm.ProductCategories = productCategoryContext.Collection();
            return View(vm);
        }
        [HttpPost]
        public ActionResult Create(ProductManagerViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            context.Insert(vm.Product);
            context.Commit();

            return RedirectToAction("Index");

        }

        public ActionResult Edit(string id)
        {
            Product p0 = context.Find(id);
            if (p0 == null) return HttpNotFound();

            ProductManagerViewModel vm = new ProductManagerViewModel();

            vm.Product = p0;
            vm.ProductCategories = productCategoryContext.Collection();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(ProductManagerViewModel vm, string id)
        {
            if (!ModelState.IsValid) return View(vm);

            Product p0 = context.Find(id);
            if (p0 == null) return HttpNotFound();

            p0.Name = vm.Product.Name;
            p0.Description = vm.Product.Description;
            p0.Image = vm.Product.Image;
            p0.Category = vm.Product.Category;
            p0.Price = vm.Product.Price;

            context.Commit();

            return RedirectToAction("Index");

        }

        public ActionResult Delete(string id)
        {
            Product p0 = context.Find(id);
            if (p0 == null) return HttpNotFound();

           
            return View(p0);

        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete( string id)
        {
            Product p0 = context.Find(id);
            if (p0 == null) return HttpNotFound();

            context.Delete(id);
            context.Commit();

            return RedirectToAction("Index");

        }
    }
}