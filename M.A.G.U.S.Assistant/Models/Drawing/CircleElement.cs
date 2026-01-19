using M.A.G.U.S.Assistant.Interfaces;

namespace M.A.G.U.S.Assistant.Models.Drawing;

public class CircleElement : IDrawableElement
{
    public required Color Color { get; set; }

    public required PointF Center { get; set; }

    public required float Radius { get; set; }

    public Color FillColor { get; set; } = Colors.Transparent;

    public float Thickness { get; set; } = 2f;

    public bool IsBoundedByRect { get; set; }

    public RectF BoundingRect { get; set; }

    public float Rotation { get; set; }

    public void Draw(ICanvas canvas)
    {
        if (IsBoundedByRect)
        {
            if (FillColor != Colors.Transparent)
            {
                canvas.FillColor = FillColor;
                canvas.FillEllipse(BoundingRect);
            }
            canvas.StrokeColor = Color;
            canvas.StrokeSize = Thickness;
            canvas.DrawEllipse(BoundingRect);
        }
        else
        {
            float x = Center.X - Radius;
            float y = Center.Y - Radius;
            float size = Radius * 2;
            if (FillColor != Colors.Transparent)
            {
                canvas.FillColor = FillColor;
                canvas.FillEllipse(x, y, size, size);
            }

            canvas.StrokeColor = Color;
            canvas.StrokeSize = Thickness;
            canvas.DrawEllipse(x, y, size, size);
        }
    }

    public bool Contains(PointF point)
    {
        if (IsBoundedByRect)
        {
            return BoundingRect.Contains(point);
        }

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

    public void Move(float dx, float dy)
    {
        if (IsBoundedByRect)
        {
            BoundingRect = new RectF(BoundingRect.X + dx, BoundingRect.Y + dy, BoundingRect.Width, BoundingRect.Height);
        }
        else
        {
            Center = new PointF(Center.X + dx, Center.Y + dy);
        }
    }

    public PointF GetCenter()
    {
        if (IsBoundedByRect)
        {
            return new PointF(BoundingRect.X + BoundingRect.Width / 2f, BoundingRect.Y + BoundingRect.Height / 2f);
        }
        return Center;
    }

    public void Rotate(float angleDegrees)
    {
        Rotation += angleDegrees;
    }

    public void Resize(float scale)
    {
        if (scale <= 0) return;

        if (IsBoundedByRect)
        {
            // Ugyanaz a logika, mint a téglalapnál
            var center = GetCenter();
            float newWidth = BoundingRect.Width * scale;
            float newHeight = BoundingRect.Height * scale;
            float newX = center.X - (newWidth / 2f);
            float newY = center.Y - (newHeight / 2f);
            BoundingRect = new RectF(newX, newY, newWidth, newHeight);
        }
        else
        {
            // Egyszerű kör esetén csak a sugarat növeljük
            Radius *= scale;
        }
    }
}
