using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

using System.Data.SqlClient;

using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Utility;
using System.Net;


public class APIOAuthAuthorizationServerProvider : OAuthAuthorizationServerProvider
{
    private readonly string connectionString = "Data Source=DESKTOP-1PDQRLS;Initial Catalog=AISportsPlatform;User ID=dev_zyzx;Password=pwd_zyzx";


    // The issuer of the token (your OAuth2 authorization server URL)
    private string Issuer = GlobalConstants.ValidIssuer;
    private string Audience = GlobalConstants.Audiance;           // The intended audience
    private string SecretKey = GlobalConstants.IssuerSigningKey; //Guid.NewGuid().ToString("N"); // This will generate a 32-character string (256 bits)
    private string clientId;
    private string clientSecret;

    // Validate the client credentials (ClientId and ClientSecret)
    public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    {
        

        // Try to extract the client credentials from the request
        if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
        {
            // If the client ID or secret is missing, return an error
            context.SetError("invalid_client", "Client credentials are missing.");
            return;
        }

        // Validate client credentials against the database
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            await conn.OpenAsync();

            //string hashedSecret = HashPassword(clientSecret); // Hash the client secret to compare

            // Query to validate the client ID and client secret
            string query = "SELECT TenantId FROM Tenant WHERE TenantId = @clientId AND TenantSecret = @clientSecret AND Is_Active = 1";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@clientId", clientId);
            cmd.Parameters.AddWithValue("@clientSecret", clientSecret);

            SqlDataReader reader = await cmd.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                // If the client is valid, validate the context
                context.Validated(clientId);
            }
            else
            {
                // If client is invalid, return an error
                context.SetError("invalid_client", "Client ID or secret is incorrect.");
            }
        }
    }

    // Validate the user's credentials (Username and Password)
    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    {
        // Allowing CORS for the token request
        context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

        string username = context.UserName; // Extracting the username
        string password = context.Password; // Extracting the password

        // Set token expiration (e.g., 30 minutes)
        var expirationTime = DateTime.UtcNow.AddMinutes(60);

        // Create the security key used to sign the JWT token
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);



        // Validate the username and password against the database
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            await conn.OpenAsync();

            // Hash the password to compare with the stored password hash
            //string hashedPassword = Utility.Encryption.HashPassword(password);

            string query = "SELECT TenantId,TenantName,TenantSecret,Location_ID,LocationName,UserId,UserGroupId,GroupName,UserName,Password,SubscriptionId,SubscriptionStartDate,SubscriptionEndDate,TenantActive,locationActive,UserActive FROM vwToken WHERE UserName=@username AND Password=@passwordHash AND TenantId = @clientId AND TenantSecret = @clientSecret";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@passwordHash", password);
            cmd.Parameters.AddWithValue("@clientId", clientId);
            cmd.Parameters.AddWithValue("@clientSecret", clientSecret);

            SqlDataReader reader = await cmd.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                // If user credentials are valid, create the identity
                await reader.ReadAsync();
               
                var identity = new ClaimsIdentity("JWT");
                identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, reader["Username"].ToString()));// Subject (usually username or user ID)
                identity.AddClaim(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())); // JWT ID (a unique ID for the token)
                identity.AddClaim(new Claim(JwtRegisteredClaimNames.Iss, Issuer));                   // Issuer of the token
                identity.AddClaim(new Claim(JwtRegisteredClaimNames.Aud, Audience));                // Audience of the token
                identity.AddClaim(new Claim(ClaimTypes.Name, reader["Username"].ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Role, reader["GroupName"].ToString()));
                identity.AddClaim(new Claim("http://egtasset/claims/tenantid", reader["TenantId"].ToString()));
                identity.AddClaim(new Claim("http://egtasset/claims/tenantname", reader["TenantName"].ToString()));
                identity.AddClaim(new Claim("http://egtasset/claims/tenantsecret", reader["TenantSecret"].ToString()));
                identity.AddClaim(new Claim("http://egtasset/claims/locationid", reader["Location_ID"].ToString()));
                identity.AddClaim(new Claim("http://egtasset/claims/locationname", reader["LocationName"].ToString()));
                identity.AddClaim(new Claim("http://egtasset/claims/userid", reader["UserId"].ToString()));
                identity.AddClaim(new Claim("http://egtasset/claims/usergroupid", reader["UserGroupId"].ToString()));

                identity.AddClaim(new Claim("http://egtasset/claims/password", reader["Password"].ToString()));
                identity.AddClaim(new Claim("http://egtasset/claims/subscriptionid", reader["SubscriptionId"].ToString()));
                identity.AddClaim(new Claim("http://egtasset/claims/subscriptionstartdate", reader["SubscriptionStartDate"].ToString()));
                identity.AddClaim(new Claim("http://egtasset/claims/subscriptionenddate", reader["SubscriptionEndDate"].ToString()));
                identity.AddClaim(new Claim("http://egtasset/claims/tenantactive", reader["TenantActive"].ToString()));
                identity.AddClaim(new Claim("http://egtasset/claims/locationactive", reader["locationActive"].ToString()));
                identity.AddClaim(new Claim("http://egtasset/claims/useractive", reader["UserActive"].ToString()));
                //identity.AddClaim(new Claim("http://egtasset/claims/signingkey", SecretKey.ToString()));


              
               // Generate the JWT token
                var token = new JwtSecurityToken(
                    issuer: Issuer,
                    audience: Audience,
                    claims: identity.Claims,
                    expires: expirationTime, // Set expiration time
                    signingCredentials: signingCredentials
                );

                // Serialize the JWT token into a string
                var tokenHandler = new JwtSecurityTokenHandler();
            
                var tokenString = tokenHandler.WriteToken(token);

             

               
                // If you want full control, you can modify the response directly
                var tokenResponse = new
                {
                    access_token = tokenString,
                    token_type = "bearer",
                    expires_in = expirationTime, 
                    user_name = context.UserName
                };

                // Modify the response manually if required
                var json = System.Text.Json.JsonSerializer.Serialize(tokenResponse);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);

                // Important: Validate the context to indicate that the credentials are correct
                context.Validated(identity);
                //var authProperties = new AuthenticationProperties
                //{
                //    // Optionally set additional authentication properties

                //};

                //// Finalize the token issuance by calling context.Validated() with the AuthenticationTicket
                //context.Validated(new AuthenticationTicket(identity, authProperties));

            }
            else
            {
                // If credentials are invalid, set an error
                context.SetError("invalid_grant", "The username or password or client data is incorrect or mismatched.");
            }
        }
    }
   
   

    //// Helper method to hash the passwords and secrets (for secure comparison)
    //private string HashPassword(string input)
    //{
    //    using (var sha256 = System.Security.Cryptography.SHA256.Create())
    //    {
    //        byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
    //        return BitConverter.ToString(bytes).Replace("-", "").ToLower();
    //    }
    //}
}
