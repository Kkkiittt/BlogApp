using Microsoft.AspNetCore.Http;

namespace BlogApp.Service.Dtos.Users;

public class UserRegisterDto
{
	public string Name { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
	public IFormFile? Image { get; set; }
}