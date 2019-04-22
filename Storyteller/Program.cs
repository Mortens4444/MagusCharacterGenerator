using Storyteller;
using System;
using System.Windows.Forms;

namespace StoryTeller
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
        static void Main()
        {
			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#if !DEBUG
			SplashScreen.ShowSplashScreen();
#endif
			MainForm mainForm;
			do
			{
				mainForm = new MainForm();
				Application.Run(mainForm);
			} while (mainForm.ChangeLanguage);
        }
    }
}
