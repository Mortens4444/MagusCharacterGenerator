namespace Storyteller;

public partial class SplashScreen : Form
{
	public delegate void VoidResultVoidParams();

	public SplashScreen()
	{
		InitializeComponent();
	}

	public static void ShowSplashScreen()
	{
		var splashScreen = new SplashScreen();
		splashScreen.Show();
		Task.Factory.StartNew(() =>
		{
			Thread.Sleep(3000);
			splashScreen.Invoke(new VoidResultVoidParams(splashScreen.Close));
		});
	}
}
