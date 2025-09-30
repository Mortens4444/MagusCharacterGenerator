using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.ViewModels;
using System.Reflection;

namespace M.A.G.U.S.Assistant.Views;

public partial class ImagePreviewPage : ContentPage
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
            var asm = Assembly.GetExecutingAssembly();
            PreviewImage.Source = ImageSource.FromResource(item.ResourceId, asm);
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
