using BlogApp.Service.Common.Utils;
using BlogApp.Service.Dtos.Articles;
using BlogApp.Service.ViewModels.Articles;

namespace BlogApp.Service.Interfaces;

public interface IArticleService
{
	public Task<bool> CreateAsync(ArticleCreateDto dto);
	public Task<bool> UpdateAsync(ArticleCreateDto dto, int id);
	public Task<bool> DeleteAsync(int id);
	public Task<IEnumerable<ArticleBaseViewModel>> GetAllAsync(PaginationParams @params);
	public Task<ArticleViewModel> GetAsync(int id);
	public Task<ArticleViewModel> GetAsync(string name);
	public Task<IEnumerable<ArticleBaseViewModel>> SearchAsync(string name, PaginationParams @params);
}
