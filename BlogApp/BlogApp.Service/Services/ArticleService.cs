using BlogApp.DataAccess.Interfaces;
using BlogApp.Service.Common.Utils;
using BlogApp.Service.Dtos.Articles;
using BlogApp.Service.Interfaces;
using BlogApp.Service.Interfaces.Common;
using BlogApp.Service.ViewModels.Articles;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlogApp.Service.Services;

public class ArticleService : BaseService, IArticleService
{
	private IArticleRepository _repository;
	private IPaginatorService _paginator;

	public ArticleService(IPaginatorService paginator, IArticleRepository repository, IIdentityService identity, IHostingEnvironment environment, IDtoService dto, IViewModelService viewModel, ISecurityManager security, IAuthManager auth, IEmailService email, IImageService image) : base(identity, environment, dto, viewModel, security, auth, image, email)
	{
		_repository = repository;
		_paginator = paginator;
	}

	public async Task<bool> CreateAsync(ArticleCreateDto dto)
	{
		return await _repository.AddAsync(await _dto.ToEntity(dto));
	}

	public async Task<bool> DeleteAsync(int id)
	{
		var entity = await _repository.GetAsync(id);
		if(entity.UserId != _identity.Id)
			throw new Exception("You can't delete this article");
		return await _repository.DeleteAsync(id);
	}

	public async Task<IEnumerable<ArticleBaseViewModel>> GetAllAsync(PaginationParams @params)
	{
		return (await _paginator.PaginateAsync(_repository.GetAll(), @params)).
			Select(art => _viewModel.ToBase(art));
	}

	public async Task<ArticleViewModel> GetAsync(int id)
	{
		var entity = await _repository.GetAsync(id);
		entity.Views += 1;
		await _repository.UpdateAsync(entity);
		return _viewModel.To(entity);
	}

	public async Task<ArticleViewModel> GetAsync(string name)
	{
		var entity = await _repository.GetAll().FirstOrDefaultAsync(art => art.Title.ToLower().Trim() == name.ToLower().Trim());
		entity.Views += 1;
		await _repository.UpdateAsync(entity);
		return _viewModel.To(entity);
	}

	public async Task<IEnumerable<ArticleBaseViewModel>> SearchAsync(string name, PaginationParams @params)
	{
		return (await _paginator.PaginateAsync(_repository.GetAll()
			.OrderByDescending(x => x.Title.ToLower() == name.ToLower())
			.ThenByDescending(x => x.Title.ToLower().StartsWith(name.ToLower()))
			.ThenByDescending(x => x.Title.ToLower().EndsWith(name.ToLower()))
			.ThenByDescending(x => x.Title.ToLower().Contains(name.ToLower()))
			.ThenByDescending(x => x.Content.ToLower().Contains(name.ToLower()))
			, @params))
			.Select(x => _viewModel.ToBase(x));
	}

	public async Task<bool> UpdateAsync(ArticleCreateDto dto, int id)
	{
		var entity = await _dto.ToEntity(dto);
		entity.Id = id;
		entity.Updated = DateTime.Now;
		return await _repository.UpdateAsync(entity);
	}
}
