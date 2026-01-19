using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Models.Drawing;

namespace M.A.G.U.S.Assistant.ViewModels;

internal class PaintCanvasDrawable : IDrawable
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

    private void DrawSelectionHighlight(ICanvas canvas, IDrawableElement element)
    {
        var center = element.GetCenter();

        // Elforgatjuk a kijelölő keretet is, ha az elem el van forgatva
        canvas.SaveState();
        canvas.Rotate(element.Rotation, center.X, center.Y);

        canvas.StrokeColor = Colors.DeepSkyBlue;
        canvas.StrokeSize = 1;
        canvas.StrokeDashPattern = new float[] { 4, 4 }; // Szaggatott vonal

        // Itt egy becsült téglalapot rajzolunk az elem köré
        // A pontos mérethez az element-nek kellene visszaadnia egy Rect-et
        if (element is RectangleElement re)
        {
            canvas.DrawRectangle(((RectangleElement)element).Rect.Inflate(5, 5));

            canvas.FillColor = Colors.White;
            canvas.FillEllipse(re.Rect.X - 8, re.Rect.Y - 8, 16, 16);
            canvas.DrawEllipse(re.Rect.X - 8, re.Rect.Y - 8, 16, 16);
        }

        canvas.RestoreState();
    }
}
