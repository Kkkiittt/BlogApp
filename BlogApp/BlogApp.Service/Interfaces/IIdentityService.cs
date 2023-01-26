namespace BlogApp.Service.Interfaces;

public interface IIdentityService
{
	public int? Id { get; }
	public string Name { get; }
	public string Email { get; }
	public string Image { get; }
}
