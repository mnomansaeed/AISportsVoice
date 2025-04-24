/*****************************************************************************************************************
Author: Code developed by Shinersoft Code Plumber 2024.
Date: Wednesday, November 13, 2024
Time: 5:12:00 PM
TableName: User
FormName: edit-user.cshtml
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
    public class edit_userModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public string UserId1 { get; set; }
        public string TenantId { get; set; }
        public string UserRole { get; set; }
        public string Loc { get; set; }
        public edit_userModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            // Access the cookie directly in the constructor
            string token = _httpContextAccessor.HttpContext?.Request.Cookies["egtdata"];
            UserId1 = _httpContextAccessor.HttpContext.User.FindFirst("http://egtasset/claims/userid")?.Value;
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
        public Int32 UserId { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Please select a Employee.")]
        public string EmployeeId { get; set; }
        public List<SelectListItem> EmployeeIds { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Please select a User Group.")]
        public string UserGroupId { get; set; }
        public List<SelectListItem> UserGroupIds { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Please select a Business Entity.")]
        public string Location_Id { get; set; }
        public List<SelectListItem> Location_Ids { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "User Name is required.")]
        [StringLength(100, ErrorMessage = "User Name cannot be longer than 100 characters")]
        public string UserName { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(5000, ErrorMessage = "Password cannot be longer than 5000 characters")]
        public string Password { get; set; }
        [BindProperty]
        [StringLength(255, ErrorMessage = "Email cannot be longer than 255 characters")]
        public string? Email { get; set; }
        [BindProperty]
        [StringLength(5000, ErrorMessage = "TempPassword cannot be longer than 5000 characters")]
        public string? TempPassword { get; set; }
        [BindProperty]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateRangeFrom { get; set; }
        [BindProperty]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateRangeTo { get; set; }
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
            // Populate dropdown EmployeeIds
            EmployeeIds = new List<SelectListItem>();
            string url1 = "";
            if (UserRole != "Super Admin Group")
            {
                url1 = GlobalConstants.ValidIssuer + "/api/employee/GetemployeesByLocationId/" + Loc;
            }
            else
            {
                url1 = GlobalConstants.ValidIssuer + "/api/employee/Getemployees";
            }
            // Making a GET request to the API endpoint
            var response1 = await _httpClient.GetAsync(url1);
            if (response1.IsSuccessStatusCode)
            {
                var data = await response1.Content.ReadAsStringAsync();
                // Process the data as needed
                JObject Jdata = JObject.Parse(data);
                // Extract lstemployee array and convert it to a list of employee objects
                EmployeeIds = Jdata["lstEmployee"]
                 .Select(item => new SelectListItem
                 {
                     Value = (string)item["EmployeeId"],
                     Text = (string)item["FirstName"] + " " + (string)item["LastName"]
                 }).ToList();
                EmployeeIds.Insert(0, new SelectListItem { Value = "", Text = "<-- Select Employee -->" });
            }
            else
            {
                // Handle errors
                var responseString = await response1.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, GlobalConstants.ValidIssuer + "/api/employee/Getemployees" + " " + HTMLHelper.GetErrorMessage(responseString));
            }
            // Populate dropdown UserGroupIds
            UserGroupIds = new List<SelectListItem>();
            string url2 = "";
            if (UserRole != "Super Admin Group")
            {
                url2 = GlobalConstants.ValidIssuer + "/api/group/GetgroupsByLocationId/" + Loc;
            }
            else
            {
                url2 = GlobalConstants.ValidIssuer + "/api/group/Getgroups";
            }
            // Making a GET request to the API endpoint
            var response2 = await _httpClient.GetAsync(url2);
            if (response2.IsSuccessStatusCode)
            {
                var data = await response2.Content.ReadAsStringAsync();
                // Process the data as needed
                JObject Jdata = JObject.Parse(data);
                // Extract lstusergroup array and convert it to a list of usergroup objects
                UserGroupIds = Jdata["lstGroup"]
                 .Select(item => new SelectListItem
                 {
                     Value = (string)item["UserGroupId"],
                     Text = (string)item["GroupName"]
                 }).ToList();
                UserGroupIds.Insert(0, new SelectListItem { Value = "", Text = "<-- Select User Group -->" });
            }
            else
            {
                // Handle errors
                var responseString = await response2.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, GlobalConstants.ValidIssuer + "/api/group/Getgroups" + " " + HTMLHelper.GetErrorMessage(responseString));
            }
            // Populate dropdown Location_Ids
            Location_Ids = new List<SelectListItem>();
            string url3 = "";
            if (UserRole != "Super Admin Group")
            {
                url3 = GlobalConstants.ValidIssuer + "/api/location/GetlocationsByLocationId/" + Loc;
            }
            else
            {
                url3 = GlobalConstants.ValidIssuer + "/api/location/Getlocations";
            }
            // Making a GET request to the API endpoint
            var response3 = await _httpClient.GetAsync(url3);
            if (response3.IsSuccessStatusCode)
            {
                var data = await response3.Content.ReadAsStringAsync();
                // Process the data as needed
                JObject Jdata = JObject.Parse(data);
                // Extract lstlocation array and convert it to a list of location objects
                Location_Ids = Jdata["lstLocation"]
                 .Select(item => new SelectListItem
                 {
                     Value = (string)item["Location_ID"],
                     Text = (string)item["LocationName"]
                 }).ToList();
                Location_Ids.Insert(0, new SelectListItem { Value = "", Text = "<-- Select Location -->" });
            }
            else
            {
                // Handle errors
                var responseString = await response3.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, GlobalConstants.ValidIssuer + "/api/location/Getlocations" + " " + HTMLHelper.GetErrorMessage(responseString));
            }
            /*****************************************Load All Fields Data************************************************************************/
            if (_httpContextAccessor.HttpContext != null)
            {
                var ID = _httpContextAccessor.HttpContext.Request.Query["id"].ToString();
                // Making a GET request to the API endpoint
                var response = await _httpClient.GetAsync(GlobalConstants.ValidIssuer + "/api/User/GetUsersByID/" + ID);
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
                    ModelState.AddModelError(string.Empty, GlobalConstants.ValidIssuer + "/api/User/GetUsersByID" + " " + HTMLHelper.GetErrorMessage(responseString));
                }
            }
            /*****************************************************************************************************************/
        }
        public async Task<IActionResult> OnPostEditUserAsync()
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
""UserId"": {UserId},
""EmployeeId"": {EmployeeId},
""UserGroupId"": {UserGroupId},
""Location_Id"": {Location_Id},
""UserName"": ""{UserName}"",
""Password"": ""{Password}"",
""Email"": ""{Email}"",
""TempPassword"": null,
""DateRangeFrom"": null,
""DateRangeTo"": null,
""Is_Active"": {Is_Active},
""Created_Date"": ""{Created_Date}"",
""Created_By"": {Created_By},
""Modified_Date"": ""{DateTime.UtcNow:O}"",
""Modified_By"": {UserId1},
""Audit_Id"": {Audit_Id},  
""User_IP"": ""{User_IP}"",
""Site_Id"": {TenantId},
""lstUser"": null
}}";
                // Set JSON content for the request
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                // Making a POST request to the API endpoint
                var response = await _httpClient.PostAsync(GlobalConstants.ValidIssuer + "/api/User/UpdateUser", content);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    // Handle errors
                    var responseString = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, GlobalConstants.ValidIssuer + "/api/User/UpdateUser" + " " + HTMLHelper.GetErrorMessage(responseString));
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
            return LocalRedirect("~/Setup/user"); // Redirects to /some/path within the same app
        }
    }
}
/*****************************************************************************************************************/

