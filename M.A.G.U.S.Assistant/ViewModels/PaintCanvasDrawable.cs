using M.A.G.U.S.Assistant.Interfaces;

namespace M.A.G.U.S.Assistant.ViewModels;

internal sealed class PaintCanvasDrawable : IDrawable
{
    public PaintWizardViewModel? ViewModel { get; set; }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        if (ViewModel == null) return;

        // Készített elemek kirajzolása
        foreach (var element in ViewModel.Elements)
        {
            DrawElement(canvas, element);
        }

        // Az éppen rajzolt (még nem kész) elem kirajzolása
        if (ViewModel.CurrentElement != null)
        {
            DrawElement(canvas, ViewModel.CurrentElement);
        }
    }

    private void DrawElement(ICanvas canvas, IDrawableElement element)
    {
        canvas.SaveState();

        if (element.Rotation != 0)
        {
            PointF center = element.GetCenter();
            canvas.Rotate(element.Rotation, center.X, center.Y);
        }

        element.Draw(canvas);
        canvas.RestoreState();
    }
}
