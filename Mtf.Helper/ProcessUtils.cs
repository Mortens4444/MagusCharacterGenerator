using System.Diagnostics;
using System.IO;

namespace Mtf.Helper
{
	public static class ProcessUtils
	{
		public static Process Start(string filePath)
		{
			if (!Directory.Exists(filePath))
			{
				return Process.Start(filePath);
			}

			return null;
		}
	}
}
