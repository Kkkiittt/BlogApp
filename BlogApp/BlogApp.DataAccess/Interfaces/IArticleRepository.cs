using BlogApp.Domain.Entities;

namespace BlogApp.DataAccess.Interfaces;

public interface IArticleRepository
{
	public Task<bool> AddAsync(Article entity);
	public Task<bool> UpdateAsync(Article entity);
	public Task<bool> DeleteAsync(int id);
	public Task<Article> GetAsync(int id);
	public IQueryable<Article> GetAll();
}
