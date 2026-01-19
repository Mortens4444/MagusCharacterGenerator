using M.A.G.U.S.Assistant.Interfaces;

namespace M.A.G.U.S.Assistant.Models.Drawing;

public class RectangleElement : IDrawableElement
{
    public required Color Color { get; set; }

    public RectF Rect { get; set; }

    public Color FillColor { get; set; } = Colors.Transparent;

    public float Rotation { get; set; }

    public void Draw(ICanvas canvas)
    {
        canvas.StrokeColor = Color;
        canvas.StrokeSize = 2;
        if (FillColor != Colors.Transparent)
        {
            canvas.FillColor = FillColor;
            canvas.FillRectangle(Rect.X, Rect.Y, Rect.Width, Rect.Height);
        }
        canvas.DrawRectangle(Rect.X, Rect.Y, Rect.Width, Rect.Height);
    }

    public void Move(float dx, float dy)
    {
        Rect = new RectF(Rect.X + dx, Rect.Y + dy, Rect.Width, Rect.Height);
    }

    public PointF GetCenter()
    {
        return new PointF(Rect.X + Rect.Width / 2f, Rect.Y + Rect.Height / 2f);
    }

    public bool Contains(PointF p) => Rect.Contains(p);

    public void Rotate(float angleDegrees)
    {
        Rotation += angleDegrees;
    }

    public void Resize(float scale)
    {
        if (scale <= 0) return; // Biztonsági ellenőrzés

        // Jelenlegi középpont mentése
        var center = GetCenter();

        // Új méretek
        float newWidth = Rect.Width * scale;
        float newHeight = Rect.Height * scale;

        // Új pozíció (bal felső sarok) kiszámolása a középont alapján
        float newX = center.X - (newWidth / 2f);
        float newY = center.Y - (newHeight / 2f);

        Rect = new RectF(newX, newY, newWidth, newHeight);
    }
}
