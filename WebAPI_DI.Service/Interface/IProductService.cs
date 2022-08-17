using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_DI.BusinessEntity;

namespace WebAPI_DI.Service.Interface
{
    public interface IProductService
    {
        List<ProductViewModel> GetProducts();

        bool AddProduct(ProductViewModel productViewModel);


        bool DeleteProduct(int productId);

        bool UpdateProduct(int productId, ProductViewModel productViewModel);
    }
}
