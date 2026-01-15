using M.A.G.U.S.Assistant.Interfaces;

namespace M.A.G.U.S.Assistant.Models.Drawing;

public class CircleElement : IDrawableElement
{
    public required Color Color { get; set; }

    public required PointF Center { get; set; }

    public required float Radius { get; set; }

    public Color FillColor { get; set; } = Colors.Transparent;

    public float Thickness { get; set; } = 2f;

    public void Draw(ICanvas canvas)
    {
        if (FillColor != Colors.Transparent)
        {
            canvas.FillColor = FillColor;
            canvas.FillEllipse(Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
        }

        canvas.StrokeColor = Color;
        canvas.StrokeSize = Thickness;
        canvas.DrawEllipse(Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
    }

    public bool Contains(PointF point)
    {
        // (x - center_x)^2 + (y - center_y)^2 <= r^2
        var dx = point.X - Center.X;
        var dy = point.Y - Center.Y;

        const int tolerance = 5;
        var distanceSquared = (dx * dx) + (dy * dy);
        var radiusSquared = (Radius + tolerance) * (Radius + tolerance);

        return distanceSquared <= radiusSquared;
    }

    public void SetFromPoints(PointF p1, PointF p2)
    {
        var dx = Math.Abs(p1.X - p2.X) / 2;
        var dy = Math.Abs(p1.Y - p2.Y) / 2;

        Radius = (float)Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
        Center = new PointF(Math.Min(p1.X, p2.X) + dx, Math.Min(p1.Y, p2.Y) + dy);
    }
}
