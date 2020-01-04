﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebChatApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { Controller="Home", action="Index"}
                );
            routes.MapRoute(
                name: "Login",
                url: "login",
                defaults: new {Controller="Auth",action="Login"}
                );
            routes.MapRoute(
                name:"ChatRoom",
                url: "chat",
                defaults: new {controller="Chat",action="Index"}
                );
            
        }
    }
}
