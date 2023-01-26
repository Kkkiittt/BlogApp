using BlogApp.Domain.Entities;
using BlogApp.Service.Dtos.Articles;
using BlogApp.Service.Dtos.Users;

namespace BlogApp.Service.Interfaces.Common;

public interface IDtoService
{
	public Task<User> ToEntity(UserRegisterDto dto);
	public Task<Article> ToEntity(ArticleCreateDto dto);
}
