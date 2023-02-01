using BlogApp.Service.Dtos.Users;
using BlogApp.Service.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Web.Controllers;
[Route("users")]
public class UserController : Controller
{
	private readonly IUserService _service;

	public UserController(IUserService service)
	{
		_service = service;
	}

	[HttpGet("register")]
	public ViewResult Register()
	{
		return View("Register");
	}
	[HttpPost("register")]
	public async Task<IActionResult> RegisterAsync(UserRegisterDto dto)
	{
		if(ModelState.IsValid)
			if(await _service.RegisterAsync(dto))
				return RedirectToAction("login", "users");
			else
				return Register();
		return Register();
	}
	[HttpGet("login")]
	public ViewResult Login()
	{
		return View("Login");
	}
	[HttpPost("login")]
	public async Task<IActionResult> LoginAsync(UserLoginDto dto)
	{
		if(ModelState.IsValid)
			try
			{
				var token = await _service.LoginAsync(dto);
				HttpContext.Response.Cookies.Append("X-Access-Token", token, new CookieOptions()
				{
					SameSite = SameSiteMode.Strict,
					HttpOnly = true
				});
				return RedirectToAction("", "articles");
			}
			catch
			{
				return Login();
			}
		return Login();
	}
	[HttpGet("logout")]
	public IActionResult Logout()
	{
		HttpContext.Response.Cookies.Append("X-Access-Token", "", new CookieOptions()
		{
			Expires = DateTime.Now.AddDays(-1),
		});
		return RedirectToAction("login", "users");
	}
	[HttpDelete]
	public async Task<IActionResult> DeleteAsync()
	{
		if(await _service.DeleteAsync())
			return RedirectToAction("register", "users");
		else
			return RedirectToAction("update", "users");
	}
	[HttpGet("update")]
	public async Task<IActionResult> UpdateAsync()
	{
		try
		{
			return View("Info", await _service.GetAsync(null));
		}
		catch(Exception ex) when(ex.Message == "Unauthorized")
		{
			return RedirectToAction("login", "users");
		}
	}
	[HttpPut("")]
	public async Task<IActionResult> UpdateAsync(UserRegisterDto dto)
	{
		if(ModelState.IsValid)
			if(await _service.UpdateAsync(dto))
				return RedirectToAction("", "articles");
			else
				return await UpdateAsync();
		else
			return await UpdateAsync();
	}
}
