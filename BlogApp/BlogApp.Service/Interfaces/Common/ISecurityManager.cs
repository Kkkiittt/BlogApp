namespace BlogApp.Service.Interfaces.Common;

public interface ISecurityManager
{
	public (string hash, string salt) Hash(string s);
	public bool Verify(string hash, string password, string salt);
}
