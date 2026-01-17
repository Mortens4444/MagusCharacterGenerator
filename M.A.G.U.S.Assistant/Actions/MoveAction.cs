using M.A.G.U.S.Assistant.Interfaces;

namespace M.A.G.U.S.Assistant.Actions;

internal class MoveAction(IDrawableElement element, float dx, float dy) : IPaintAction
{
    private readonly IDrawableElement element = element;
    private readonly float dx = dx;
    private readonly float dy = dy;

    public void Undo(IList<IDrawableElement> elements)
    {
        element.Move(-dx, -dy);
    }

    public void Redo(IList<IDrawableElement> elements)
    {
        element.Move(dx, dy);
    }
}
