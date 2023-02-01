using System.Net;

using BlogApp.Web.Configurations;
using BlogApp.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.ConfigureDataAccess();
builder.ConfigureService();
builder.ConfigureAuth();
var app = builder.Build();
if(!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}
app.UseStatusCodePages(async context =>
{
	if(context.HttpContext.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
	{
		context.HttpContext.Response.Redirect("../users/login");
	}
});
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseMiddleware<TokenRedirectMiddleWare>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
