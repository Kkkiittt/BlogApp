using BlogApp.Domain.Entities;

namespace BlogApp.Service.Interfaces;

public interface IAuthManager
{
	public string GenerateToken(User user);
}
