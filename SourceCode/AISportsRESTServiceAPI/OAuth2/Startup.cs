
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Owin.Security.Jwt;

using System.Web.Http;
using Utility;

[assembly: OwinStartup(typeof(AISportsRESTServiceAPI.OAuth2.Startup))]

namespace AISportsRESTServiceAPI.OAuth2
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure OAuth Authorization Server options
            OAuthAuthorizationServerOptions oAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),  // URL path for token requests
                Provider = new APIOAuthAuthorizationServerProvider(),  // Provider with DB logic
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),  // Token expiration time
                AllowInsecureHttp = true  // Allow HTTP for testing; use HTTPS in production
               
            };

            // Enable OAuth Authorization Server
            app.UseOAuthAuthorizationServer(oAuthOptions);

           
            // Use JWT Bearer Token Authentication
            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,  // Validation logic for issuer
                    ValidateAudience = false,  // Validation logic for audience
                    ValidateLifetime = true,  // Validate token expiration
                    ValidIssuer = GlobalConstants.ValidIssuer, // Replace with your issuer
                    ValidAudience = GlobalConstants.Audiance, // Replace with your audience
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(GlobalConstants.IssuerSigningKey)) // Secret key for validating token
                }
            });

            //// Enable CORS if necessary
            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            // Configure Web API
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}