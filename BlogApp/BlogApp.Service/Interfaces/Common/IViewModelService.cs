using BlogApp.Domain.Entities;
using BlogApp.Service.ViewModels.Articles;
using BlogApp.Service.ViewModels.Users;

namespace BlogApp.Service.Interfaces.Common;

public interface IViewModelService
{
	public ArticleBaseViewModel ToBase(Article entity);
	public ArticleViewModel To(Article entity);
	public UserBaseViewModel ToBase(User entity);
	public UserViewModel To(User entity);
}
