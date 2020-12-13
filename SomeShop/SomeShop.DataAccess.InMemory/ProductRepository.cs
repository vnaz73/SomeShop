using SomeShop.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace SomeShop.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache =  MemoryCache.Default;
        List<Product> products;

        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if(products == null)
            {
                products = new List<Product>();
                
            }
            
        }

        public void Commit()
        {
            cache["products"] = products;
        }

        public void Insert(Product p)
        {
            products.Add(p);
        }

        public void Update(Product p)
        {
            Product p0 = products.Find(t => t.Id == p.Id);

            if(p0 != null)
            {
                p0 = p;
            }
            else
            {
                throw new System.Exception("Product not found");
            }
        }

        public Product Find(string id)
        {
            Product p0 = products.Find(t => t.Id == id);

            if (p0 != null)
            {
                return p0; 
            }
            else
            {
                throw new System.Exception("Product not found");
            }
        }

        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

        public void Delete(string id)
        {
            Product p0 = products.Find(t => t.Id == id);

            if (p0 != null)
            {
               products.Remove(p0);
            }
            else
            {
                throw new System.Exception("Product not found");
            }

        }
    }
}
