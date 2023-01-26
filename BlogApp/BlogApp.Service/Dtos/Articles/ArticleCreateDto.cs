using Microsoft.AspNetCore.Http;

namespace BlogApp.Service.Dtos.Articles;

public class ArticleCreateDto
{
	public string Title { get; set; } = string.Empty;
	public string Content { get; set; } = string.Empty;
	public IFormFile? Image { get; set; }
}
