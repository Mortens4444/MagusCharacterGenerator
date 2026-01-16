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
    private IDrawableElement movingElement;
    private double currentScale = 1;
    private double startScale = 1;
    private const double MinScale = 1;
    private const double MaxScale = 4;

    public PaintWizardPage(PaintWizardViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        this.viewModel = viewModel;

        viewModel.PropertyChanged += (s, e) => {
            if (e.PropertyName == nameof(viewModel.BackgroundColor))
            {
                MainThread.BeginInvokeOnMainThread(() => {
                    CanvasView?.Invalidate();
                });
            }
        };
        
        viewModel.Elements.CollectionChanged += (s, e) => {
            MainThread.BeginInvokeOnMainThread(() => {
                CanvasView?.Invalidate();
            });
        };
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
        await viewModel.RefreshSavedDrawingsCommand.ExecuteAsync(null);
    }

    private void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
    {
        if (sender is not Image image)
        {
            return;
        }

        if (e.Status == GestureStatus.Started)
        {
            startScale = currentScale;
            return;
        }

        if (e.Status == GestureStatus.Running)
        {
            var newScale = startScale * e.Scale;
            currentScale = Math.Clamp(newScale, MinScale, MaxScale);
            image.Scale = currentScale;
            return;
        }

        if (e.Status == GestureStatus.Completed)
        {
            startScale = currentScale;
        }
    }

    private async void OnDoubleTapped(object sender, EventArgs e)
    {
        if (sender is not Image image)
        {
            return;
        }

        currentScale = 1;
        startScale = 1;

        await image.ScaleToAsync(1, 120, Easing.CubicOut).ConfigureAwait(true);
    }

    private void OnTouchStart(object sender, TouchEventArgs e)
    {
        startPoint = e.Touches[0];
        lastPoint = startPoint;

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
            // Kiszámoljuk a különbséget az elõzõ pont óta
            float dx = currentPoint.X - lastPoint.X;
            float dy = currentPoint.Y - lastPoint.Y;

            // Elmozgatjuk az elemet
            movingElement.Move(dx, dy);

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
            // Megkeressük az elsõ olyan elemet, ami közel van az ujjunkhoz és töröljük
            var hit = viewModel.Elements.FirstOrDefault(el => el.Contains(currentPoint));
            if (hit != null)
            {
                viewModel.Elements.Remove(hit);
                CanvasView.Invalidate();
                return true;
            }
        }

        return false;
    }

    private void OnTouchEnd(object sender, TouchEventArgs e)
    {
        movingElement = null;

        if (viewModel.CurrentElement != null)
        {
            viewModel.Elements.Add(viewModel.CurrentElement);
            viewModel.CurrentElement = null;
            CanvasView.Invalidate();
        }
    }

    private async void OnNewPageClicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlertAsync(Lng.Elem("Clear all"), Lng.Elem("Are you sure you want to clear the board?"), Lng.Elem("Yes"), Lng.Elem("No")).ConfigureAwait(true);
        if (answer)
        {
            viewModel.Elements.Clear();
            CanvasView.Invalidate();
        }
    }
}