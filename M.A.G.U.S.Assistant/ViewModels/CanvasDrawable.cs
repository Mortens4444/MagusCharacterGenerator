using M.A.G.U.S.Assistant.Models;

namespace M.A.G.U.S.Assistant.ViewModels;

public class CanvasDrawable : IDrawable
{
    private readonly PaintViewModel viewModel;

    public CanvasDrawable(PaintViewModel vm)
    {
        viewModel = vm;
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.SaveState();
        canvas.FillColor = Colors.White;
        canvas.FillRectangle(dirtyRect);

        // draw grid for orientation (optional)
        DrawGrid(canvas, dirtyRect);

        foreach (var s in viewModel.Shapes)
        {
            DrawShape(canvas, s);
        }

        canvas.RestoreState();
    }

    public void Invalidate()
    {
        // Nothing here — GraphicsView will call invalidate via binding to this instance.
    }

    private void DrawGrid(ICanvas canvas, RectF rect)
    {
        var step = 50;
        canvas.StrokeColor = Colors.LightGray;
        canvas.StrokeSize = 0.5f;
        for (var x = 0; x < rect.Width; x += step) canvas.DrawLine(x, 0, x, rect.Height);
        for (var y = 0; y < rect.Height; y += step) canvas.DrawLine(0, y, rect.Width, y);
    }

    private void DrawShape(ICanvas canvas, DrawableShape s)
    {
        canvas.SaveState();
        canvas.FillColor = s.Color;
        canvas.StrokeColor = Colors.Black;
        canvas.StrokeSize = 2;

        var half = s.Size / 2f;
        var cx = s.X;
        var cy = s.Y;

        switch (s.Type)
        {
            case "Chair":
                DrawChair(canvas, cx, cy, s.Size);
                break;
            case "Table":
                // top-down table = rectangle with legs
                canvas.FillRoundedRectangle(cx - half, cy - half, s.Size, s.Size * 0.6f, 6);
                break;
            case "Wall":
                // wall as long rectangle
                canvas.FillRectangle(cx - half * 2, cy - half / 2, s.Size * 2, s.Size / 3);
                break;
            case "GlassSphere":
                // circle with glare (glass look)
                canvas.FillColor = s.Color.WithAlpha(0.5f);
                canvas.FillCircle(cx, cy, half);
                canvas.StrokeColor = Colors.LightGray;
                canvas.DrawCircle(cx, cy, half);
                canvas.FillColor = Colors.White.WithAlpha(0.25f);
                canvas.FillEllipse(cx - half / 2, cy - half / 2, half * 0.6f, half * 0.4f);
                break;
            case "Human":
                // simplified top-down human: circle (head) + body ellipse
                canvas.FillCircle(cx, cy - half * 0.25f, half * 0.45f);
                canvas.FillEllipse(cx - half * 0.6f, cy + half * 0.05f, s.Size * 0.9f, half);
                break;
            default:
                // fallback: simple square
                canvas.FillRectangle(cx - half, cy - half, s.Size, s.Size);
                break;
        }

        canvas.RestoreState();
    }

    private void DrawChair(ICanvas canvas, float cx, float cy, float size)
    {
        var half = size / 2f;
        // seat
        canvas.FillRoundedRectangle(cx - half * 0.6f, cy - half * 0.1f, size * 0.6f, size * 0.4f, 4);
        // backrest (top of chair)
        canvas.FillRoundedRectangle(cx - half * 0.6f, cy - half * 0.55f, size * 0.6f, size * 0.25f, 3);
        // legs (small rectangles)
        var legW = size * 0.08f;
        var legH = size * 0.12f;
        canvas.FillRectangle(cx - half * 0.55f, cy + half * 0.25f, legW, legH);
        canvas.FillRectangle(cx + half * 0.55f - legW, cy + half * 0.25f, legW, legH);
    }
}
