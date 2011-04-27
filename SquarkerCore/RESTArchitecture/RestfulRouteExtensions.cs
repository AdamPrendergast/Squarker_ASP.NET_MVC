using System.Web.Mvc;
using System.Web.Routing;

namespace SquarkerCore
{
    public static class RestfulRouteExtensions
    {
        public static void MapResource<TController>(this RouteCollection routes, string alias) where TController : IController 
        {
            string controllerName = typeof(TController).Name.Replace("Controller", "");
            
            //LIST
            routes.MapRoute(alias + "_LIST", alias,
                            new { controller = controllerName, action = "Index" },
                            new { httpMethod = new RestfulHttpMethodConstraint("GET") });

            //NEW
            routes.MapRoute(alias + "_NEW", alias + "/new",
                            new { controller = controllerName, action = "New" },
                            new { httpMethod = new RestfulHttpMethodConstraint("GET") });

            //POST (create)
            routes.MapRoute(alias + "_POST", alias,
                            new { controller = controllerName, action = "Create" },
                            new { httpMethod = new RestfulHttpMethodConstraint("POST") });

            //EDIT
            routes.MapRoute(alias + "_EDIT", alias + "/{id}/edit",
                            new { controller = controllerName, action = "Edit" },
                            new { httpMethod = new RestfulHttpMethodConstraint("GET") });

            //PUT (update)
            routes.MapRoute(alias + "_PUT", alias + "/{id}",
                            new { controller = controllerName, action = "Update" },
                            new { httpMethod = new RestfulHttpMethodConstraint("PUT") });

            //DELETE
            routes.MapRoute(alias + "_DELETE", alias + "/{id}",
                            new { controller = controllerName, action = "Delete" },
                            new { httpMethod = new RestfulHttpMethodConstraint("DELETE") });

            //SHOW
            routes.MapRoute(alias + "_SHOW", alias + "/{id}",
                            new { controller = controllerName, action = "Show" },
                            new { httpMethod = new RestfulHttpMethodConstraint("GET") });
        }
		
    }
}