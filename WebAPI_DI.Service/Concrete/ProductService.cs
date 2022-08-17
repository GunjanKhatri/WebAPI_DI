using DomainEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_DI.BusinessEntity;
using WebAPI_DI.Repository.Interface;
using WebAPI_DI.Service.Interface;

namespace WebAPI_DI.Service.Concrete
{
    public class ProductService : IProductService
    {
        public IProductRepository productRepository { get; set; }

        public ProductService(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }
        public bool AddProduct(ProductViewModel productViewModel)
        {
            Product product = new Product();
            product.ProductID = productViewModel.ProductID;
            product.ProductName = productViewModel.ProductName;
            product.CategoryID = productViewModel.CategoryID;
            product.UnitPrice = productViewModel.UnitPrice;

            return productRepository.AddProduct(product);
        }

        public bool DeleteProduct(int productId)
        {
            return productRepository.DeleteProduct(productId);
        }

        public List<ProductViewModel> GetProducts()
        {
            var products = productRepository.GetProducts();
            var newProducts = products.Select(y => new ProductViewModel
            {
                CategoryID = y.CategoryID.Value,
                ProductID = y.ProductID,
                ProductName = y.ProductName,
                UnitPrice = Convert.ToDecimal(y.UnitPrice)
            }).ToList();

            return newProducts;
        }

        public bool UpdateProduct(int productId, ProductViewModel productViewModel)
        {
            var product = new Product();
            product.ProductName = productViewModel.ProductName;
            product.ProductID = productViewModel.ProductID;
            product.CategoryID = productViewModel.CategoryID;
            product.UnitPrice = productViewModel.UnitPrice;

            return productRepository.UpdateProduct(productId,product);
        }
    }
}
