using System.Collections.ObjectModel;
using Microsoft.Maui;
using Microsoft.Maui.Graphics;

namespace M.A.G.U.S.Assistant.ViewModels
{
    public class GraphicsCanvasDrawable : IDrawable
    {
        private readonly PaintWizardViewModel vm;
        private readonly ObservableCollection<ObservableCollection<PointF>> strokes = new ObservableCollection<ObservableCollection<PointF>>();

        public GraphicsCanvasDrawable(PaintWizardViewModel viewModel)
        {
            vm = viewModel;
        }

        // UI thread invalidate-ot beállíthat a Page (CanvasView.Invalidate)
        public System.Action InvalidateAction { get; set; }

        public void Invalidate()
        {
            InvalidateAction?.Invoke();
        }

        public void ClearStrokes()
        {
            strokes.Clear();
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.SaveState();

            // background grid
            canvas.StrokeColor = Colors.Gray;
            canvas.Alpha = 0.08f;
            for (var x = 0f; x < dirtyRect.Width; x += 40f)
                canvas.DrawLine(x, 0, x, dirtyRect.Height);
            for (var y = 0f; y < dirtyRect.Height; y += 40f)
                canvas.DrawLine(0, y, dirtyRect.Width, y);

            canvas.Alpha = 1f;

            // draw placed items (top-down icons) — itt már IImage-t használunk
            foreach (var it in vm.PlacedItems)
            {
                var rect = new RectF(it.X - it.Width / 2f, it.Y - it.Height / 2f, it.Width, it.Height);

                if (it.Image != null)
                {
                    // IImage, helyes overload: (IImage, x, y, width, height)
                    //canvas.DrawImage(it.Image, rect.X, rect.Y, rect.Width, rect.Height);
                }
                else
                {
                    // fallback: placeholder rectangle
                    canvas.FillColor = Colors.DarkGray;
                    canvas.FillRectangle(rect);
                }
            }

            // draw active stroke
            //if (vm.CurrentStroke.Count > 1)
            //{
            //    canvas.StrokeSize = 4;
            //    canvas.StrokeColor = vm.SelectedColor;
            //    for (var i = 1; i < vm.CurrentStroke.Count; i++)
            //    {
            //        var a = vm.CurrentStroke[i - 1];
            //        var b = vm.CurrentStroke[i];
            //        canvas.DrawLine(a.X, a.Y, b.X, b.Y);
            //    }
            //}

            canvas.RestoreState();
        }
    }
}
