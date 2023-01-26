using BlogApp.Service.Common.Utils;
using BlogApp.Service.Dtos.Articles;
using BlogApp.Service.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Web.Controllers;
[Route("articles")]
public class ArticleController : Controller
{
	private readonly IArticleService _service;
	private readonly int _pageSize = 30;

	public ArticleController(IArticleService service)
	{
		_service = service;
	}

	[HttpGet("create")]
	public ViewResult Create()
	{
		return View("Create");
	}
	[HttpPost]
	public async Task<IActionResult> CreateAsync(ArticleCreateDto dto)
	{
		if(ModelState.IsValid)
			if(await _service.CreateAsync(dto))
				return RedirectToAction("all/1", "articles");
			else
				return Create();
		else
			return Create();

	}
	[HttpGet("update/{id}")]
	public ViewResult Update(int id)
	{
		return View("Update", _service.GetAsync(id));
	}
	[HttpPut("{id}")]
	public async Task<IActionResult> Update(ArticleCreateDto dto, int id)
	{
		if(ModelState.IsValid)
			if(await _service.UpdateAsync(dto, id))
				return RedirectToAction(id.ToString(), "articles");
			else
				return Create();
		else
			return Create();
	}
	[HttpGet("all/{page}")]
	public async Task<ViewResult> GetAllAsync(int page = 1)
	{
		return View("All", await _service.GetAllAsync(new PaginationParams(_pageSize, page)));
	}
	[HttpGet("find/{title}")]
	public async Task<ViewResult> FindAsync(string title)
	{
		return View("One", await _service.GetAsync(title));
	}
	[HttpGet("{id}")]
	public async Task<ViewResult> GetAsync(int id)
	{
		return View("One", await _service.GetAsync(id));
	}
}
