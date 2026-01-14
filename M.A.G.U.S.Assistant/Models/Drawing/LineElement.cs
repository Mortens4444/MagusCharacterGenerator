using M.A.G.U.S.Assistant.Interfaces;

namespace M.A.G.U.S.Assistant.Models.Drawing;

internal class LineElement : IDrawableElement
{
    public required Color Color { get; set; }

    public List<PointF> Points { get; set; } = [];

    public float Thickness { get; set; } = 2f;

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
}
