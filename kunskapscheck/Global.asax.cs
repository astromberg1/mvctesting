﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace kunskapscheck
    {
    public class MvcApplication : System.Web.HttpApplication
        {
        protected void Application_Start()
            {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            ////Remove all view engine
            //ViewEngines.Engines.Clear();

            ////Add Razor view Engine
            //ViewEngines.Engines.Add(new RazorViewEngine());

            }
        }
    }
