using BlogApp.Service.Common.Utils;

namespace BlogApp.Service.Interfaces;

public interface IPaginatorService
{
	public Task<IEnumerable<T>> PaginateAsync<T>(IQueryable<T> arr, PaginationParams @params);
}
