using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DemosRotaMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Todas",
                url: "Todas",
                defaults: new { controller = "Noticias", action = "Todas" }
            );

            routes.MapRoute(
                name: "Por Categoria",
                url: "{cat}",
                defaults: new { controller = "Noticias", action = "NoticiasDaCategoria"}
            );

            routes.MapRoute(
                name: "Mostrar Noticia",
                url: "{categoria}/{titulo}/{id}",
                defaults: new { controller = "Noticias", action = "MostrarNoticia"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Noticias", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}