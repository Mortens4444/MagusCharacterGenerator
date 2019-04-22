using System.IO;
using System.Windows.Forms;

namespace Mtf.Helper
{
	public static class PathProvider
	{
		public static string Maps => Path.Combine(Application.StartupPath, "Maps");

		public static string Music => Path.Combine(Application.StartupPath, "Music");

		public static string SoundEffects => Path.Combine(Application.StartupPath, "Sound effects");

		public static string Characters => Path.Combine(Application.StartupPath, "Characters");

		public static string VideoClips => Path.Combine(Application.StartupPath, "Video clips");
	}
}
