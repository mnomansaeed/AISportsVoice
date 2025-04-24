/*****************************************************************************************************************
Author: Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 10:54:00 AM
TableName: PhysicalLocation_Type
FormName: add-physicallocation_type.cshtml
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
    public class add_physicallocation_typeModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public string UserId { get; set; }
        public string TenantId { get; set; }
        public string UserRole { get; set; }
        public string Loc { get; set; }
        public add_physicallocation_typeModel(IHttpContextAccessor httpContextAccessor)
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
        public Int32 PhysicalLocation_Type_Id { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Physical Location Type Name is required.")]
        [StringLength(30, ErrorMessage = "Physical Location Type Name cannot be longer than 30 characters")]
        public string PhysicalLocationTypeName { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(2147483647, ErrorMessage = "Description cannot be longer than 2147483647 characters")]
        public string Description { get; set; }
        [BindProperty]
        
        public string Parent_PhysicalLocation_Type_ID { get; set; }
        public List<SelectListItem> Parent_PhysicalLocation_Type_IDs { get; set; }
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
            // Populate dropdown Parent_PhysicalLocation_Type_IDs
            Parent_PhysicalLocation_Type_IDs = new List<SelectListItem>();
            string url3 = "";
            //if (UserRole != "Super Admin Group")
            //{
            //    url3 = GlobalConstants.ValidIssuer + "/api/physicallocationtype/Getphysicallocation_typesByLocationId/" + Loc;
            //}
            //else
            //{
                url3 = GlobalConstants.ValidIssuer + "/api/physicallocation_type/Getphysicallocation_types";
            //}
            // Making a GET request to the API endpoint
            var response3 = await _httpClient.GetAsync(url3);
            if (response3.IsSuccessStatusCode)
            {
                var data = await response3.Content.ReadAsStringAsync();
                // Process the data as needed
                JObject Jdata = JObject.Parse(data);
                // Extract lstparentphysicallocationtype array and convert it to a list of parentphysicallocationtype objects
                Parent_PhysicalLocation_Type_IDs = Jdata["lstPhysicalLocation_Type"]
                 .Select(item => new SelectListItem
                 {
                     Value = (string)item["PhysicalLocation_Type_Id"],
                     Text = (string)item["PhysicalLocationTypeName"]
                 }).ToList();
                Parent_PhysicalLocation_Type_IDs.Insert(0, new SelectListItem { Value = "0", Text = "<-- Select Parent_Physical Location Type -->" });
            }
            else
            {
                // Handle errors
                var responseString = await response3.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, GlobalConstants.ValidIssuer + "/api/physicallocation_type/Getphysicallocation_types" + " " + HTMLHelper.GetErrorMessage(responseString));
            }
        }
        public async Task<IActionResult> OnPostAddPhysicalLocation_TypeAsync()
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
""PhysicalLocationTypeName"": ""{PhysicalLocationTypeName}"",
""Description"": ""{Description}"",
""Parent_PhysicalLocation_Type_ID"": {Parent_PhysicalLocation_Type_ID},
""Is_Active"": 1,
""Created_Date"": ""{DateTime.UtcNow:O}"",
""Created_By"": {UserId},
""Modified_Date"": null,
""Modified_By"": null,
""Audit_Id"": 0,  
""User_IP"": ""{User_IP}"",
""Site_Id"": {TenantId},
""lstPhysicalLocation_Type"": null
}}";
                // Set JSON content for the request
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                // Making a POST request to the API endpoint
                var response = await _httpClient.PostAsync(GlobalConstants.ValidIssuer + "/api/PhysicalLocation_Type/AddPhysicalLocation_Type", content);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    // Handle errors
                    var responseString = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, GlobalConstants.ValidIssuer + "/api/PhysicalLocation_Type/AddPhysicalLocation_Type" + " " + HTMLHelper.GetErrorMessage(responseString));
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
            return LocalRedirect("~/Setup/physicallocation_type"); // Redirects to /some/path within the same app
        }
    }
}
/*****************************************************************************************************************/

