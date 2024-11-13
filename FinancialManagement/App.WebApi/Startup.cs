using Microsoft.Owin;
using Microsoft.Owin.Security.Jwt;
using Owin;
using Microsoft.Owin.Security;
using System.Text;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(YourNamespace.Startup))]

namespace YourNamespace
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Enable CORS (optional but recommended for cross-origin requests)
            app.UseCors(CorsOptions.AllowAll);

            // Configure Web API
            HttpConfiguration config = new HttpConfiguration();
            ConfigureAuth(app);
            app.UseWebApi(config);
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            var issuer = "YourIssuer";
            var audience = "YourAudience";
            var secretKey = "YourVeryLongSecretKeyThatIsAtLeast32CharactersLong"; // You should store this in a secure location like web.config or environment variable

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
            };

            // Use JWT bearer authentication
            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                TokenValidationParameters = tokenValidationParameters
            });
        }
    }
}
