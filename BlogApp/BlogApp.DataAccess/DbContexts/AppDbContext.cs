using BlogApp.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace BlogApp.DataAccess.DbContexts;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{

	}
	public virtual DbSet<User> Users { get; set; } = default!;
	public virtual DbSet<Article> Articles { get; set; } = default!;
}
