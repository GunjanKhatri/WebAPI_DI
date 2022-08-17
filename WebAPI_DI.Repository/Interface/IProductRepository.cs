using DomainEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_DI.Repository.Interface
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        bool AddProduct(Product product);
        bool DeleteProduct(int productId);
        bool UpdateProduct(int productId, Product product);
    }
}
