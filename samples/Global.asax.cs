﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcCodeRouting;

namespace Samples {

   public class MvcApplication : System.Web.HttpApplication {

      void Application_Start() {

         RegisterRoutes(RouteTable.Routes);
         RegisterViewEngines(ViewEngines.Engines);
      }

      void RegisterRoutes(RouteCollection routes) {

         routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

         CodeRoutingSettings.Defaults.Reset();
         CodeRoutingSettings.Defaults.RouteFormatter = args =>
            Regex.Replace(args.OriginalSegment, @"([a-z])([A-Z])", "$1-$2").ToLowerInvariant();

         routes.MapCodeRoutes(typeof(Controllers.HomeController));
      }

      void RegisterViewEngines(ViewEngineCollection viewEngines) {
         viewEngines.EnableCodeRouting();
      }
   }
}