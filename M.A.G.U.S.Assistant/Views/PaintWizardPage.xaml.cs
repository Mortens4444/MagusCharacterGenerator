using M.A.G.U.S.Assistant.Actions;
using M.A.G.U.S.Assistant.Enums;
using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Models.Drawing;
using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI;
using Mtf.LanguageService.MAUI.Views;

namespace M.A.G.U.S.Assistant.Views;

internal partial class PaintWizardPage : NotifierPage
{
    private readonly PaintWizardViewModel viewModel;
    private PointF startPoint;
    private PointF lastPoint;
    private IDrawableElement? movingElement;
    private float totalDeltaX;
    private float totalDeltaY;

    public PaintWizardPage(PaintWizardViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        this.viewModel = viewModel;
        
        viewModel.Elements.CollectionChanged += (s, e) =>
        {
            Invalidate();
        };

        viewModel.RequestInvalidate += (s, e) =>
        {
            Invalidate();
        };
    }

    private void Invalidate()
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            CanvasView?.Invalidate();
        });
    }

    public override bool Equals(object? obj)
    {
        return obj is PaintWizardPage page && EqualityComparer<PointF>.Default.Equals(startPoint, page.startPoint);
    }

    public override int GetHashCode()
    {
        return startPoint.GetHashCode();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.RefreshSavedDrawingsCommand.ExecuteAsync(null).ConfigureAwait(true);
    }

    private void OnTouchStart(object sender, TouchEventArgs e)
    {
        startPoint = e.Touches[0];
        lastPoint = startPoint;
        totalDeltaX = 0;
        totalDeltaY = 0;

        if (viewModel.ActiveTool == PaintTool.Move)
        {
            movingElement = viewModel.Elements.LastOrDefault(el => el.Contains(startPoint));
            return;
        }

        if (PerformEraser(startPoint))
        {
            return;
        }

        var currentFillColor = viewModel.AutoFill ? viewModel.SelectedColor : Colors.Transparent;
        switch (viewModel.ActiveTool)
        {
            case PaintTool.Text:
                var textElement = new TextElement
                {
                    Color = viewModel.SelectedColor,
                    Position = startPoint,
                    Text = viewModel.DefaultText
                };
                viewModel.Elements.Add(textElement);
                viewModel.RegisterAction(new AddAction(textElement));
                CanvasView.Invalidate();
                break;
            case PaintTool.Pencil:
                var line = new LineElement { Color = viewModel.SelectedColor, Thickness = 2f };
                line.Points.Add(startPoint);
                viewModel.CurrentElement = line;
                break;
            case PaintTool.Rect:
                viewModel.CurrentElement = new RectangleElement { Color = viewModel.SelectedColor, Rect = new RectF(startPoint, SizeF.Zero), FillColor = currentFillColor };
                break;
            case PaintTool.Circle:
                viewModel.CurrentElement = new CircleElement { Color = viewModel.SelectedColor, Center = startPoint, Radius = 0, FillColor = currentFillColor };
                break;
            case PaintTool.Line:
                viewModel.CurrentElement = new LineElement { Color = viewModel.SelectedColor, Points = { startPoint, startPoint } };
                break;

            case PaintTool.Fill:
                var hit = viewModel.Elements.LastOrDefault(el => el.Contains(startPoint));
                if (hit != null)
                {
                    Color oldColor = Colors.Transparent;

                    if (hit is RectangleElement r)
                    {
                        oldColor = r.FillColor;
                    }
                    else if (hit is CircleElement c)
                    {
                        oldColor = c.FillColor;
                    }

                    viewModel.RegisterAction(new FillAction(hit, oldColor, viewModel.SelectedColor));

                    switch (hit)
                    {
                        case RectangleElement rect:
                            rect.FillColor = viewModel.SelectedColor;
                            break;
                        case CircleElement circle:
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

        if (viewModel.ActiveTool == PaintTool.Move && movingElement != null)
        {
            float dx = currentPoint.X - lastPoint.X;
            float dy = currentPoint.Y - lastPoint.Y;

            movingElement.Move(dx, dy);

            totalDeltaX += dx;
            totalDeltaY += dy;

            lastPoint = currentPoint;
            CanvasView.Invalidate();
            return;
        }

        if (PerformEraser(currentPoint))
        {
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
                if (viewModel.IsCircleRectMode) // Ez a checkboxod értéke
                {
                    circle.IsBoundedByRect = true;
                    float x1 = Math.Min(startPoint.X, currentPoint.X);
                    float y1 = Math.Min(startPoint.Y, currentPoint.Y);
                    float w1 = Math.Abs(startPoint.X - currentPoint.X);
                    float h1 = Math.Abs(startPoint.Y - currentPoint.Y);
                    circle.BoundingRect = new RectF(x1, y1, w1, h1);
                }
                else
                {
                    circle.IsBoundedByRect = false;
                    circle.Center = startPoint;
                    circle.Radius = startPoint.Distance(currentPoint);
                }
                //circle.Radius = (float)Math.Sqrt(Math.Pow(currentPoint.X - this.startPoint.X, 2) + Math.Pow(currentPoint.Y - this.startPoint.Y, 2));
                break;
        }
        CanvasView.Invalidate();

        lastPoint = currentPoint;
    }

    private bool PerformEraser(PointF currentPoint)
    {
        if (viewModel.ActiveTool == PaintTool.Eraser)
        {
            var hit = viewModel.Elements.FirstOrDefault(el => el.Contains(currentPoint));
            if (hit != null)
            {
                viewModel.Elements.Remove(hit);
                viewModel.RegisterAction(new RemoveAction(hit));
                CanvasView.Invalidate();
                return true;
            }
        }

        return false;
    }

    private void OnTouchEnd(object sender, TouchEventArgs e)
    {
        switch (viewModel.ActiveTool)
        {
            case PaintTool.Pencil:
            case PaintTool.Line:
            case PaintTool.Rect:
            case PaintTool.Circle:
                if (viewModel.CurrentElement != null)
                {
                    viewModel.Elements.Add(viewModel.CurrentElement);
                    viewModel.RegisterAction(new AddAction(viewModel.CurrentElement));
                    viewModel.CurrentElement = null;
                }
                break;

            case PaintTool.Move:
                if (movingElement != null && (totalDeltaX != 0 || totalDeltaY != 0))
                {
                    viewModel.RegisterAction(new MoveAction(movingElement, totalDeltaX, totalDeltaY));
                }
                movingElement = null;
                totalDeltaX = 0;
                totalDeltaY = 0;
                break;

            case PaintTool.Eraser:
            case PaintTool.Fill:
            case PaintTool.Text:
                break;
        }

        CanvasView.Invalidate();
    }

    private async void OnNewPageClicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlertAsync(Lng.Elem("Clear all"), Lng.Elem("Are you sure you want to clear the board?"), Lng.Elem("Yes"), Lng.Elem("No")).ConfigureAwait(true);
        if (answer)
        {
            viewModel.ClearBoardCommand.Execute(null);
            CanvasView.Invalidate();
        }
    }
}