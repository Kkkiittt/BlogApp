using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using BlogApp.Domain.Entities;
using BlogApp.Service.Interfaces;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BlogApp.Service.Services.Common;

public class AuthManager : IAuthManager
{
	private readonly IConfiguration _config;

	public AuthManager(IConfiguration config)
	{
		_config = config.GetSection("JWT");
	}

	public string GenerateToken(User user)
	{
		Claim[] claims = new[]
		{
			new Claim("Id", user.Id.ToString()),
			new Claim("Name", user.Name),
			new Claim("Email", user.Email),
			new Claim("Image", user.Image)
		};
		SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_config["SecretKey"]));
		SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256Signature);
		JwtSecurityToken tokenDescriptor = new JwtSecurityToken(_config["Issuer"], _config["Audience"], claims, expires: DateTime.Now.AddMonths(int.Parse(_config["Lifetime"])), signingCredentials: credentials);
		return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
	}
}
