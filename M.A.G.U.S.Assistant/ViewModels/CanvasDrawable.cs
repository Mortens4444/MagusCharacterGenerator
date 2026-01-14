//using M.A.G.U.S.Assistant.Models;

//namespace M.A.G.U.S.Assistant.ViewModels;

//internal class CanvasDrawable(PaintWizardViewModel vm) : IDrawable
//{
//    private readonly PaintWizardViewModel viewModel = vm;

//    public void Draw(ICanvas canvas, RectF dirtyRect)
//    {
//        canvas.SaveState();

//        // háttér
//        canvas.FillColor = Colors.White;
//        canvas.FillRectangle(dirtyRect);

//        // rács
//        DrawGrid(canvas, dirtyRect);

//        // PlacedItems rajzolása (ikon vagy fallback forma)
//        if (viewModel.PlacedItems != null)
//        {
//            for (var i = 0; i < viewModel.PlacedItems.Count; i++)
//            {
//                var it = viewModel.PlacedItems[i];
//                DrawPlacedItem(canvas, it);
//            }
//        }

//        canvas.RestoreState();
//    }

//    public void Invalidate()
//    {
//        // a GraphicsView-et a Page invalidálja, itt nem kell semmit csinálni
//    }

//    private void DrawGrid(ICanvas canvas, RectF rect)
//    {
//        var step = 50f;
//        canvas.StrokeColor = Colors.LightGray;
//        canvas.StrokeSize = 0.5f;
//        for (var x = 0f; x < rect.Width; x += step) canvas.DrawLine(x, 0, x, rect.Height);
//        for (var y = 0f; y < rect.Height; y += step) canvas.DrawLine(0, y, rect.Width, y);
//    }

//    private void DrawPlacedItem(ICanvas canvas, PlacedItem it)
//    {
//        var rect = new RectF(it.X - it.Width / 2f, it.Y - it.Height / 2f, it.Width, it.Height);

//        // ha van betöltött IImage, rajzoljuk
//        if (it.Image != null)
//        {
//            //canvas.DrawImage(it.Image, rect.X, rect.Y, rect.Width, rect.Height);
//            return;
//        }

//        // különböző típusok top-down megjelenítése (ha Icon típusból tudunk dönteni)
//        var type = "chair";//it.Icon?.ToLowerInvariant() ?? String.Empty;

//        if (type.Contains("chair"))
//        {
//            DrawChair(canvas, rect);
//        }
//        else if (type.Contains("table"))
//        {
//            canvas.FillColor = Colors.SaddleBrown;
//            canvas.FillRoundedRectangle(rect.X, rect.Y + rect.Height * 0.15f, rect.Width, rect.Height * 0.7f, 6);
//        }
//        else if (type.Contains("rug") || type.Contains("carpet"))
//        {
//            canvas.FillColor = Colors.DarkOliveGreen;
//            canvas.FillRoundedRectangle(rect.X, rect.Y, rect.Width, rect.Height, 8);
//        }
//        else
//        {
//            // fallback: egyszerű négyzet
//            canvas.FillColor = Colors.LightGray;
//            canvas.FillRectangle(rect);
//        }

//        // körvonal
//        canvas.StrokeColor = Colors.Black;
//        canvas.StrokeSize = 1;
//        canvas.DrawRectangle(rect);
//    }

//    private void DrawChair(ICanvas canvas, RectF rect)
//    {
//        var cx = rect.X + rect.Width / 2f;
//        var cy = rect.Y + rect.Height / 2f;
//        var size = Math.Min(rect.Width, rect.Height);
//        var half = size / 2f;

//        canvas.FillColor = Colors.SaddleBrown;
//        // ülőke
//        canvas.FillRoundedRectangle(cx - half * 0.6f, cy - half * 0.1f, size * 0.6f, size * 0.4f, 4);
//        // háttámla
//        canvas.FillRoundedRectangle(cx - half * 0.6f, cy - half * 0.55f, size * 0.6f, size * 0.25f, 3);
//        // lábak
//        var legW = size * 0.08f;
//        var legH = size * 0.12f;
//        canvas.FillRectangle(cx - half * 0.55f, cy + half * 0.25f, legW, legH);
//        canvas.FillRectangle(cx + half * 0.55f - legW, cy + half * 0.25f, legW, legH);
//    }
//}
