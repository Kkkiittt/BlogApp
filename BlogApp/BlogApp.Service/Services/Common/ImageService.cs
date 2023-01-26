using BlogApp.Service.Interfaces.Common;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace BlogApp.Service.Common.Helpers;

public class ImageService:IImageService
{
	private readonly string _imagePath;
	public ImageService(IHostingEnvironment environment)
	{
		_imagePath = Path.Combine(environment.WebRootPath, "images");
	}
	public async Task<string> SaveImageAsync(IFormFile? file)
	{
		if(file == null)
		{
			return "";
		}
		string name = MakeImageName(file);
		FileStream stream = new FileStream(Path.Combine(_imagePath, name), FileMode.Create);
		try
		{
			await file.CopyToAsync(stream);
			return Path.Combine("images", name);
		}
		catch
		{
			return "";
		}
		finally
		{
			stream.Close();
		}
	}
	private string MakeImageName(IFormFile file)
	{
		return "IMG_" + Guid.NewGuid().ToString();
	}
}
