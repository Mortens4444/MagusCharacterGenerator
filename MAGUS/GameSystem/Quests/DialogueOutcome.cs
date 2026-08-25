namespace MAGUS.GameSystem.Quests;

public enum DialogueOutcome
{
    /// <summary>Moves to DialogueOption.NextNode - the conversation keeps going.</summary>
    Continue,

    /// <summary>Ends the conversation and completes the quest for its full reward.</summary>
    Success,

    /// <summary>
    /// Ends the conversation and completes the quest, but only for half its reward (see
    /// Character.CompleteQuest's rewardMultiplier) - a compromise reached without getting everything
    /// asked for, typically a middling answer partway down a branch that a better answer earlier
    /// would have avoided.
    /// </summary>
    PartialSuccess,

    /// <summary>Ends the conversation without completing the quest - the player can start over from the root next time.</summary>
    Failure,

    /// <summary>Ends the conversation and drops the character into an unplanned fight (GameEventService.TriggerRandomEncounterAsync) - the wrong answer at the wrong moment.</summary>
    Danger
}
