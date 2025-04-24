/*****************************************************************************************************************
Author: Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 10:54:00 AM
TableName: PhysicalLocation
FormName: add-physicallocation.cshtml
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
    public class add_physicallocationModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public string UserId { get; set; }
        public string TenantId { get; set; }
        public string UserRole { get; set; }
        public string Loc { get; set; }
        public add_physicallocationModel(IHttpContextAccessor httpContextAccessor)
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
        public Int32 PhysicalLocation_ID { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Please select a business entity.")]
        public string Location_ID { get; set; }
        public List<SelectListItem> Location_IDs { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Physical Location Name is required.")]
        [StringLength(30, ErrorMessage = "Physical Location Name cannot be longer than 30 characters")]
        public string PhysicalLocationName { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Short Code is required.")]
        [StringLength(6, ErrorMessage = "Short Code cannot be longer than 6 characters")]
        public string Short_Code { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Long Code is required.")]
        [StringLength(15, ErrorMessage = "Long Code cannot be longer than 15 characters")]
        public string Long_Code { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Short Name is required.")]
        [StringLength(10, ErrorMessage = "Short Name cannot be longer than 10 characters")]
        public string Short_Name { get; set; }
        [BindProperty]
        [StringLength(2147483647, ErrorMessage = "Description cannot be longer than 2147483647 characters")]
        public string? Description { get; set; }
        [BindProperty]
       
        public string Parent_PhysicalLocation_ID { get; set; }
        public List<SelectListItem> Parent_PhysicalLocation_IDs { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Please select a Physical Location Type.")]
        public string PhysicalLocation_Type_Id { get; set; }
        public List<SelectListItem> PhysicalLocation_Type_Ids { get; set; }
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
                Location_IDs.Insert(0, new SelectListItem { Value = "", Text = "<-- Select Location -->" });
            }
            else
            {
                // Handle errors
                var responseString = await response1.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, GlobalConstants.ValidIssuer + "/api/location/Getlocations" + " " + HTMLHelper.GetErrorMessage(responseString));
            }
            // Populate dropdown Parent_PhysicalLocation_IDs
            Parent_PhysicalLocation_IDs = new List<SelectListItem>();
            string url7 = "";
            if (UserRole != "Super Admin Group")
            {
                url7 = GlobalConstants.ValidIssuer + "/api/physicallocation/GetphysicallocationsByLocationId/" + Loc;
            }
            else
            {
                url7 = GlobalConstants.ValidIssuer + "/api/physicallocation/Getphysicallocations";
            }
            // Making a GET request to the API endpoint
            var response7 = await _httpClient.GetAsync(url7);
            if (response7.IsSuccessStatusCode)
            {
                var data = await response7.Content.ReadAsStringAsync();
                // Process the data as needed
                JObject Jdata = JObject.Parse(data);
                // Extract lstparentphysicallocation array and convert it to a list of parentphysicallocation objects
                Parent_PhysicalLocation_IDs = Jdata["lstPhysicalLocation"]
                 .Select(item => new SelectListItem
                 {
                     Value = (string)item["PhysicalLocation_ID"],
                     Text = (string)item["PhysicalLocationName"]
                 }).ToList();
                Parent_PhysicalLocation_IDs.Insert(0, new SelectListItem { Value = "0", Text = "<-- Select Parent Physical Location -->" });
            }
            else
            {
                // Handle errors
                var responseString = await response7.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, GlobalConstants.ValidIssuer + "/api/physicallocation/Getphysicallocations" + " " + HTMLHelper.GetErrorMessage(responseString));
            }
            // Populate dropdown PhysicalLocation_Type_Ids
            PhysicalLocation_Type_Ids = new List<SelectListItem>();
            string url8 = "";
            //if (UserRole != "Super Admin Group")
            //{
            //    url8 = GlobalConstants.ValidIssuer + "/api/physicallocation_type/Getphysicallocation_typesByLocationId/" + Loc;
            //}
            //else
            //{
                url8 = GlobalConstants.ValidIssuer + "/api/physicallocation_type/Getphysicallocation_types";
            //}
            // Making a GET request to the API endpoint
            var response8 = await _httpClient.GetAsync(url8);
            if (response8.IsSuccessStatusCode)
            {
                var data = await response8.Content.ReadAsStringAsync();
                // Process the data as needed
                JObject Jdata = JObject.Parse(data);
                // Extract lstphysicallocationtype array and convert it to a list of physicallocationtype objects
                PhysicalLocation_Type_Ids = Jdata["lstPhysicalLocation_Type"]
                 .Select(item => new SelectListItem
                 {
                     Value = (string)item["PhysicalLocation_Type_Id"],
                     Text = (string)item["PhysicalLocationTypeName"]
                 }).ToList();
                PhysicalLocation_Type_Ids.Insert(0, new SelectListItem { Value = "", Text = "<-- Select Physical Location Type -->" });
            }
            else
            {
                // Handle errors
                var responseString = await response8.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, GlobalConstants.ValidIssuer + "/api/physicallocation_type/Getphysicallocation_types" + " " + HTMLHelper.GetErrorMessage(responseString));
            }
        }
        public async Task<IActionResult> OnPostAddPhysicalLocationAsync()
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
""Location_ID"": {Location_ID},
""PhysicalLocationName"": ""{PhysicalLocationName}"",
""Short_Code"": ""{Short_Code}"",
""Long_Code"": ""{Long_Code}"",
""Short_Name"": ""{Short_Name}"",
""Description"": ""{Description}"",
""Parent_PhysicalLocation_ID"": {Parent_PhysicalLocation_ID},
""PhysicalLocation_Type_Id"": {PhysicalLocation_Type_Id},
""Is_Active"": 1,
""Created_Date"": ""{DateTime.UtcNow:O}"",
""Created_By"": {UserId},
""Modified_Date"": null,
""Modified_By"": null,
""Audit_Id"": 0,  
""User_IP"": ""{User_IP}"",
""Site_Id"": {TenantId},
""lstPhysicalLocation"": null
}}";
                // Set JSON content for the request
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                // Making a POST request to the API endpoint
                var response = await _httpClient.PostAsync(GlobalConstants.ValidIssuer + "/api/PhysicalLocation/AddPhysicalLocation", content);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    // Handle errors
                    var responseString = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, GlobalConstants.ValidIssuer + "/api/PhysicalLocation/AddPhysicalLocation" + " " + HTMLHelper.GetErrorMessage(responseString));
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
            return LocalRedirect("~/Setup/physicallocation"); // Redirects to /some/path within the same app
        }
    }
}
/*****************************************************************************************************************/

