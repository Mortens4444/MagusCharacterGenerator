using M.A.G.U.S.Assistant.Enums;
using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Models.Drawing;
using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace M.A.G.U.S.Assistant.Views;

internal partial class PaintWizardPage : NotifierPage
{
    private readonly PaintWizardViewModel viewModel;
    private PointF startPoint;

    public PaintWizardPage(PaintWizardViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        this.viewModel = viewModel;
    }

    public override bool Equals(object? obj)
    {
        return obj is PaintWizardPage page && EqualityComparer<PointF>.Default.Equals(startPoint, page.startPoint);
    }

    public override int GetHashCode()
    {
        return startPoint.GetHashCode();
    }

    private void OnTouchStart(object sender, TouchEventArgs e)
    {
        startPoint = e.Touches[0];

        switch (viewModel.ActiveTool)
        {
            case PaintTool.Picker:
                viewModel.Elements.Add(new TextElement
                {
                    Text = viewModel.DefaultText,
                    Position = startPoint,
                    Color = viewModel.SelectedColor
                });
                CanvasView.Invalidate();
                break;
            case PaintTool.Pencil:
                var line = new LineElement { Color = viewModel.SelectedColor, Thickness = 2f };
                line.Points.Add(startPoint);
                viewModel.CurrentElement = line;
                break;
            case PaintTool.Rect:
                viewModel.CurrentElement = new RectangleElement { Color = viewModel.SelectedColor, Rect = new RectF(startPoint, SizeF.Zero) };
                break;
            case PaintTool.Circle:
                viewModel.CurrentElement = new CircleElement { Color = viewModel.SelectedColor, Center = startPoint, Radius = 0 };
                break;
            case PaintTool.Line:
                viewModel.CurrentElement = new LineElement { Color = viewModel.SelectedColor, Points = { startPoint, startPoint } };
                break;

            case PaintTool.Fill:
                var hit = viewModel.Elements.LastOrDefault(el => IsHit(el, startPoint));
                if (hit != null)
                {
                    switch (hit)
                    {
                        case RectangleElement rect:
                            rect.IsFilled = true;
                            rect.FillColor = viewModel.SelectedColor;
                            break;
                        case CircleElement circle:
                            circle.IsFilled = true;
                            circle.FillColor = viewModel.SelectedColor;
                            break;
                    }
                    CanvasView.Invalidate();
                }
                break;
        }
    }

    private void OnTouchDrag(object sender, TouchEventArgs e)
    {
        var currentPoint = e.Touches[0];

        if (viewModel.ActiveTool == PaintTool.Eraser)
        {
            // Megkeressük az elsõ olyan elemet, ami közel van az ujjunkhoz és töröljük
            var hit = viewModel.Elements.FirstOrDefault(el => IsHit(el, currentPoint));
            if (hit != null)
            {
                viewModel.Elements.Remove(hit);
                CanvasView.Invalidate();
            }
            return;
        }

        if (viewModel.CurrentElement == null)
        {
            return;
        }

        switch (viewModel.CurrentElement)
        {
            case LineElement line:
                if (viewModel.ActiveTool == PaintTool.Pencil)
                {
                    line.Points.Add(currentPoint);
                }
                else
                {
                    line.Points[1] = currentPoint;
                }

                break;

            case RectangleElement rect:
                float x = Math.Min(this.startPoint.X, currentPoint.X);
                float y = Math.Min(this.startPoint.Y, currentPoint.Y);
                float w = Math.Abs(this.startPoint.X - currentPoint.X);
                float h = Math.Abs(this.startPoint.Y - currentPoint.Y);
                rect.Rect = new RectF(x, y, w, h);
                break;

            case CircleElement circle:
                circle.Radius = (float)Math.Sqrt(Math.Pow(currentPoint.X - this.startPoint.X, 2) + Math.Pow(currentPoint.Y - this.startPoint.Y, 2));
                break;
        }
        CanvasView.Invalidate();
    }

    private void OnTouchEnd(object sender, TouchEventArgs e)
    {
        if (viewModel.CurrentElement != null)
        {
            viewModel.Elements.Add(viewModel.CurrentElement);
            viewModel.CurrentElement = null;
            CanvasView.Invalidate();
        }
    }

    private static bool IsHit(IDrawableElement el, PointF p)
    {
        switch (el)
        {
            case CircleElement c:
                return Math.Sqrt(Math.Pow(p.X - c.Center.X, 2) + Math.Pow(p.Y - c.Center.Y, 2)) <= c.Radius + 5;

            case RectangleElement r:
                return r.Rect.Contains(p);

            case LineElement l:
                return l.Points.Any(pt => Math.Abs(pt.X - p.X) < 10 && Math.Abs(pt.Y - p.Y) < 10);

            case TextElement t:
                var textRect = new RectF(t.Position.X, t.Position.Y - 20, 100, 20);
                return textRect.Contains(p);

            default:
                return false;
        }
    }
}