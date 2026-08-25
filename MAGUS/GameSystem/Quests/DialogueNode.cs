namespace MAGUS.GameSystem.Quests;

/// <summary>
/// One line of a branching negotiation - what's said, and what the player can answer with. See
/// Quest.DialogueRoot and DialoguePage/DialogueViewModel (MAGUS.Assistant) for how it's played out.
/// </summary>
public sealed class DialogueNode
{
    public required string Text { get; init; }

    public required IReadOnlyList<DialogueOption> Options { get; init; }
}
