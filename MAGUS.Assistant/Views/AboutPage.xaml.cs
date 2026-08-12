using MAGUS.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace MAGUS.Assistant.Views;

internal sealed partial class AboutPage : NotifierPage
{
    public AboutPage(AboutPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        CreditsLbl.Text = EmbeddedResourceReader.Get("MAGUS.Assistant.Resources.Raw.Credits.txt", GetType().Assembly).Replace("\r\n", "\r\n\r\n", StringComparison.Ordinal);
    }

    private async void OnEmailLabelTappedAsync(object sender, TappedEventArgs e) => await AboutPageViewModel.SendEmailAsync().ConfigureAwait(true);
}