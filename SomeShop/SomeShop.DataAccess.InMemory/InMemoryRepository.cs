using SomeShop.Core.Contracts;
using SomeShop.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace SomeShop.DataAccess.InMemory
{
    public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
    {
        ObjectCache cache = MemoryCache.Default;
        List<T> items;
        string className;

        public InMemoryRepository()
        {
            className = typeof(T).Name;
            items = cache[className] as List<T>;
            if (items == null)
            {
                items = new List<T>();

            }

        }

        public void Commit()
        {
            cache[className] = items;
        }

        public void Insert(T p)
        {
            items.Add(p);
        }

        public void Update(T p)
        {
            T p0 = items.Find(t => t.Id == p.Id);

            if (p0 != null)
            {
                p0 = p;
            }
            else
            {
                throw new System.Exception(className + " not found");
            }
        }

        public T Find(string id)
        {
            T p0 = items.Find(t => t.Id == id);
            return p0;
            //if (p0 != null)
            //{

            //}
            //else
            //{
            //    throw new System.Exception("T not found");
            //}
        }

        public IQueryable<T> Collection()
        {
            return items.AsQueryable();
        }

        public void Delete(string id)
        {
            T p0 = items.Find(t => t.Id == id);

            if (p0 != null)
            {
                items.Remove(p0);
            }
            else
            {
                throw new System.Exception("T not found");
            }

        }
    }
}
