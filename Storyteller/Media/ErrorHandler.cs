using DirectShowLib;

namespace Storyteller.Media
{
	public class ErrorHandler
	{
		public void ShowError(int statusCode, string message)
		{
			if (statusCode < 0)
			{
				Console.WriteLine(message);
				DsError.ThrowExceptionForHR(statusCode);
			}
		}
	}
}
