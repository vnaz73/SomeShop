using SomeShop.Core.Models;
using SomeShop.DataAccess.InMemory;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SomeShop.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        InMemoryRepository<ProductCategory> context;
        public ProductCategoryManagerController()
        {
            context = new InMemoryRepository<ProductCategory>();
        }
        // GET: Product
        public ActionResult Index()
        {
            List<ProductCategory> products = context.Collection().ToList();
            return View(products);
        }
        public ActionResult Create()
        {
            ProductCategory p = new ProductCategory();
            return View(p);
        }
        [HttpPost]
        public ActionResult Create(ProductCategory p)
        {
            if (!ModelState.IsValid) return View(p);

            context.Insert(p);
            context.Commit();

            return RedirectToAction("Index");

        }

        public ActionResult Edit(string id)
        {
            ProductCategory p0 = context.Find(id);
            if (p0 == null) return HttpNotFound();


            return View(p0);
        }

        [HttpPost]
        public ActionResult Edit(ProductCategory p, string id)
        {
            if (!ModelState.IsValid) return View(p);

            ProductCategory p0 = context.Find(id);
            if (p0 == null) return HttpNotFound();

            p0.Category = p.Category;
           

            context.Commit();

            return RedirectToAction("Index");

        }

        public ActionResult Delete(string id)
        {
            ProductCategory p0 = context.Find(id);
            if (p0 == null) return HttpNotFound();


            return View(p0);

        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            ProductCategory p0 = context.Find(id);
            if (p0 == null) return HttpNotFound();

            context.Delete(id);
            context.Commit();

            return RedirectToAction("Index");

        }
    }
}