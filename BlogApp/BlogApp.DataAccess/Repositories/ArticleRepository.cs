using BlogApp.DataAccess.DbContexts;
using BlogApp.DataAccess.Interfaces;
using BlogApp.Domain.Entities;

namespace BlogApp.DataAccess.Repositories;

public class ArticleRepository : IArticleRepository
{
	private readonly AppDbContext _dbContext;

	public ArticleRepository(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<bool> AddAsync(Article entity)
	{
		_dbContext.Articles.Add(entity);
		return await _dbContext.SaveChangesAsync() > 0;
	}

	public async Task<bool> DeleteAsync(int id)
	{
		_dbContext.Articles.Remove(await GetAsync(id));
		return await _dbContext.SaveChangesAsync() > 0;
	}

	public IQueryable<Article> GetAll()
	{
		return _dbContext.Articles;
	}

	public async Task<Article> GetAsync(int id)
	{
		Article? entity = await _dbContext.Articles.FindAsync(id);
		if(entity == null)
		{
			throw new Exception("Article not found");
		}
		await _dbContext.Entry(entity).Reference(x => x.User).LoadAsync();
		return entity;
	}

	public async Task<bool> UpdateAsync(Article entity)
	{
		_dbContext.Articles.Update(entity);
		return await _dbContext.SaveChangesAsync() > 0;
	}
}
