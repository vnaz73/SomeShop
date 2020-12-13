using SomeShop.Core.Models;
using SomeShop.DataAccess.InMemory;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SomeShop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        ProductRepository context;
        public ProductManagerController()
        {
            context = new ProductRepository();
        }
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }
        public ActionResult Create()
        {
            Product p = new Product();
            return View(p);
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (!ModelState.IsValid) return View(p);

            context.Insert(p);
            context.Commit();

            return RedirectToAction("Index");

        }

        public ActionResult Edit(string id)
        {
            Product p0 = context.Find(id);
            if (p0 == null) return HttpNotFound();


            return View(p0);
        }

        [HttpPost]
        public ActionResult Edit(Product p, string id)
        {
            if (!ModelState.IsValid) return View(p);

            Product p0 = context.Find(id);
            if (p0 == null) return HttpNotFound();

            p0.Name = p.Name;
            p0.Description = p.Description;
            p0.Image = p.Image;
            p0.Category = p.Category;
            p0.Price = p.Price;

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