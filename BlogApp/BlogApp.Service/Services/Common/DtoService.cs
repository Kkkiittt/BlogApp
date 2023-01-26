using BlogApp.Domain.Entities;
using BlogApp.Service.Common.Helpers;
using BlogApp.Service.Dtos.Articles;
using BlogApp.Service.Dtos.Users;
using BlogApp.Service.Interfaces;
using BlogApp.Service.Interfaces.Common;

namespace BlogApp.Service.Services.Common;

public class DtoService : IDtoService
{
	private readonly ISecurityManager _security;
	private readonly IIdentityService _identity;
	private readonly IImageService _image;

	public DtoService(ISecurityManager security, IImageService image, IIdentityService identity)
	{
		_security = security;
		_image = image;
		_identity = identity;
	}

	public async Task<User> ToEntity(UserRegisterDto dto)
	{
		var res = _security.Hash(dto.Password);
		return new User()
		{
			Created = DateTime.Now,
			Email = dto.Email,
			EmailVerified = false,
			Name = dto.Name,
			Password = res.hash,
			Salt = res.salt,
			Articles = new List<Article>(),
			Image = await _image.SaveImageAsync(dto.Image),
			Updated = DateTime.Now,
		};
	}

	public async Task<Article> ToEntity(ArticleCreateDto dto)
	{
		return new Article()
		{
			Content = dto.Content,
			Created = DateTime.Now,
			Title = dto.Title,
			Updated = DateTime.Now,
			Views = 0,
			Image = await _image.SaveImageAsync(dto.Image),
			UserId = _identity.Id is null ? throw new Exception("Not authorized") : (int)_identity.Id,
		};
	}
}
