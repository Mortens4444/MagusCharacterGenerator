using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace M.A.G.U.S.Assistant.Views;

internal partial class AboutPage : NotifierPage
{
    public AboutPage(AboutPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        CreditsLbl.Text = EmbeddedResourceReader.Get("M.A.G.U.S.Assistant.Resources.Raw.Credits.txt", GetType().Assembly).Replace("\r\n", "\r\n\r\n", StringComparison.Ordinal);
    }

    private async void OnEmailLabelTappedAsync(object sender, TappedEventArgs e) => await AboutPageViewModel.SendEmailAsync().ConfigureAwait(false);
}