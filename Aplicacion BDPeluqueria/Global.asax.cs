using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Aplicacion_BDPeluqueria.Configuration;
using AutoMapper;

namespace Aplicacion_BDPeluqueria
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Mapper.Initialize(cf => cf.AddProfile(new AutoMapperConfiguration()));
        }
        
        public void LoadAutoMapperConfig()
        {

        }

    }
}
