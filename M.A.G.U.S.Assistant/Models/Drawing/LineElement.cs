using M.A.G.U.S.Assistant.Interfaces;

namespace M.A.G.U.S.Assistant.Models.Drawing;

internal class LineElement : IDrawableElement
{
    public required Color Color { get; set; }

    public List<PointF> Points { get; set; } = [];

    public float Thickness { get; set; } = 2f;

    public float Rotation { get; set; }

    public void Move(float dx, float dy)
    {
        for (int i = 0; i < Points.Count; i++)
        {
            Points[i] = new PointF(Points[i].X + dx, Points[i].Y + dy);
        }
    }

    public bool Contains(PointF point)
    {
        if (Points == null || Points.Count < 2)
        {
            return false;
        }

        // A tolerancia határozza meg, milyen pontosan kell rákattintani (pixelben)
        // Érdemes legalább a Thickness felét + pár pixelt ráhagyni
        float tolerance = Thickness + 5f;

        for (int i = 0; i < Points.Count - 1; i++)
        {
            PointF p1 = Points[i];
            PointF p2 = Points[i + 1];

            if (IsPointNearLine(point, p1, p2, tolerance))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Megvizsgálja, hogy a 'p' pont egy 'p1-p2' szakasz közelében van-e.
    /// </summary>
    private bool IsPointNearLine(PointF p, PointF p1, PointF p2, float tolerance)
    {
        // Szakasz hossza négyzeten
        float l2 = (float)(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        if (l2 == 0) return (float)Math.Sqrt(Math.Pow(p.X - p1.X, 2) + Math.Pow(p.Y - p1.Y, 2)) <= tolerance;

        // A pont vetülete a szakaszon (0-1 közötti érték)
        float t = ((p.X - p1.X) * (p2.X - p1.X) + (p.Y - p1.Y) * (p2.Y - p1.Y)) / l2;
        t = Math.Max(0, Math.Min(1, t));

        // A legközelebbi pont koordinátái a szakaszon
        PointF projection = new(
            p1.X + t * (p2.X - p1.X),
            p1.Y + t * (p2.Y - p1.Y)
        );

        // Távolság a pont és a vetület között
        float distance = (float)Math.Sqrt(Math.Pow(p.X - projection.X, 2) + Math.Pow(p.Y - projection.Y, 2));

        return distance <= tolerance;
    }

    public void Draw(ICanvas canvas)
    {
        canvas.StrokeColor = Color;
        canvas.StrokeSize = Thickness;
        canvas.StrokeLineCap = LineCap.Round;
        canvas.StrokeLineJoin = LineJoin.Round;

        for (int i = 0; i < Points.Count - 1; i++)
        {
            canvas.DrawLine(Points[i], Points[i + 1]);
        }
    }

    public PointF GetCenter()
    {
        if (Points == null || Points.Count == 0) return PointF.Zero;

        float minX = Points.Min(p => p.X);
        float maxX = Points.Max(p => p.X);
        float minY = Points.Min(p => p.Y);
        float maxY = Points.Max(p => p.Y);

        return new PointF(minX + (maxX - minX) / 2f, minY + (maxY - minY) / 2f);
    }

    public void Rotate(float angleDegrees)
    {
        Rotation += angleDegrees;
    }

    public void Resize(float scale)
    {
        if (scale <= 0 || Points.Count == 0) return;

        var center = GetCenter();
        var newPoints = new List<PointF>();

        foreach (var p in Points)
        {
            // Vektor a középponttól a pontig
            float dx = p.X - center.X;
            float dy = p.Y - center.Y;

            // A vektort megszorozzuk a skálával és hozzáadjuk a középponthoz
            newPoints.Add(new PointF(center.X + dx * scale, center.Y + dy * scale));
        }

        Points = newPoints;

        // Opcionális: A vonal vastagságát is növelheted
        // Thickness *= scale; 
    }
}
