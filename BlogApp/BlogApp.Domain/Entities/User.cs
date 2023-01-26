using BlogApp.Domain.Entities.Common;

namespace BlogApp.Domain.Entities;

public class User : BaseEntity
{
	public string Name { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
	public string Salt { get; set; } = string.Empty;
	public string Image { get; set; } = string.Empty;
	public bool EmailVerified { get; set; }
	public DateTime Created { get; set; }
	public DateTime Updated { get; set; }
	public virtual IList<Article> Articles { get; set; }
}
