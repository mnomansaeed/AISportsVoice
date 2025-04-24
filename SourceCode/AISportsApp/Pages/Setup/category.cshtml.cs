/*****************************************************************************************************************
Author: Code developed by Shinersoft Code Plumber 2024.
Date: Wednesday, November 13, 2024
Time: 5:12:00 PM
TableName: Category
FormName: Category.cshtml
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
    public class categoryModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public categoryModel(IHttpContextAccessor httpContextAccessor)
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
                        var obj = JsonConvert.DeserializeObject<ObjCategoryData>(requestBody);
                        if (obj != null)
                        {
                            var id = obj.Id;
                            // Manually construct JSON object as a string
                            var jsonContent = $@"
{{
""CategoryId"": {id},
""Location_ID"": null,
""CategoryName"": null,
""Description"": null,
""Life"": null,
""Is_Checkout"": null,
""Notes"": null,
""Is_Active"": null,
""Created_Date"":null,
""Created_By"": null,
""Modified_Date"": null,
""Modified_By"": null,
""Audit_Id"": null,  
""User_IP"": null,
""Site_Id"": null,
""lstCategory"": null
}}";
                            // Set JSON content for the request
                            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                            // Making a POST request to the API endpoint
                            var response = await _httpClient.PostAsync(GlobalConstants.ValidIssuer + "/api/Category/DeleteCategory", content);
                            if (response.IsSuccessStatusCode)
                            {
                                var data = await response.Content.ReadAsStringAsync();
                            }
                            else
                            {
                                // Handle errors
                                var responseString = await response.Content.ReadAsStringAsync();
                                return new JsonResult(new { success = false, message = GlobalConstants.ValidIssuer + "/api/Category/DeleteCategory" + " " + HTMLHelper.GetErrorMessage(responseString) });
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
    public class ObjCategoryData
    {
        public string Id { get; set; }
    }
}
/*****************************************************************************************************************/

