using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


// Configure JWT Bearer Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.LogoutPath = "/authenticate/Logout";     // Logout page path
    options.LoginPath = "/authenticate/login";  // Path to login page
    options.AccessDeniedPath = "/authenticate/access-denied";  // Path to access denied page
    options.SlidingExpiration = false;
    //options.Cookie.HttpOnly = true;
    //options.Cookie.SecurePolicy = CookieSecurePolicy.Always;  // Only send cookie over HTTPS
    //options.Cookie.SameSite = SameSiteMode.Strict;  // Prevent CSRF attacks
})
.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,options =>
{
    options.UseSecurityTokenValidators = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = GlobalConstants.ValidIssuer, // Replace with your issuer
        ValidAudience = GlobalConstants.Audiance, // Replace with your audience
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(GlobalConstants.IssuerSigningKey)) // Replace with your key
    };

    // Handle token expiration (optional)
    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                context.Response.Headers.Add("Token-Expired", "true");
            }
            return Task.CompletedTask;

        },
        OnTokenValidated = context =>
        {
            // Log when a token is successfully validated
            var user = context.Principal.Identity.Name;
            context.HttpContext.Response.Headers.Add("Token-Validated", user);
            return Task.CompletedTask;
        }
    };
});

// Register IHttpContextAccessor for accessing cookies
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();  // Enable authentication middleware
app.UseAuthorization();   // Enable authorization middleware


// Middleware to catch 401 Unauthorized responses and redirect to login page
app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == 401)
    {
        // Redirect to login page if unauthorized
        context.Response.Redirect("/authenticate/login");
    }
});

app.MapRazorPages();


app.Run();
