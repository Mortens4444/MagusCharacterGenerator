using Storyteller.Media;
using System.Windows.Forms;

namespace Storyteller.Converter
{
	public static class MusicPlayerToListViewItem
	{
		public static ListViewItem Convert(MusicPlayer musicPlayer)
		{
			return new ListViewItem(musicPlayer.ToString())
			{
				Name = musicPlayer.Id,
				Tag = musicPlayer
			};
		}
	}
}
