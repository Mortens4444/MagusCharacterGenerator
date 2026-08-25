namespace MAGUS.GameSystem.Quests;

/// <summary>One thing the player can say in response to a DialogueNode - see DialogueNode.Options.</summary>
public sealed class DialogueOption
{
    public required string Text { get; init; }

    public DialogueOutcome Outcome { get; init; } = DialogueOutcome.Continue;

    /// <summary>Where the conversation goes next - only used when Outcome is Continue.</summary>
    public DialogueNode? NextNode { get; init; }
}
