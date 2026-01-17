using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.Services;
using Mtf.LanguageService.MAUI;
using Mtf.LanguageService.MAUI.Views;

namespace M.A.G.U.S.Assistant.Views;

internal partial class ImagePreviewPage : NotifierPage
{
    private readonly ImageItem item;
    private double currentScale = 1;
    private double startScale = 1;
    private const double MinScale = 1;
    private const double MaxScale = 4;

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

    private void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
    {
        if (sender is not Image image)
        {
            return;
        }

        if (e.Status == GestureStatus.Started)
        {
            startScale = currentScale;
            return;
        }

        if (e.Status == GestureStatus.Running)
        {
            var newScale = startScale * e.Scale;
            currentScale = Math.Clamp(newScale, MinScale, MaxScale);
            image.Scale = currentScale;
            return;
        }

        if (e.Status == GestureStatus.Completed)
        {
            startScale = currentScale;
        }
    }

    private async void OnDoubleTapped(object sender, EventArgs e)
    {
        if (sender is not Image image)
        {
            return;
        }

        currentScale = 1;
        startScale = 1;

        await image.ScaleToAsync(1, 120, Easing.CubicOut).ConfigureAwait(true);
    }
}
