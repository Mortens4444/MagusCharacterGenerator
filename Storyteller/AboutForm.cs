using FontAwesome.Sharp;
using Mtf.LanguageService.Windows.Forms;

namespace Storyteller;

public partial class AboutForm : Form
{
	public AboutForm()
	{
		InitializeComponent();

		Icon = IconCreator.Get(IconChar.Info, Color.Gray);
		Translator.Translate(this);
	}

	private void LlLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		ProcessUtils.Start(llLink.Text);
	}

	private void LlDonate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		ProcessUtils.Start("https://www.paypal.me/Mortens4444");
	}
}
