using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebAPI_DI.BusinessEntity;
using WebAPI_DI.Service.Concrete;
using WebAPI_DI.Service.Interface;

namespace WebAPI_DI.Controllers
{
    public class EmployeeController : Controller
    {
        public IProductService producrService { get; set; }
        public EmployeeController(ProductService _producrService)
        {

            producrService = _producrService;
        }
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] ProductViewModel productViewModel)
        {


            producrService.AddProduct(productViewModel);

            return new HttpResponseMessage(HttpStatusCode.OK);



        }

        // GET api/<controller>
        //public HttpResponseMessage Get()
        //{
        //    var product = producrService.GetProducts();

            //IContentNegotiator negotiator = this.Configuration.Services.GetContentNegotiator();

            //ContentNegotiationResult result = negotiator.Negotiate(
            //    typeof(List<ProductViewModel>), this.Request, this.Configuration.Formatters);
            //if (result == null)
            //{
            //    var response = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            //    throw new HttpResponseException(response);
            //}

            //return new HttpResponseMessage()
            //{
            //    Content = new ObjectContent<List<ProductViewModel>>(
            //        product,                // What we are serializing 
            //        result.Formatter,           // The media formatter
            //        result.MediaType.MediaType  // The MIME type
            //    )
            //};


        //}

    }
}