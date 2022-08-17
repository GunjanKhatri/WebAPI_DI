using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebAPI_DI.BusinessEntity;
using WebAPI_DI.Service.Interface;
using WebAPI_DI.Filter;

namespace WebAPI_DI.Controllers
{     [ValidateModelStateFilter]
    [System.Web.Http.RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        public IProductService productService { get; set; }
        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        
        // GET: Product
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("getProduct")]
        public List<ProductViewModel> getAllProducts()
        {
            if (ModelState.IsValid)
            {
                //return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return productService.GetProducts();
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("addProduct")]
        public bool addProduct([FromBody] ProductViewModel productViewModel)
        {
            return productService.AddProduct(productViewModel);
        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("deleteProduct")]
        public bool deleteProduct(int productId)
        {
            return productService.DeleteProduct(productId);
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("updateProduct")]
        public bool updateProduct([FromUri] int productId,[FromBody] ProductViewModel productViewModel)
        {
            return productService.UpdateProduct(productId, productViewModel);        }
    }
}