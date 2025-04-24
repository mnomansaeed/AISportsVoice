/*****************************************************************************************************************
Author: Code developed by Shinersoft Code Plumber 2024.
Date: Wednesday, November 13, 2024
Time: 3:45:00 AM
TableName: Subscription
FormName: edit-subscription.cshtml
/*****************************************************************************************************************/
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Utility;
using System.Security.Claims;
namespace AISportsApp.Pages
{
    [Authorize]
    public class edit_subscriptionModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public string UserId { get; set; }
        public string TenantId { get; set; }
        public string UserRole { get; set; }
        public string Loc { get; set; }
        public edit_subscriptionModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            // Access the cookie directly in the constructor
            string token = _httpContextAccessor.HttpContext?.Request.Cookies["egtdata"];
            UserId = _httpContextAccessor.HttpContext.User.FindFirst("http://egtasset/claims/userid")?.Value;
            TenantId = _httpContextAccessor.HttpContext.User.FindFirst("http://egtasset/claims/tenantid")?.Value;
            User_IP = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString();
            UserRole = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            Loc = _httpContextAccessor.HttpContext.User.FindFirst("http://egtasset/claims/locationid")?.Value;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(GlobalConstants.ValidIssuer);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
        [BindProperty]
        public Int32 SubscriptionId { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Plan Name is required.")]
        [StringLength(200, ErrorMessage = "Plan Name cannot be longer than 200 characters")]
        public string PlanName { get; set; }
        [BindProperty]
        [StringLength(100, ErrorMessage = "Status cannot be longer than 100 characters")]
        public string? Status { get; set; }
        [BindProperty]
        public byte Is_Active { get; set; }
        [BindProperty]
        public DateTime? Created_Date { get; set; }
        [BindProperty]
        public Int32 Created_By { get; set; }
        [BindProperty]
        public DateTime? Modified_Date { get; set; }
        [BindProperty]
        public Int32? Modified_By { get; set; }
        [BindProperty]
        public Int64? Audit_Id { get; set; }
        [BindProperty]
        public string? User_IP { get; set; }
        public async Task OnGetAsync()
        {
            /*****************************************Load All Fields Data************************************************************************/
            if (_httpContextAccessor.HttpContext != null)
            {
                var ID = _httpContextAccessor.HttpContext.Request.Query["id"].ToString();
                // Making a GET request to the API endpoint
                var response = await _httpClient.GetAsync(GlobalConstants.ValidIssuer + "/api/Subscription/GetSubscriptionsByID/" + ID);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    // Populate the page model properties.
                    JsonConvert.PopulateObject(data, this);
                }
                else
                {
                    // Handle errors
                    var responseString = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, GlobalConstants.ValidIssuer + "/api/Subscription/GetSubscriptionsByID" + " " + HTMLHelper.GetErrorMessage(responseString));
                }
            }
            /*****************************************************************************************************************/
        }
        public async Task<IActionResult> OnPostEditSubscriptionAsync()
        {
            // Validate the model
            if (!ModelState.IsValid)
            {
                // If validation fails, re-populate dropdown lists and return the page
                OnGetAsync();  // This reloads the lists in case of validation errors
                return Page();
            }
            try
            {
                // Manually construct JSON object as a string
                var jsonContent = $@"
{{
""SubscriptionId"": {SubscriptionId},
""PlanName"": ""{PlanName}"",
""Status"": ""{Status}"",
""Is_Active"": {Is_Active},
""Created_Date"": ""{Created_Date}"",
""Created_By"": {Created_By},
""Modified_Date"": ""{DateTime.UtcNow:O}"",
""Modified_By"": {UserId},
""Audit_Id"": {Audit_Id},  
""User_IP"": ""{User_IP}"",
""Site_Id"": {TenantId},
""lstSubscription"": null
}}";
                // Set JSON content for the request
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                // Making a POST request to the API endpoint
                var response = await _httpClient.PostAsync(GlobalConstants.ValidIssuer + "/api/Subscription/UpdateSubscription", content);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    // Handle errors
                    var responseString = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, GlobalConstants.ValidIssuer + "/api/Subscription/UpdateSubscription" + " " + HTMLHelper.GetErrorMessage(responseString));
                    return Page();
                }
            }
            catch (Exception ex)
            {
                // Log error and show a user-friendly message
                ModelState.AddModelError(string.Empty, $"An error occurred:  {ex.Message}");
                return Page();
            }
            // If validation passes, you can proceed with other logic
            // Save data or redirect to another page
            return LocalRedirect("~/Setup/subscription"); // Redirects to /some/path within the same app
        }
    }
}
/*****************************************************************************************************************/

