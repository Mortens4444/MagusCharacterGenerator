using M.A.G.U.S.Assistant.Interfaces;

namespace M.A.G.U.S.Assistant.Models.Drawing;

public class CircleElement : IDrawableElement
{
    public required Color Color { get; set; }

    public PointF Center { get; set; }

    public float Radius { get; set; }

    public bool IsFilled { get; set; }

    public Color FillColor { get; set; }

    public void Draw(ICanvas canvas)
    {
        canvas.StrokeColor = Color;
        canvas.StrokeSize = 2;
        if (IsFilled)
        {
            canvas.FillColor = FillColor;
            canvas.FillEllipse(Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
        }
        canvas.DrawEllipse(Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
    }
}
