using System.IO;

namespace Mtf.Helper
{
	public static class DirectoryExtension
	{
		private static readonly string[] ApplicationDirectories = new string[]
		{
			PathProvider.Maps,
			PathProvider.Music,
			PathProvider.SoundEffects,
			PathProvider.Characters
		};

		public static void CreateApplicationDirectories()
		{
			foreach (var directory in ApplicationDirectories)
			{
				CreateIfNotExists(directory);
			}
		}

		public static void CreateIfNotExists(string directory)
		{
			if (!Directory.Exists(directory))
			{
				Directory.CreateDirectory(directory);
			}
		}
	}
}
