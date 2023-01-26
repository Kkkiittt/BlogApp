using Microsoft.AspNetCore.Http;

namespace BlogApp.Service.Interfaces.Common;

public interface IImageService
{
	public Task<string> SaveImageAsync(IFormFile? file);
}
