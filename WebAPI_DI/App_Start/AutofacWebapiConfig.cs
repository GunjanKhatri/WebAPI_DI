using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using WebAPI_DI.Repository.Concrete;
using WebAPI_DI.Repository.Interface;
using WebAPI_DI.Service.Concrete;
using WebAPI_DI.Service.Interface;

namespace WebAPI_DI.App_Start
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //builder.RegisterType<DBCustomerEntities>()
            //       .As<DbContext>()
            //       .InstancePerRequest();

            builder.RegisterType<ProductService>()
                   .As<IProductService>()
                   .InstancePerRequest();

            builder.RegisterType<ProductRepository>()
                   .As<IProductRepository>()
                   .InstancePerRequest();

           
            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }
    }
}