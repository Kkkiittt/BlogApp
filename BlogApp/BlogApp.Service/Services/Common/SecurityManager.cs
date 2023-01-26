using System.Security.Cryptography;
using System.Text;

using BlogApp.Service.Interfaces.Common;

namespace BlogApp.Service.Services.Common;

public class SecurityManager : ISecurityManager
{
	private readonly SHA256 _engine;
	public SecurityManager()
	{
		_engine = SHA256.Create();
	}
	public (string hash, string salt) Hash(string s)
	{
		string salt = Guid.NewGuid().ToString();
		return (ComputeHash(s, salt), salt);
	}
	private string ComputeHash(string s, string salt)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(s + salt);
		return Convert.ToBase64String(_engine.ComputeHash(bytes));
	}
	public bool Verify(string hash, string s, string salt)
	{
		return hash == ComputeHash(s, salt);
	}
}
