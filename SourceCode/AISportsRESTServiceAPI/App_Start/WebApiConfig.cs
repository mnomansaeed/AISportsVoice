using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Swashbuckle.Swagger;
using System.Web;

namespace AISportsRESTServiceAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Enable Swagger
            /*"http://localhost/AISportsRESTServiceAPI/swagger/ui/index"*/
            config.EnableSwagger(c =>
            {

                c.SingleApiVersion("v1", "AI Sports Data Access API")
                .Description("Complete documentation of AI Sports Data Access API")
                .TermsOfService("Need to get access permission from Health IT Integrations LLC.")
                .Contact(cc => cc
                    .Name("Talha Amin Shaikh")
                    .Email("talha149@gmail.com")
                    .Url("https://www.healthitintegrations.com"))
                .License(lc => lc
                    .Name("License")
                    .Url("https://www.healthitintegrations.com"));


                // Correct the base path
                c.RootUrl(req => new Uri(req.RequestUri, HttpContext.Current.Request.ApplicationPath ?? string.Empty).ToString());


                //c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); // In case of multiple route conflicts

                var xmlPath = System.AppDomain.CurrentDomain.BaseDirectory + @"bin\AISportsRESTServiceAPI.xml";
                c.IncludeXmlComments(xmlPath); // This enables XML documentation in Swagger


                // OAuth2 configuration
                c.OAuth2("oauth2")
                    .Description("OAuth2 Implicit Grant")
                    .Flow("implicit")// or "accessCode" for authorization code flow
                    .AuthorizationUrl("http://localhost/AISportsRESTServiceAPI/auth")  // Authorization URL
                    .TokenUrl("http://localhost/AISportsRESTServiceAPI/token")
                    .Scopes(scopes =>
                    {
                        scopes.Add("read", "Read access to protected resources");
                        scopes.Add("write", "Write access to protected resources");
                    });

                // Add the security definition globally
                c.OperationFilter<AssignOAuth2SecurityRequirements>();


            }).EnableSwaggerUi(c =>
            {

                c.DocumentTitle("AI Sports Data Access API Swagger UI");

                // Enable OAuth2 authentication in Swagger UI
                c.EnableOAuth2Support(
                    clientId: "1",
                    clientSecret:null, //"egt123",
                    realm: "your-realm",
                    appName: "AI Sports Data Access API",
                    additionalQueryStringParams:null
                );

            }); // Enables Swagger UI
        }
    }
    // Assign security requirements to operations
    public class AssignOAuth2SecurityRequirements : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var authorizationAttributes = apiDescription.ActionDescriptor.GetCustomAttributes<AuthorizeAttribute>();

            if (authorizationAttributes.Any())
            {
                if (operation.security == null)
                    operation.security = new List<IDictionary<string, IEnumerable<string>>>();

                var oAuthRequirements = new Dictionary<string, IEnumerable<string>>
                {
                    { "oauth2", new List<string> { "read", "write" } }
                };

                operation.security.Add(oAuthRequirements);
            }
        }

    }
}
