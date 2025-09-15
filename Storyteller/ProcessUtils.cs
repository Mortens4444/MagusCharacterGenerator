using System.Diagnostics;

namespace Storyteller;

public static class ProcessUtils
{
	public static Process? Start(string filePath)
	{
		if (!Directory.Exists(filePath))
		{
			return Process.Start(filePath);
		}

		return null;
	}
}
