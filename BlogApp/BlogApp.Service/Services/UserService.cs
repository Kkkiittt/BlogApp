using BlogApp.DataAccess.Interfaces;
using BlogApp.Domain.Entities;
using BlogApp.Service.Dtos.Users;
using BlogApp.Service.Interfaces;
using BlogApp.Service.Interfaces.Common;
using BlogApp.Service.ViewModels.Users;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace BlogApp.Service.Services;

public class UserService : BaseService, IUserService
{
	private readonly IUserRepository _repository;

	public UserService(IHostingEnvironment environment, IUserRepository repository, IIdentityService identity, IDtoService helper, IViewModelService viewModel, ISecurityManager security, IAuthManager auth, IEmailService email, IImageService image) : base(identity, environment, helper, viewModel, security, auth, image, email)
	{
		_repository = repository;
	}

	public async Task<bool> DeleteAsync()
	{
		int? id = _identity.Id;
		if(id == null)
			throw new Exception("Not authorized");
		return await _repository.DeleteAsync((int)id);
	}

	public async Task<UserViewModel> GetAsync(int? id)
	{
		if(id is not null)
			return _viewModel.To(await _repository.GetAsync((int)id));
		else if(_identity.Id is not null)
			return _viewModel.To(await _repository.GetAsync((int)_identity.Id));
		else
			throw new Exception("Unauthorized");
	}

	public async Task<string> LoginAsync(UserLoginDto dto)
	{
		var entity = await _repository.GetAsync(dto.Email);
		if(_security.Verify(entity.Password, dto.Password, entity.Salt))
			return _auth.GenerateToken(entity);
		throw new Exception($"Failed to login {dto.Email}");
	}

	public async Task<bool> RegisterAsync(UserRegisterDto dto)
	{
		return await _repository.AddAsync(await _dto.ToEntity(dto));
	}

	public async Task<bool> UpdateAsync(UserRegisterDto dto, int id)
	{
		var entity = await _dto.ToEntity(dto);
		entity.Id = id;
		entity.Updated = DateTime.Now;
		return await _repository.UpdateAsync(entity);
	}
	public int Id
	{
		get
		{
			return _identity.Id is null ? 0 : (int)_identity.Id;
		}
	}
}
