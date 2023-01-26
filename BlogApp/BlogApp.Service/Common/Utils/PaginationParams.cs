namespace BlogApp.Service.Common.Utils;

public class PaginationParams
{
	public int Number { get; set; }
	public int Size { get; set; }

	public PaginationParams(int number, int size)
	{
		Number = number;
		Size = size;
	}
}
