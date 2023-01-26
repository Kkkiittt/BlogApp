namespace BlogApp.Service.ViewModels.Articles;

public class ArticleBaseViewModel
{
	public int Id { get; set; }
	public string Title { get; set; } = string.Empty;
	public string Image { get; set; } = string.Empty;
	public DateTime Created { get; set; }
	public bool IsUpdated { get; set; }
}
