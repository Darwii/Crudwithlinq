using DomainLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class RepositoryOperations<T> : IRepositoryOperations<T>where T:class
    {
        ProductDbContext Context;
        readonly DbSet<T> dbSet;
       
        public RepositoryOperations(ProductDbContext product)
        {
            Context = product;
            dbSet = Context.Set<T>();
           
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public IEnumerable<T> Get()
        {
            return dbSet.ToList();
        }

        public T GetById(int Id)
        {

            return dbSet.Find(Id);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
