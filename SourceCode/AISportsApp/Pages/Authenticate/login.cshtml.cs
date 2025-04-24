using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using System.Text;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Utility;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

using System.Security.Principal;
using Microsoft.Extensions.Options;


namespace AISportsApp.Pages.Authenticate
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Username is required")]
        [StringLength(100, ErrorMessage = "Username can't be longer than 100 characters")]
        public string ?Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string ?Password { get; set; }

        [BindProperty]
        public bool RememberMe { get; set; }

        public string ?ReturnUrl { get; set; }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");
          
        }
        public async Task<IActionResult> OnPostLoginAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");

            if (!ModelState.IsValid)
            {
                return Page();
            }
       
            // Call the Web API to validate the user and get a JWT token
            string jwtToken = await GetJwtTokenAsync(Username, Password);

            if (string.IsNullOrEmpty(jwtToken))
            {
                // Add model state error if the login fails
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }
            // Store the token in an HTTP-only cookie Utility.Encryption.EncryptMessage(jwtToken,"ponmlkjihgfedcba", "6543210987654321")
            Response.Cookies.Append("egtdata", jwtToken, new CookieOptions
            {
                HttpOnly = false,
                Secure = false, // Set to true if using HTTPS
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddHours(1) // Set expiration as needed
            });

            var claims = await DecodeJwtTokenAsync(jwtToken);

          
            var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
         
            // Sign in the user with cookie-based authentication
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            
            // On successful login, redirect to ReturnUrl
            return LocalRedirect(ReturnUrl);
        }

        private async Task<List<Claim>> DecodeJwtTokenAsync(string token)
        {
            var handler = new JwtSecurityTokenHandler();
         
            // Check if the token is in a valid JWT format
            if (handler.CanReadToken(token.Trim()))
            {
                // Create claims
                var claims = new List<Claim>();
                var jwtToken = handler.ReadJwtToken(token.Trim());
                // Decode the payload
                var payload = jwtToken.Payload;
                foreach (var claim in payload)
                {
                    claims.Add(new Claim(claim.Key, claim.Value.ToString() ?? ""));
                  
                }
                return claims;
            }
            else
            {
                return null;
            }
               
        }

        private async Task<string> ParseJSON(string json)
        {
            // The input JSON string (concatenated JSON objects)
            string jsonString = json;

            // Splitting the string into individual JSON objects based on assumption (end of first JSON object is after "user_name")
            string[] jsonParts = jsonString.Split(new String[] { "}{" }, StringSplitOptions.None);

            // Add the curly braces back to complete the two separate JSON objects
            jsonParts[0] += "}";
            jsonParts[1] = "{" + jsonParts[1];

            // Parse each JSON object using JObject
            JObject token1 = JObject.Parse(jsonParts[0]);
            JObject token2 = JObject.Parse(jsonParts[1]);
            return token1["access_token"].ToString();
        }

        private async Task<string> GetJwtTokenAsync(string username, string password)
        {
            // Define your Web API URL here
            string apiUrl = GlobalConstants.ValidIssuer + "/token";  // Replace with your Web API URL

            using (var httpClient = new HttpClient())
            {
                // If the API expects client_id and client_secret in the headers (Basic Auth)
                var clientId = GlobalConstants.ClientId;
                var clientSecret = GlobalConstants.ClientSecret;
                var authToken = Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}");
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));

                // Prepare the data for the request
                var data = new Dictionary<string, string>
            {
                { "grant_type", "password" },
                { "username", username },
                { "password", password }

            };

                // Make the HTTP POST request
                var response = await httpClient.PostAsync(apiUrl, new FormUrlEncodedContent(data));


                if (response.IsSuccessStatusCode)
                {
                    // Read and parse the JWT token from the response
                    var responseString = await response.Content.ReadAsStringAsync();
                    var jsonResponse = await ParseJSON(responseString);
                    return jsonResponse;
                }
                else
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    JObject err = JObject.Parse(responseString);
                    ModelState.AddModelError(string.Empty, err["error_description"].ToString());
                                   
                    // If the request failed, return null or an empty string
                    return null;
                }
            }
        }
    }
}
