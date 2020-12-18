using SomeShop.Core.Contracts;
using SomeShop.Core.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace SomeShop.DataAccess.SQL
{
    public class SQLRepository<T> : IRepository<T> where T: BaseEntity
    {
        private readonly DataContext context;
        DbSet<T> dbSet;

        public SQLRepository(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
           
        }
        public IQueryable<T> Collection()
        {
           return this.dbSet;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            T t = Find(id);
            if (context.Entry(t).State == EntityState.Detached)
                dbSet.Attach(t);

            dbSet.Remove(t);
        }

        public T Find(string id)
        {
            return dbSet.Find(id);
        }

        public void Insert(T p)
        {
            dbSet.Add(p);
        }

        public void Update(T p)
        {
            dbSet.Attach(p);
            context.Entry(p).State = EntityState.Modified;
        }
    } 
    
}
