using BlogApp.Service.Common.Helpers;
using BlogApp.Service.Interfaces;
using BlogApp.Service.Interfaces.Common;
using BlogApp.Service.Services;
using BlogApp.Service.Services.Common;

namespace BlogApp.Web.Configurations;

public static class ServiceConfiguration
{
	public static void ConfigureService(this WebApplicationBuilder builder)
	{
		builder.Services.AddScoped<IImageService, ImageService>();
		builder.Services.AddScoped<IEmailService, EmailService>();
		builder.Services.AddScoped<IAuthManager, AuthManager>();
		builder.Services.AddScoped<IDtoService, DtoService>();
		builder.Services.AddScoped<IPaginatorService, PaginatorService>();
		builder.Services.AddScoped<ISecurityManager, SecurityManager>();
		builder.Services.AddScoped<IViewModelService, ViewModelService>();
		builder.Services.AddScoped<IArticleService, ArticleService>();
		builder.Services.AddScoped<IIdentityService, IdentityService>();
		builder.Services.AddScoped<IUserService, UserService>();
	}
}
