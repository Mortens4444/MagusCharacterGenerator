using Mtf.Languages;
using System;
using System.Windows.Forms;

namespace Mtf.Helper
{
	public static class ErrorBox
	{
		public static void Show(Exception ex)
		{
			Show(ex.GetType().ToString(), ex.Message);
		}

		public static void Show(string text)
		{
			Show(Lng.Elem("General error"), text);
		}

		public static void Show(string caption, string text)
		{
			MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
		}
	}
}
