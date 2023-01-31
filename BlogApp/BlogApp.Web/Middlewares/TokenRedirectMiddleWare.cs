
namespace BlogApp.Web.Middlewares;

public class TokenRedirectMiddleWare
{
	private readonly RequestDelegate _next;

	public TokenRedirectMiddleWare(RequestDelegate next)
	{
		_next = next;
	}
	public Task InvokeAsync(HttpContext context)
	{
		if(context.Request.Cookies.TryGetValue("X-Access-Token", out var token))
		{
			context.Request.Headers.Add("Authorization", $"Bearer {token}");
		}
		return _next(context);
	}
}