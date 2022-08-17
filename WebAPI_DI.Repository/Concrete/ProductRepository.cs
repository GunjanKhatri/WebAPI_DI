using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainEntity;
using WebAPI_DI.Repository.Interface;

namespace WebAPI_DI.Repository.Concrete
{
    public class ProductRepository : IProductRepository
    {
        public bool AddProduct(Product product)
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                context.Products.Add(product);
                return context.SaveChanges() > 0 ? true : false;
            }
        }

        public bool DeleteProduct(int productId)
        {
            Product product = new Product();
            using (NorthwindEntities context = new NorthwindEntities())
            {
                product = context.Products.Where(p => p.ProductID == productId).FirstOrDefault();
                context.Products.Remove(product);
                return context.SaveChanges() > 0 ? true : false;
            }
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            using(NorthwindEntities context =new NorthwindEntities())
            {
                products = context.Products.ToList();
            }
            return products;
        }

        public bool UpdateProduct(int productId, Product product)
        {
           
            using (NorthwindEntities context = new NorthwindEntities())
            {
                var productInfo = context.Products.Where(p => p.ProductID == productId).FirstOrDefault();
                productInfo.ProductName = product.ProductName;
                return context.SaveChanges() > 0 ? true : false;
            }
        }
    }
}
