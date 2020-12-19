using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomeShop.Core.Contracts;
using SomeShop.Core.Models;
using SomeShop.WebUI.Controllers;
using System.Web.Mvc;

namespace SomeShop.WebUI.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private readonly IRepository<ProductCategory> ProductCategoryContext;
        private readonly IRepository<Product> Productcontext;

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(Productcontext, ProductCategoryContext);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController(Productcontext, ProductCategoryContext);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController(Productcontext, ProductCategoryContext);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
