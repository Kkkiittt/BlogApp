using BlogApp.DataAccess.DbContexts;
using BlogApp.DataAccess.Interfaces;
using BlogApp.DataAccess.Repositories;

using Microsoft.EntityFrameworkCore;

namespace BlogApp.Web.Configurations;

public static class DataAccessConfiguration
{
	public static void ConfigureDataAccess(this WebApplicationBuilder builder)
	{
		string connectionString = builder.Configuration.GetConnectionString("ElephantSQL");
		builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
		builder.Services.AddScoped<IUserRepository, UserRepository>();
		builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
	}
}
