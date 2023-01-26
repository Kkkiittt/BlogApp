namespace BlogApp.Service.Interfaces.Common;

public interface IEmailService
{
	public Task<bool> Send(string email, string content);
}
