using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace BlogApp.Web.Configurations;

public static class JwtConfiguration
{
	public static void ConfigureAuth(this WebApplicationBuilder builder)
	{
		IConfigurationSection _config = builder.Configuration.GetSection("Jwt");
		builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
		{
			opt.TokenValidationParameters = new()
			{
				ValidateIssuer = true,
				ValidateAudience = false,
				ValidIssuer = _config["Issuer"],
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecretKey"]))
			};
		});
	}
}
