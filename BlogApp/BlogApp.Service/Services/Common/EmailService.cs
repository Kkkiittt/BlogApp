using System.Net;
using System.Net.Mail;

using BlogApp.Service.Interfaces.Common;

using Microsoft.Extensions.Configuration;

namespace BlogApp.Service.Common.Helpers;

public class EmailService : IEmailService
{
	private readonly IConfiguration _config;

	public EmailService(IConfiguration configuration)
	{
		_config = configuration.GetSection("EmailConnection");
	}

	public async Task<bool> Send(string content, string email)
	{
		MailAddress from = new(_config["Email"], "Blog");
		MailAddress to = new(email);
		MailMessage message = new(from, to);
		message.Subject = "Verification Code for BlogApp";
		message.Body = $"<h2>{content}</h2>";
		message.IsBodyHtml = true;
		SmtpClient client = new SmtpClient(_config["Host"], int.Parse(_config["Port"]));
		client.Credentials = new NetworkCredential(_config["Email"], _config["Password"]);
		await client.SendMailAsync(message);
		return true;
	}
}
