using DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer
{
    public interface IProductCatalog
    {
        void AddProduct(Product product);
    }
}
