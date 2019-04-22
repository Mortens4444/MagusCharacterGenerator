using System.IO;
using System.IO.Compression;

namespace Mtf.Helper
{
	public static class Zip
	{
		public static string Extract(string zipFile, string parentDestinationFolder)
		{
			var destinationFolder = Path.Combine(parentDestinationFolder, Path.GetFileNameWithoutExtension(zipFile));
			var zip = new ZipArchive(new FileStream(zipFile, FileMode.Open));
			foreach (var entry in zip.Entries)
			{
				string destinationPath = Path.GetFullPath(Path.Combine(destinationFolder, entry.FullName));
				var folder = Path.GetDirectoryName(destinationPath);
				DirectoryExtension.CreateIfNotExists(folder);
				if (entry.Length != 0 && !File.Exists(destinationPath))
				{
					entry.ExtractToFile(destinationPath);
				}
			}
			return destinationFolder;
		}
	}
}
