namespace MAGUS.GameSystem.Quests;

/// <summary>Per-character record of how far a given Quest (identified by Quest.Key) has progressed - see Character.QuestProgress.</summary>
public class QuestProgress
{
    public string QuestKey { get; set; } = String.Empty;

    public QuestStatus Status { get; set; }

    /// <summary>When this quest was accepted, in UTC - only meaningful for a timed quest (see Quest.TimeLimitHours), checked lazily in Character.GetQuestStatus to expire it once the deadline passes.</summary>
    public DateTime AcceptedAtUtc { get; set; }
}
