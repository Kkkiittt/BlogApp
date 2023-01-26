using BlogApp.DataAccess.DbContexts;
using BlogApp.DataAccess.Interfaces;
using BlogApp.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace BlogApp.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
	private readonly AppDbContext _dbContext;

	public UserRepository(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<bool> AddAsync(User entity)
	{
		_dbContext.Users.Add(entity);
		return await _dbContext.SaveChangesAsync() > 0;
	}

	public async Task<bool> DeleteAsync(int id)
	{
		_dbContext.Users.Remove(await GetAsync(id));
		return await _dbContext.SaveChangesAsync() > 0;
	}

	public async Task<User> GetAsync(int id)
	{
		var entity = await _dbContext.Users.FindAsync(id);
		if(entity == null)
		{
			throw new Exception("User not found");
		}
		return entity;
	}

	public async Task<User> GetAsync(string email)
	{
		var entity = await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
		if(entity == null)
		{
			throw new Exception("User not found");
		}
		return entity;
	}

	public async Task<bool> UpdateAsync(User entity)
	{
		_dbContext.Users.Update(entity);
		return await _dbContext.SaveChangesAsync() > 0;
	}
}
