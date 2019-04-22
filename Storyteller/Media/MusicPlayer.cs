using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Storyteller.Media
{
	public partial class MusicPlayer : Form
	{
		public const int MM_MCINOTIFY = 0x3B9;

		[DllImport("winmm.dll", EntryPoint = "mciSendString")]
		public static extern long MciSendString(string strCommand, StringBuilder strReturn, int returnedLength, IntPtr hwndCallback);

		public event EventHandler PlayStopped;

		public bool IsPlaying { get; private set; }

		public bool Loop { get; private set; }

		public string Filename { get; private set; }

		public string Id { get; private set; }

		public MusicPlayer(string filename)
		{
			Filename = filename;
			Id = Guid.NewGuid().ToString();
			var command = $"Open \"{filename}\" type mpegvideo alias {Id}";
			CommandExecuter(command);
		}

		~MusicPlayer()
		{
			var command = String.Concat("Close ", Id);
			CommandExecuter(command);
		}

		public void Play(bool loop = false)
		{
			Loop = loop;
			var command = loop ? $"Play {Id} REPEAT notify" : $"Play {Id} notify";
			CommandExecuter(command);
			IsPlaying = true;
		}

		public void Stop()
		{
			var command = String.Concat("Stop ", Id);
			CommandExecuter(command);
			IsPlaying = false;
		}

		public override string ToString()
		{
			return Path.GetFileNameWithoutExtension(Filename);
		}

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == MM_MCINOTIFY)
			{
				IsPlaying = false;
				OnPlayStopped(EventArgs.Empty);
			}

			base.WndProc(ref m);
		}

		void CommandExecuter(string command)
		{
			MciSendString(command, null, 0, Handle);
		}

		void OnPlayStopped(EventArgs e)
		{
			PlayStopped?.Invoke(this, e);
		}
	}
}
