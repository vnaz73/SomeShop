using SomeShop.Core.Models;
using System.Collections.Generic;

namespace SomeShop.Core.ViewModels
{
    public class ProductListViewModel
    {

        public IEnumerable<Product> Product { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}
