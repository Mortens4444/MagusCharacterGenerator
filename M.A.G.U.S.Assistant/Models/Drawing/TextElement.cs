using M.A.G.U.S.Assistant.Interfaces;

namespace M.A.G.U.S.Assistant.Models.Drawing;

internal class TextElement : IDrawableElement
{
    public required string Text { get; set; }

    public required Color Color { get; set; }

    public PointF Position { get; set; }

    public float FontSize { get; set; } = 18;

    public void Draw(ICanvas canvas)
    {
        canvas.FontColor = Color;
        canvas.FontSize = FontSize;
        canvas.DrawString(Text, Position.X, Position.Y, HorizontalAlignment.Left);
    }
}
