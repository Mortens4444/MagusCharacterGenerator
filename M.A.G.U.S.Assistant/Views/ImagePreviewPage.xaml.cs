using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.Services;
using Mtf.LanguageService.MAUI;
using Mtf.LanguageService.MAUI.Views;

namespace M.A.G.U.S.Assistant.Views;

internal partial class ImagePreviewPage : NotifierPage
{
    private readonly ImageItem item;

    private double scale = 1;
    private double lastScale = 1;

    private double xOffset;
    private double yOffset;

    private const double MinScale = 1;
    private const double MaxScale = 4;

    private bool isGestureRunning;

    public ImagePreviewPage(ImageItem image)
    {
        InitializeComponent();
        Translator.Translate(this);

        item = image;
        LoadImage();

        PreviewImage.AnchorX = 0.5;
        PreviewImage.AnchorY = 0.5;
    }

    private async void CloseClicked(object sender, EventArgs e)
    {
        await ShellNavigationService.ClosePage().ConfigureAwait(true);
    }

    private void LoadImage()
    {
        try
        {
            PreviewImage.Source = ImageSource.FromFile(item.ResourceId);
        }
        catch
        {
        }
    }

    private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
    {
        if (isGestureRunning || scale <= 1 || sender is not Image image)
        {
            return;
        }

        if (e.StatusType == GestureStatus.Running)
        {
            image.TranslationX = xOffset + e.TotalX;
            image.TranslationY = yOffset + e.TotalY;
        }
        else if (e.StatusType == GestureStatus.Completed)
        {
            xOffset = image.TranslationX;
            yOffset = image.TranslationY;
        }
    }

    private void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
    {
        if (sender is not Image image)
        {
            return;
        }

        if (e.Status == GestureStatus.Started)
        {
            isGestureRunning = true;
            lastScale = scale;
        }
        else if (e.Status == GestureStatus.Running)
        {
            var newScale = Math.Clamp(lastScale * e.Scale, MinScale, MaxScale);

            // 🔒 Android fix: csak akkor frissítünk, ha tényleg változott
            if (Math.Abs(newScale - scale) < 0.001)
            {
                return;
            }

            scale = newScale;
            image.Scale = scale;
        }
        else if (e.Status is GestureStatus.Completed or GestureStatus.Canceled)
        {
            lastScale = scale;
            xOffset = image.TranslationX;
            yOffset = image.TranslationY;
            isGestureRunning = false;
        }
    }

    private async void OnDoubleTapped(object sender, EventArgs e)
    {
        if (sender is not Image image)
        {
            return;
        }

        scale = 1;
        lastScale = 1;
        xOffset = 0;
        yOffset = 0;

        await Task.WhenAll(
            image.ScaleToAsync(1, 160, Easing.CubicOut),
            image.TranslateToAsync(0, 0, 160, Easing.CubicOut)
        ).ConfigureAwait(true);
    }
}
