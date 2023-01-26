using BlogApp.Service.Dtos.Users;
using BlogApp.Service.ViewModels.Users;

namespace BlogApp.Service.Interfaces;

public interface IUserService
{
	public Task<bool> RegisterAsync(UserRegisterDto dto);
	public Task<bool> UpdateAsync(UserRegisterDto dto, int id);
	public Task<string> LoginAsync(UserLoginDto dto);
	public Task<UserViewModel> GetAsync(int? id);
	public Task<bool> DeleteAsync();
}
