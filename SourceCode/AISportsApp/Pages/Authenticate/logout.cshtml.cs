using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;


namespace AISportsApp.Pages.Authenticate
{
    public class LogoutModel : PageModel
    {
        // POST: Handles the logout operation
        public async Task<IActionResult> OnPostLogoutAsync()
        {
            // Sign out from the Cookie Authentication
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
           
            // Clear all session data (if applicable)
            // HttpContext.Session.Clear();

            // Remove the authentication cookie explicitly
         
            Response.Cookies.Append(".AspNetCore.Cookies", "", new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(-1)
           
            });

            // Clear token from cookie
            Response.Cookies.Append("egtdata", "", new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(-1)

            });
            // Redirect the user to the login page or homepage
            return RedirectToPage("/Authenticate/Login");
        }
    }
}
