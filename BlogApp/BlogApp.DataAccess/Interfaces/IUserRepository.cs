using BlogApp.Domain.Entities;

namespace BlogApp.DataAccess.Interfaces;

public interface IUserRepository
{
	public Task<bool> AddAsync(User entity);
	public Task<bool> UpdateAsync(User entity);
	public Task<bool> DeleteAsync(int id);
	public Task<User> GetAsync(int id);
	public Task<User> GetAsync(string email);
}
