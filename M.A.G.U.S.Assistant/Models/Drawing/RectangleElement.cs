using M.A.G.U.S.Assistant.Interfaces;

namespace M.A.G.U.S.Assistant.Models.Drawing;

public class RectangleElement : IDrawableElement
{
    public required Color Color { get; set; }

    public RectF Rect { get; set; }

    public bool IsFilled { get; set; }

    public Color FillColor { get; set; }

    public void Draw(ICanvas canvas)
    {
        canvas.StrokeColor = Color;
        canvas.StrokeSize = 2;
        if (IsFilled)
        {
            canvas.FillColor = FillColor;
            canvas.FillRectangle(Rect.X, Rect.Y, Rect.Width, Rect.Height);
        }
        canvas.DrawRectangle(Rect.X, Rect.Y, Rect.Width, Rect.Height);
    }
}
