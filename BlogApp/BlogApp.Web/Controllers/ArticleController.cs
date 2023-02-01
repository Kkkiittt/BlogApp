using BlogApp.Service.Common.Utils;
using BlogApp.Service.Dtos.Articles;
using BlogApp.Service.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Web.Controllers;
[Route("articles")]
[Authorize]
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
				return RedirectToAction("all/", "articles", 1);
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
	[HttpGet("search")]
	public ViewResult SearchAsync()
	{
		return View("Search");
	}
	[HttpPost("search")]
	public async Task<IActionResult> SearchAsync(ArticleSearchDto dto)
	{
		ViewBag.Title =$"Search results for \"{dto.Title}\"";
		return View("All", await _service.SearchAsync(dto.Title, new PaginationParams(dto.Page, _pageSize)));
	}
	[HttpGet("{id}")]
	public async Task<ViewResult> GetAsync(int id)
	{
		return View("One", await _service.GetAsync(id));
	}
}
