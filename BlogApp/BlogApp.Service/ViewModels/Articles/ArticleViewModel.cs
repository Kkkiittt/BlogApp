using BlogApp.Service.ViewModels.Users;

namespace BlogApp.Service.ViewModels.Articles;

public class ArticleViewModel : ArticleBaseViewModel
{
	public string Content { get; set; } = string.Empty;
	public DateTime? Updated { get; set; }
	public UserBaseViewModel User { get; set; } = new UserBaseViewModel();
}
