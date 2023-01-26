using System.Text.Json.Serialization;

using BlogApp.Service.Common.Utils;
using BlogApp.Service.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

namespace BlogApp.Service.Services.Common;

public class PaginatorService : IPaginatorService
{
	private readonly IHttpContextAccessor _accessor;

	public PaginatorService(IHttpContextAccessor accessor)
	{
		_accessor = accessor;
	}

	public async Task<IEnumerable<T>> PaginateAsync<T>(IQueryable<T> items, PaginationParams @params)
	{
		int total = await items.CountAsync();
		int pages = (int)Math.Ceiling(total / (double)@params.Size);
		PaginationMetaData metaData = new PaginationMetaData()
		{
			PageSize = @params.Size,
			CurrentPage = @params.Number,
			TotalItems = total,
			TotalPages = pages,
			HasPrevious = @params.Number > 1,
			HasNext = @params.Number < pages,
		};
		string json = JsonConvert.SerializeObject(metaData);
		_accessor.HttpContext.Response.Headers.Add("X-Pagination", json);
		return await items.Skip(@params.Number * @params.Size - @params.Size).Take(@params.Size).ToListAsync();
	}
}
