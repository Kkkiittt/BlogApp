using BlogApp.Service.ViewModels.Articles;

namespace BlogApp.Service.ViewModels.Users;

public class UserViewModel : UserBaseViewModel
{
	public string Email { get; set; } = string.Empty;
	public DateTime Created { get; set; }
	public DateTime Updated { get; set; }
	public IList<ArticleBaseViewModel> Articles { get; set; } = new List<ArticleBaseViewModel>();
}
