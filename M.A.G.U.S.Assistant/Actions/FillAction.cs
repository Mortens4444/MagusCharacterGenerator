using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Models.Drawing;

namespace M.A.G.U.S.Assistant.Actions;

internal class FillAction(IDrawableElement element, Color oldColor, Color newColor) : IPaintAction
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
