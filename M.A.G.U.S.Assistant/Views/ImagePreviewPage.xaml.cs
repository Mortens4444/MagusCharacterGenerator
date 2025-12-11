using M.A.G.U.S.Assistant.Models;
using Mtf.LanguageService.MAUI.Views;

namespace M.A.G.U.S.Assistant.Views;

internal partial class ImagePreviewPage : NotifierPage
{
    private readonly ImageItem item;

    public ImagePreviewPage(ImageItem image)
    {
        InitializeComponent();
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
        await Navigation.PopModalAsync();
    }
}
