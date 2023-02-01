using BlogApp.Service.Enums;
using BlogApp.Service.ViewModels.Articles;

namespace BlogApp.Service.Dtos.Articles;

public class ArticleViewDto
{
	public string Title { get; set; } = string.Empty;
	public OrderBy Order { get; set; } = OrderBy.None;
	public int Page { get; set; } = 1;
	public IEnumerable<ArticleBaseViewModel> Articles { get; set; } = Enumerable.Empty<ArticleBaseViewModel>();
}
