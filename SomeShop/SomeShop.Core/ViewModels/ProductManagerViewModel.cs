using SomeShop.Core.Models;
using System.Collections.Generic;

namespace SomeShop.Core.ViewModels
{
    public class ProductManagerViewModel
    {

        public Product Product { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}
