using BlogApp.Domain.Entities;
using BlogApp.Service.Interfaces.Common;
using BlogApp.Service.ViewModels.Articles;
using BlogApp.Service.ViewModels.Users;

namespace BlogApp.Service.Services.Common;

public class ViewModelService : IViewModelService
{
	public ArticleViewModel To(Article entity)
	{
		return new ArticleViewModel()
		{
			Content = entity.Content,
			Created = entity.Created,
			Id = entity.Id,
			Image = entity.Image,
			Title = entity.Title,
			IsUpdated = entity.Updated is not null,
			Updated = entity.Updated,
			User = ToBase(entity.User),
		};
	}

	public UserViewModel To(User entity)
	{
		return new UserViewModel()
		{
			Created = entity.Created,
			Email = entity.Email,
			Id = entity.Id,
			Image = entity.Image,
			Name = entity.Name,
			Updated = entity.Updated,
			Articles = entity.Articles.Select(x => ToBase(x)).ToList(),
		};
	}

	public ArticleBaseViewModel ToBase(Article entity)
	{
		return new ArticleBaseViewModel()
		{
			Created = entity.Created,
			Id = entity.Id,
			Image = entity.Image,
			IsUpdated = entity.Updated is not null,
			Title = entity.Title,
		};
	}

	public UserBaseViewModel ToBase(User entity)
	{
		return new UserBaseViewModel()
		{
			Id = entity.Id,
			Image = entity.Image,
			Name = entity.Name,
		};
	}
}
