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
    private double totalX, totalY;

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

    private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
    {
        if (sender is not Image image || currentScale <= 1) return;

        if (e.StatusType == GestureStatus.Started)
        {
            totalX = image.TranslationX;
            totalY = image.TranslationY;
        }
        else if (e.StatusType == GestureStatus.Running)
        {
            image.TranslationX = totalX + e.TotalX;
            image.TranslationY = totalY + e.TotalY;
        }
    }

    private void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
    {
        if (sender is not Image image) return;

        if (e.Status == GestureStatus.Started)
        {
            startScale = image.Scale;

            // Kiszámoljuk az érintési pontot a kép aktuális koordináta-rendszerében
            // Fontos: Csak egyszer, a mûvelet elején fixáljuk az horgonyt!
            double originX = e.ScaleOrigin.X;
            double originY = e.ScaleOrigin.Y;

            double oldAnchorX = image.AnchorX;
            double oldAnchorY = image.AnchorY;

            // Az új horgonypont beállítása
            image.AnchorX = originX;
            image.AnchorY = originY;

            // Korrekció, hogy az Anchor váltás miatt ne ugorjon el a kép
            // (Az aktuális méretarány és az eltolás különbségét kompenzáljuk)
            double width = image.Width;
            double height = image.Height;

            image.TranslationX += (originX - oldAnchorX) * width * (image.Scale - 1);
            image.TranslationY += (originY - oldAnchorY) * height * (image.Scale - 1);
        }
        else if (e.Status == GestureStatus.Running)
        {
            // Csak a Scale-t módosítjuk. 
            // Ha itt módosítanánk az Anchor-t, az okozná a vibrálást.
            double newScale = startScale * e.Scale;
            currentScale = Math.Clamp(newScale, MinScale, MaxScale);

            image.Scale = currentScale;
        }
        else if (e.Status == GestureStatus.Completed || e.Status == GestureStatus.Canceled)
        {
            // Opcionálisan itt elmenthetjük a végsõ állapotot
            startScale = currentScale;
        }
    }

    private async void OnDoubleTapped(object sender, EventArgs e)
    {
        if (sender is not Image image) return;

        currentScale = 1;
        startScale = 1;

        await Task.WhenAll(
            image.ScaleToAsync(1, 150, Easing.CubicOut),
            image.TranslateToAsync(0, 0, 150, Easing.CubicOut)
        ).ConfigureAwait(true);

        image.AnchorX = 0.5;
        image.AnchorY = 0.5;
    }
}
