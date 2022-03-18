using DomainLayer;
using Repository;
using System;

namespace BusinessObjectLayer
{
    public class ProductCatalog : IProductCatalog
    {
        ProductDbContext _context;
        IRepositoryOperations<Product> _repo;
        public ProductCatalog(ProductDbContext context,IRepositoryOperations<Product> repo )
        {
            _context = context;
            _repo = new RepositoryOperations<Product>(context);
        }
        public void AddProduct(Product product)
        {
            _repo.Add(product);
        }
    }
}
