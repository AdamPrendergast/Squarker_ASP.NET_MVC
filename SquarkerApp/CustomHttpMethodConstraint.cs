using System;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace SquarkerApp
{
    public class RestfulHttpMethodConstraint : HttpMethodConstraint
    {
        public RestfulHttpMethodConstraint(params string[] allowedMethods)
            :base(allowedMethods)
        {            
        }

        protected override bool Match(HttpContextBase httpContext, Route route, string parameterName, 
            RouteValueDictionary values, RouteDirection routeDirection)
        {
            if(routeDirection == RouteDirection.UrlGeneration)
            {
                string verb = "GET";
                if (values.ContainsKey(parameterName))
                    verb = values[parameterName].ToString();

                return AllowedMethods.Any(v => 
                    v.Equals(verb, StringComparison.OrdinalIgnoreCase));                    
            }
            
            return base.Match(httpContext, route, parameterName, values, routeDirection);        
        }
    }
}