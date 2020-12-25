using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomeShop.Core.Contracts;
using SomeShop.Core.Models;
using SomeShop.Core.ViewModels;
using SomeShop.WebUI.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace SomeShop.WebUI.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        

        [TestMethod]
        public void IndexPageReturnsProducts()
        {
            IRepository<Product> productContext = new Mocks.MockContext<Product>();
            IRepository<ProductCategory> productCategoryContext = new Mocks.MockContext<ProductCategory>();
            // Arrange
            HomeController controller = new HomeController(productContext, productCategoryContext);

            // Act
            ViewResult result = controller.Index() as ViewResult;
            var ViewModel = (ProductListViewModel)result.ViewData.Model;
            // Assert
            Assert.AreEqual(0, ViewModel.Product.Count());
        }

        //[TestMethod]
        //public void About()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController(Productcontext, ProductCategoryContext);

        //    // Act
        //    ViewResult result = controller.About() as ViewResult;

        //    // Assert
        //    Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        //}

        //[TestMethod]
        //public void Contact()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController(Productcontext, ProductCategoryContext);

        //    // Act
        //    ViewResult result = controller.Contact() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}
    }
}
