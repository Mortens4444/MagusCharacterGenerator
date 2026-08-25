using MAGUS.Assistant.Interfaces;

namespace MAGUS.Assistant.Actions;

/// <summary>Groups several actions (e.g. every element added by a merged JSON load) into a single undo/redo step.</summary>
internal sealed class BatchAction(IReadOnlyList<IPaintAction> actions) : IPaintAction
{
    private readonly IReadOnlyList<IPaintAction> actions = actions;

    public void Undo(IList<IDrawableElement> elements)
    {
        for (var i = actions.Count - 1; i >= 0; i--)
        {
            actions[i].Undo(elements);
        }
    }

    public void Redo(IList<IDrawableElement> elements)
    {
        foreach (var action in actions)
        {
            action.Redo(elements);
        }
    }
}
