using BlogApp.Service.Interfaces;

using Microsoft.AspNetCore.Http;

namespace BlogApp.Service.Services;

public class IdentityService : IIdentityService
{
	private readonly IHttpContextAccessor _accessor;

	public IdentityService(IHttpContextAccessor accessor)
	{
		_accessor = accessor;
	}

	public int? Id
	{
		get
		{
			var res = _accessor.HttpContext.User.FindFirst("Id");
			return res is null ? null : int.Parse(res.Value);
		}
	}

	public string Name
	{
		get
		{
			var res = _accessor.HttpContext.User.FindFirst("Name");
			return res is null ? string.Empty : res.Value;
		}
	}

	public string Email
	{
		get
		{
			var res = _accessor.HttpContext.User.FindFirst("Email");
			return res is null ? string.Empty : res.Value;
		}
	}

	public string Image
	{
		get
		{
			var res = _accessor.HttpContext.User.FindFirst("Image");
			return res is null ? "images/Account.png" : res.Value;
		}
	}
}
