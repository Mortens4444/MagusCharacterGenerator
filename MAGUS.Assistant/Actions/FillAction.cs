using MAGUS.Assistant.Interfaces;
using MAGUS.Assistant.Models.Drawing;

namespace MAGUS.Assistant.Actions;

internal sealed class FillAction(IDrawableElement element, Color oldColor, Color newColor) : IPaintAction
{
    private readonly IDrawableElement element = element;
    private readonly Color oldColor = oldColor;
    private readonly Color newColor = newColor;

    public void Undo(IList<IDrawableElement> elements)
    {
        SetColor(oldColor);
    }

    public void Redo(IList<IDrawableElement> elements)
    {
        SetColor(newColor);
    }

    private void SetColor(Color c)
    {
        if (element is RectangleElement rect)
        {
            rect.FillColor = c;
        }
        else if (element is CircleElement circle)
        {
            circle.FillColor = c;
        }
    }
}
