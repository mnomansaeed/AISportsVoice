/*****************************************************************************************************************
Author: Code developed by Shinersoft Code Plumber 2024.
Date: Tuesday, November 12, 2024
Time: 10:12:00 AM
TableName: Tenant
FormName: add-tenant.cshtml
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
using Microsoft.AspNetCore.Http;
using Utility;
using System.Security.Claims;
namespace AISportsApp.Pages
{
    [Authorize]
    public class add_tenantModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public string UserId { get; set; }
        public string TenantId1 { get; set; }
        public string UserRole { get; set; }
        public string Loc { get; set; }
        public add_tenantModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            // Access the cookie directly in the constructor
            string token = _httpContextAccessor.HttpContext?.Request.Cookies["egtdata"];
            UserId = _httpContextAccessor.HttpContext.User.FindFirst("http://egtasset/claims/userid")?.Value;
            TenantId1 = _httpContextAccessor.HttpContext.User.FindFirst("http://egtasset/claims/tenantid")?.Value;
            User_IP = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString();
            UserRole = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            Loc = _httpContextAccessor.HttpContext.User.FindFirst("http://egtasset/claims/locationid")?.Value;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(GlobalConstants.ValidIssuer);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
        [BindProperty]
        public Int32 TenantId { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Tenant Secret Key is required.")]
        [StringLength(510, ErrorMessage = "Tenant Secret Key cannot be longer than 510 characters")]
        public string TenantSecret { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Tenant Name is required.")]
        [StringLength(510, ErrorMessage = "Tenant Name cannot be longer than 510 characters")]
        public string TenantName { get; set; }
        [BindProperty]
        [StringLength(510, ErrorMessage = "Contact Email cannot be longer than 510 characters")]
        public string? ContactEmail { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Please select a Subscription.")]
        public string SubscriptionId { get; set; }
        public List<SelectListItem> SubscriptionIds { get; set; }
        [BindProperty]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? SubscriptionStartDate { get; set; }
        [BindProperty]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? SubscriptionEndDate { get; set; }
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
            // Populate dropdown SubscriptionIds
            SubscriptionIds = new List<SelectListItem>();
            string url4 = "";
            //if (UserRole != "Super Admin Group")
            //{
            //    url4 = GlobalConstants.ValidIssuer + "/api/subscription/GetsubscriptionsByLocationId/" + Loc;
            //}
            //else
            //{
                url4 = GlobalConstants.ValidIssuer + "/api/subscription/Getsubscriptions";
           // }
            // Making a GET request to the API endpoint
            var response4 = await _httpClient.GetAsync(url4);
            if (response4.IsSuccessStatusCode)
            {
                var data = await response4.Content.ReadAsStringAsync();
                // Process the data as needed
                JObject Jdata = JObject.Parse(data);
                // Extract lstsubscription array and convert it to a list of subscription objects
                SubscriptionIds = Jdata["lstSubscription"]
                 .Select(item => new SelectListItem
                 {
                     Value = (string)item["SubscriptionId"],
                     Text = (string)item["PlanName"]
                 }).ToList();
                SubscriptionIds.Insert(0, new SelectListItem { Value = "", Text = "<-- Select SubscriptionId -->" });
            }
            else
            {
                // Handle errors
                var responseString = await response4.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, GlobalConstants.ValidIssuer + "/api/subscription/Getsubscriptions" + " " + HTMLHelper.GetErrorMessage(responseString));
            }
        }
        public async Task<IActionResult> OnPostAddTenantAsync()
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
""TenantSecret"": ""{TenantSecret}"",
""TenantName"": ""{TenantName}"",
""ContactEmail"": ""{ContactEmail}"",
""SubscriptionId"": {SubscriptionId},
""SubscriptionStartDate"": ""{SubscriptionStartDate}"",
""SubscriptionEndDate"": ""{SubscriptionEndDate}"",
""Is_Active"": 1,
""Created_Date"": ""{DateTime.UtcNow:O}"",
""Created_By"": {UserId},
""Modified_Date"": null,
""Modified_By"": null,
""Audit_Id"": 0,  
""User_IP"": ""{User_IP}"",
""Site_Id"": {TenantId1},
""lstTenant"": null
}}";
                // Set JSON content for the request
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                // Making a POST request to the API endpoint
                var response = await _httpClient.PostAsync(GlobalConstants.ValidIssuer + "/api/Tenant/AddTenant", content);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    // Handle errors
                    var responseString = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, GlobalConstants.ValidIssuer + "/api/Tenant/AddTenant" + " " + HTMLHelper.GetErrorMessage(responseString));
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
            return LocalRedirect("~/Setup/tenant"); // Redirects to /some/path within the same app
        }
    }
}
/*****************************************************************************************************************/

