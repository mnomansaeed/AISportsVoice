
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using DomainLayer;
using DataLayer;
using Utility;
using POCO;
using System.Web.Http;
using System.Web.Http.Description;
using System.Diagnostics;
using System.Security.Claims;
using System.Web;

namespace WebAPI
{
    [Authorize]
    public class ClaimsController : ApiController
    {
        // GET api/claims
        [HttpGet]
        [Route("api/Claims/GetUserClaims")]
        public IHttpActionResult GetUserClaims()
        {
            // Access the current HttpContext
            var context = HttpContext.Current;

            if (context != null)
            {
                System.Security.Principal.IPrincipal _principal = context.User;
                var _identity = (ClaimsPrincipal)_principal;
                // Retrieve custom claims from the current user
                var claims = new
                {
                    UserName = _identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value,
                    GroupName = _identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value,
                    TenantId = _identity.Claims.FirstOrDefault(c => c.Type == "http://egtasset/claims/tenantid")?.Value,
                    TenantName = _identity.Claims.FirstOrDefault(c => c.Type == "http://egtasset/claims/tenantname")?.Value,
                    TenantSecret = _identity.Claims.FirstOrDefault(c => c.Type == "http://egtasset/claims/tenantsecret")?.Value,
                    Location_ID = _identity.Claims.FirstOrDefault(c => c.Type == "http://egtasset/claims/locationid")?.Value,
                    LocationName = _identity.Claims.FirstOrDefault(c => c.Type == "http://egtasset/claims/locationname")?.Value,
                    UserId = _identity.Claims.FirstOrDefault(c => c.Type == "http://egtasset/claims/userid")?.Value,
                    UserGroupId = _identity.Claims.FirstOrDefault(c => c.Type == "http://egtasset/claims/usergroupid")?.Value,
                    Password = _identity.Claims.FirstOrDefault(c => c.Type == "http://egtasset/claims/password")?.Value,
                    SubscriptionId = _identity.Claims.FirstOrDefault(c => c.Type == "http://egtasset/claims/subscriptionid")?.Value,
                    SubscriptionStartDate = _identity.Claims.FirstOrDefault(c => c.Type == "http://egtasset/claims/subscriptionstartdate")?.Value,
                    SubscriptionEndDate = _identity.Claims.FirstOrDefault(c => c.Type == "http://egtasset/claims/subscriptionenddate")?.Value,
                    TenantActive = _identity.Claims.FirstOrDefault(c => c.Type == "http://egtasset/claims/tenantactive")?.Value,
                    locationActive = _identity.Claims.FirstOrDefault(c => c.Type == "http://egtasset/claims/locationactive")?.Value,
                    UserActive = _identity.Claims.FirstOrDefault(c => c.Type == "http://egtasset/claims/useractive")?.Value,
                  //  SigningKey = _identity.Claims.FirstOrDefault(c => c.Type == "http://egtasset/claims/signingkey")?.Value
                };

                // Return the claims as a JSON response
                return Ok(claims);

            }



            return BadRequest("HttpContext is not available.");
        }
    }
}
