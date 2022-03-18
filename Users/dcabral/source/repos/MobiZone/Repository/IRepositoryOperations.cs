using DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IRepositoryOperations<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> Get();
        Product GetById(int id);

        void Save();
    }
}
