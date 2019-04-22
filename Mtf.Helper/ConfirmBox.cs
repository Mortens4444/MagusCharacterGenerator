using Mtf.Languages;
using System.Windows.Forms;

namespace Mtf.Helper
{
	public static class ConfirmBox
	{
		public static bool Show(string text)
		{
			return Show(Lng.Elem("Confirmation"), text);
		}

		public static bool Show(string caption, string text)
		{
			return MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
		}
	}
}
