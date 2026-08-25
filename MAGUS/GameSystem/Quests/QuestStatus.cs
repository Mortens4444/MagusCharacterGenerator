namespace MAGUS.GameSystem.Quests;

public enum QuestStatus
{
    NotStarted,
    Accepted,

    /// <summary>
    /// The delivery item (see Quest.DeliveryDestination) has been found via Search at Quest.SearchLocation
    /// but not yet carried to its destination - a delivery quest passes through this status between
    /// Accepted and Completed, instead of completing the moment Search succeeds.
    /// </summary>
    ItemObtained,

    Completed,

    /// <summary>
    /// A timed quest (see Quest.TimeLimitHours) whose deadline passed before it was completed - set
    /// lazily by Character.GetQuestStatus once QuestProgress.AcceptedAtUtc plus the time limit is in
    /// the past. Terminal, like Completed: the quest stays out of AvailableQuestsHere (it's no longer
    /// NotStarted) but grants no reward and can't be reattempted.
    /// </summary>
    Failed
}
