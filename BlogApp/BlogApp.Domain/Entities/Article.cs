using BlogApp.Domain.Entities.Common;

namespace BlogApp.Domain.Entities;

public class Article : BaseEntity
{
	public int UserId { get; set; }
	public virtual User User { get; set; } = default!;
	public int Views { get; set; }
	public string Title { get; set; } = string.Empty;
	public string Content { get; set; } = string.Empty;
	public string Image { get; set; } = string.Empty;
	public DateTime Created { get; set; }
	public DateTime? Updated { get; set; }
}
