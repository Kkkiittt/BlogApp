using BlogApp.Service.Common.Helpers;
using BlogApp.Service.Interfaces;
using BlogApp.Service.Interfaces.Common;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace BlogApp.Service.Services;

public class BaseService
{
	protected readonly IDtoService _dto;
	protected readonly IIdentityService _identity;
	protected readonly IEmailService _email;
	protected readonly IImageService _image;
	protected readonly IViewModelService _viewModel;
	protected readonly ISecurityManager _security;
	protected readonly IAuthManager _auth;

	public BaseService( IIdentityService identity, IHostingEnvironment environment, IDtoService dto, IViewModelService viewModel, ISecurityManager security, IAuthManager auth, IImageService image, IEmailService email)
	{
		_dto = dto;
		_identity = identity;
		_email = email;
		_image = image;
		_viewModel = viewModel;
		_security = security;
		_auth = auth;
	}
}
