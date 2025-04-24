/*****************************************************************************************************************
Author: Code developed by Shinersoft Code Plumber 2024.
Date: Wednesday, November 13, 2024
Time: 3:14:00 AM
TableName: Tenant
FormName: Tenant.cshtml
/*****************************************************************************************************************/
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Utility;
using Newtonsoft.Json.Linq;
namespace AISportsApp.Pages
{
    [Authorize]
    public class tenantModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public tenantModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            string token = _httpContextAccessor.HttpContext?.Request.Cookies["egtdata"];
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(GlobalConstants.ValidIssuer);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostDeleteAsync()
        {
            MemoryStream stream = new MemoryStream();
            try
            {
                await Request.Body.CopyToAsync(stream);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream))
                {
                    string requestBody = reader.ReadToEnd();
                    if (requestBody.Length > 0)
                    {
                        var obj = JsonConvert.DeserializeObject<ObjTenantData>(requestBody);
                        if (obj != null)
                        {
                            var id = obj.Id;
                            // Manually construct JSON object as a string
                            var jsonContent = $@"
{{
""TenantId"": {id},
""TenantSecret"": null,
""TenantName"": null,
""ContactEmail"": null,
""SubscriptionId"": null,
""SubscriptionStartDate"": null,
""SubscriptionEndDate"": null,
""Is_Active"": null,
""Created_Date"":null,
""Created_By"": null,
""Modified_Date"": null,
""Modified_By"": null,
""Audit_Id"": null,  
""User_IP"": null,
""Site_Id"": null,
""lstTenant"": null
}}";
                            // Set JSON content for the request
                            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                            // Making a POST request to the API endpoint
                            var response = await _httpClient.PostAsync(GlobalConstants.ValidIssuer + "/api/Tenant/DeleteTenant", content);
                            if (response.IsSuccessStatusCode)
                            {
                                var data = await response.Content.ReadAsStringAsync();
                            }
                            else
                            {
                                // Handle errors
                                var responseString = await response.Content.ReadAsStringAsync();
                                return new JsonResult(new { success = false, message = GlobalConstants.ValidIssuer + "/api/Tenant/DeleteTenant" + " " + HTMLHelper.GetErrorMessage(responseString) });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = $"An error occurred:  {ex.Message}" });
                // Log error and show a user-friendly message
            }
            return new JsonResult(new { success = true, message = "Record deleted successfully." });
        }
    }
    public class ObjTenantData
    {
        public string Id { get; set; }
    }
}
/*****************************************************************************************************************/


