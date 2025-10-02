using M.A.G.U.S.Assistant.ViewModels;

namespace M.A.G.U.S.Assistant.Views;

public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        InitializeComponent();
        CreditsLbl.Text = EmbeddedResourceReader.Get("M.A.G.U.S.Assistant.Resources.Raw.Credits.txt", GetType().Assembly).Replace("\r\n", "\r\n\r\n");
    }

    private async void OnEmailLabelTappedAsync(object sender, TappedEventArgs e) => await AboutPageViewModel.SendEmailAsync().ConfigureAwait(false);
}