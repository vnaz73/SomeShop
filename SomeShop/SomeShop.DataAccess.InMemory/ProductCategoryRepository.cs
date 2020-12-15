using SomeShop.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace SomeShop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;

        public ProductCategoryRepository()
        {
            productCategories = cache["productCategories"] as List<ProductCategory>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();

            }

        }

        public void Commit()
        {
            cache["productCategories"] = productCategories;
        }

        public void Insert(ProductCategory p)
        {
            productCategories.Add(p);
        }

        public void Update(ProductCategory p)
        {
            ProductCategory p0 = productCategories.Find(t => t.Id == p.Id);

            if (p0 != null)
            {
                p0 = p;
            }
            else
            {
                throw new System.Exception("ProductCategory not found");
            }
        }

        public ProductCategory Find(string id)
        {
            ProductCategory p0 = productCategories.Find(t => t.Id == id);
            return p0;
            //if (p0 != null)
            //{

            //}
            //else
            //{
            //    throw new System.Exception("Product not found");
            //}
        }

        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }

        public void Delete(string id)
        {
            ProductCategory p0 = productCategories.Find(t => t.Id == id);

            if (p0 != null)
            {
                productCategories.Remove(p0);
            }
            else
            {
                throw new System.Exception("ProductCategory not found");
            }

        }
    }
}
