using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.Services;
using Mtf.LanguageService.MAUI;
using Mtf.LanguageService.MAUI.Views;

namespace M.A.G.U.S.Assistant.Views;

internal partial class ImagePreviewPage : NotifierPage
{
    private readonly ImageItem item;

    public ImagePreviewPage(ImageItem image)
    {
        InitializeComponent();
        Translator.Translate(this);
        item = image;
        LoadImage();
    }

    private void LoadImage()
    {
        try
        {
            PreviewImage.Source = ImageSource.FromFile(item.ResourceId);
        }
        catch
        {
            // fallback empty
        }
    }

    private async void CloseClicked(object sender, EventArgs e)
    {
        await ShellNavigationService.ClosePage().ConfigureAwait(true);
    }
}
