/*****************************************************************************************************************
Author: Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 2:20:00 AM
TableName: Vendor
FormName: edit-vendor.cshtml
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
    public class edit_vendorModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public string UserId { get; set; }
        public string TenantId { get; set; }
        public string UserRole { get; set; }
        public string Loc { get; set; }
        public edit_vendorModel(IHttpContextAccessor httpContextAccessor)
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
        public Int32 VendorId { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Please select a Business Entity.")]
        public string Location_ID { get; set; }
        public List<SelectListItem> Location_IDs { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Vendor Code is required.")]
        [StringLength(100, ErrorMessage = "Vendor Code cannot be longer than 100 characters")]
        public string VendorCode { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Vendor Name is required.")]
        [StringLength(255, ErrorMessage = "Vendor Name cannot be longer than 255 characters")]
        public string VendorName { get; set; }
        [BindProperty]
        [StringLength(50, ErrorMessage = "VAT No cannot be longer than 50 characters")]
        public string? VATRegistrationNo { get; set; }
        [BindProperty]
        [StringLength(255, ErrorMessage = "Contact Name cannot be longer than 255 characters")]
        public string? ContactName { get; set; }
        [BindProperty]
        [StringLength(100, ErrorMessage = "Contact Title cannot be longer than 100 characters")]
        public string? ContactTitle { get; set; }
        [BindProperty]
        [StringLength(20, ErrorMessage = "Phone cannot be longer than 20 characters")]
        public string? PhoneNumber { get; set; }
        [BindProperty]
        [StringLength(255, ErrorMessage = "Email cannot be longer than 255 characters")]
        public string? Email { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Address is required.")]
        [StringLength(255, ErrorMessage = "Address cannot be longer than 255 characters")]
        public string AddressLine1 { get; set; }
        [BindProperty]
        [StringLength(255, ErrorMessage = "Address Line2 cannot be longer than 255 characters")]
        public string? AddressLine2 { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "City is required.")]
        [StringLength(100, ErrorMessage = "City cannot be longer than 100 characters")]
        public string City { get; set; }
        [BindProperty]
        [StringLength(100, ErrorMessage = "State cannot be longer than 100 characters")]
        public string? State { get; set; }
        [BindProperty]
        [StringLength(20, ErrorMessage = "Postal Code cannot be longer than 20 characters")]
        public string? PostalCode { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Country is required.")]
        [StringLength(100, ErrorMessage = "Country cannot be longer than 100 characters")]
        public string Country { get; set; }
        [BindProperty]
        [StringLength(255, ErrorMessage = "URL cannot be longer than 255 characters")]
        public string? WebsiteURL { get; set; }
        [BindProperty]
        [StringLength(2147483647, ErrorMessage = "Notes cannot be longer than 2147483647 characters")]
        public string? Notes { get; set; }
        [BindProperty]
        public byte Is_Active { get; set; }
        [BindProperty]
        public DateTime Created_Date { get; set; }
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
        [BindProperty]
        public Int32 Site_Id { get; set; }
        public async Task OnGetAsync()
        {
            // Populate dropdown Location_IDs
            Location_IDs = new List<SelectListItem>();
            string url1 = "";
            if (UserRole != "Super Admin Group")
            {
                url1 = GlobalConstants.ValidIssuer + "/api/location/GetlocationsByLocationId/" + Loc;
            }
            else
            {
                url1 = GlobalConstants.ValidIssuer + "/api/location/Getlocations";
            }
            // Making a GET request to the API endpoint
            var response1 = await _httpClient.GetAsync(url1);
            if (response1.IsSuccessStatusCode)
            {
                var data = await response1.Content.ReadAsStringAsync();
                // Process the data as needed
                JObject Jdata = JObject.Parse(data);
                // Extract lstlocation array and convert it to a list of location objects
                Location_IDs = Jdata["lstLocation"]
                 .Select(item => new SelectListItem
                 {
                     Value = (string)item["Location_ID"],
                     Text = (string)item["LocationName"]
                 }).ToList();
                Location_IDs.Insert(0, new SelectListItem { Value = "", Text = "<-- Select Location_ID -->" });
            }
            else
            {
                // Handle errors
                var responseString = await response1.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, GlobalConstants.ValidIssuer + "/api/location/Getlocations" + " " + HTMLHelper.GetErrorMessage(responseString));
            }
            /*****************************************Load All Fields Data************************************************************************/
            if (_httpContextAccessor.HttpContext != null)
            {
                var ID = _httpContextAccessor.HttpContext.Request.Query["id"].ToString();
                // Making a GET request to the API endpoint
                var response = await _httpClient.GetAsync(GlobalConstants.ValidIssuer + "/api/Vendor/GetVendorsByID/" + ID);
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
                    ModelState.AddModelError(string.Empty, GlobalConstants.ValidIssuer + "/api/Vendor/GetVendorsByID" + " " + HTMLHelper.GetErrorMessage(responseString));
                }
            }
            /*****************************************************************************************************************/
        }
        public async Task<IActionResult> OnPostEditVendorAsync()
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
""VendorId"": {VendorId},
""Location_ID"": {Location_ID},
""VendorCode"": ""{VendorCode}"",
""VendorName"": ""{VendorName}"",
""VATRegistrationNo"": ""{VATRegistrationNo}"",
""ContactName"": ""{ContactName}"",
""ContactTitle"": ""{ContactTitle}"",
""PhoneNumber"": ""{PhoneNumber}"",
""Email"": ""{Email}"",
""AddressLine1"": ""{AddressLine1}"",
""AddressLine2"": ""{AddressLine2}"",
""City"": ""{City}"",
""State"": ""{State}"",
""PostalCode"": ""{PostalCode}"",
""Country"": ""{Country}"",
""WebsiteURL"": ""{WebsiteURL}"",
""Notes"": ""{Notes}"",
""Is_Active"": {Is_Active},
""Created_Date"": ""{Created_Date}"",
""Created_By"": {Created_By},
""Modified_Date"": ""{DateTime.UtcNow:O}"",
""Modified_By"": {UserId},
""Audit_Id"": {Audit_Id},  
""User_IP"": ""{User_IP}"",
""Site_Id"": {TenantId},
""lstVendor"": null
}}";
                // Set JSON content for the request
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                // Making a POST request to the API endpoint
                var response = await _httpClient.PostAsync(GlobalConstants.ValidIssuer + "/api/Vendor/UpdateVendor", content);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    // Handle errors
                    var responseString = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, GlobalConstants.ValidIssuer + "/api/Vendor/UpdateVendor" + " " + HTMLHelper.GetErrorMessage(responseString));
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
            return LocalRedirect("~/Setup/vendor"); // Redirects to /some/path within the same app
        }
    }
}
/*****************************************************************************************************************/

