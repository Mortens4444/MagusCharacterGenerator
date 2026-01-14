namespace M.A.G.U.S.Assistant.ViewModels;

internal class PaintCanvasDrawable : IDrawable
{
    public PaintWizardViewModel? ViewModel { get; set; }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        if (ViewModel == null)
        {
            return;
        }

        foreach (var element in ViewModel.Elements)
        {
            element.Draw(canvas);
        }

        ViewModel.CurrentElement?.Draw(canvas);
    }
}
