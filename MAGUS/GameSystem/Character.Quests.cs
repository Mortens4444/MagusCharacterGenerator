using MAGUS.GameSystem.Quests;

namespace MAGUS.GameSystem;

public partial class Character
{
    /// <summary>
    /// True for a throwaway bandit-type Character spawned as a combat quest's opponent (see
    /// MAGUS.Assistant.Services.BanditGenerator) rather than one of the player's own saved
    /// characters. Not persisted - the character itself is never saved.
    /// </summary>
    [System.Text.Json.Serialization.JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public bool IsGeneratedEnemy { get; set; }

    public List<QuestProgress> QuestProgress { get; } = [];

    /// <summary>
    /// Current status of this quest for this character - lazily expires a timed quest (see
    /// Quest.TimeLimitHours) whose deadline has passed into QuestStatus.Failed on the way out, the
    /// same "catch up whenever queried" pattern as CompleteTravelIfArrived.
    /// </summary>
    public QuestStatus GetQuestStatus(Quest quest)
    {
        var progress = QuestProgress.FirstOrDefault(q => q.QuestKey == quest.Key);
        if (progress == null)
        {
            return QuestStatus.NotStarted;
        }

        if (progress.Status is QuestStatus.Accepted or QuestStatus.ItemObtained &&
            quest.TimeLimitHours is { } limitHours &&
            (DateTime.UtcNow - progress.AcceptedAtUtc).TotalHours > limitHours)
        {
            progress.Status = QuestStatus.Failed;
        }

        return progress.Status;
    }

    public void AcceptQuest(Quest quest)
    {
        if (GetQuestStatus(quest) != QuestStatus.NotStarted)
        {
            return;
        }

        QuestProgress.Add(new QuestProgress { QuestKey = quest.Key, Status = QuestStatus.Accepted, AcceptedAtUtc = DateTime.UtcNow });
        OnPropertyChanged(nameof(QuestProgress));
    }

    /// <summary>
    /// Completes an accepted (or, for a delivery quest, item-obtained) quest and grants its reward
    /// (Money and/or experience via AddExperience), scaled by rewardMultiplier - 1.0 (the default) for
    /// the full reward, or e.g. 0.5 for a negotiation quest's DialogueOutcome.PartialSuccess, a
    /// compromise that didn't get everything asked for.
    /// </summary>
    public void CompleteQuest(Quest quest, double rewardMultiplier = 1.0)
    {
        var progress = QuestProgress.FirstOrDefault(q => q.QuestKey == quest.Key);
        if (progress == null || progress.Status is not (QuestStatus.Accepted or QuestStatus.ItemObtained))
        {
            return;
        }

        progress.Status = QuestStatus.Completed;

        Money += quest.MoneyReward * rewardMultiplier;
        var experienceReward = (ulong)(quest.ExperienceReward * rewardMultiplier);
        if (experienceReward > 0)
        {
            AddExperience(experienceReward);
        }

        OnPropertyChanged(nameof(QuestProgress));
    }

    /// <summary>
    /// Moves a delivery quest (see Quest.DeliveryDestination) from Accepted to ItemObtained once a
    /// Search at Quest.SearchLocation succeeds - the quest stays open until the character carries the
    /// item to DeliveryDestination and CompleteQuest is called there.
    /// </summary>
    public void MarkItemObtained(Quest quest)
    {
        var progress = QuestProgress.FirstOrDefault(q => q.QuestKey == quest.Key);
        if (progress == null || progress.Status != QuestStatus.Accepted)
        {
            return;
        }

        progress.Status = QuestStatus.ItemObtained;
        OnPropertyChanged(nameof(QuestProgress));
    }

    /// <summary>
    /// Fails an accepted (or item-obtained) quest outright - no reward, terminal like Completed. Used
    /// when a protected ally dies mid-Encounter (see EncounterViewModel.DieHandler/HasProtectAlly);
    /// a timed quest's own deadline failure goes through ExpireOverdueQuests instead.
    /// </summary>
    public void FailQuest(Quest quest)
    {
        var progress = QuestProgress.FirstOrDefault(q => q.QuestKey == quest.Key);
        if (progress == null || progress.Status is not (QuestStatus.Accepted or QuestStatus.ItemObtained))
        {
            return;
        }

        progress.Status = QuestStatus.Failed;
        OnPropertyChanged(nameof(QuestProgress));
    }

    /// <summary>
    /// Scans every accepted (or item-obtained) timed quest for a passed deadline, flips each one to
    /// QuestStatus.Failed, and returns the Quest.Key of every one that just expired - unlike
    /// GetQuestStatus's own lazy check (needed for correctness anywhere a single quest's status is
    /// queried), this looks at QuestProgress directly so it can report what changed, for
    /// CharacterViewModel to turn into a "quest failed" notification. Called from the same lazy
    /// "catch up whenever loaded" hook as CompleteTravelIfArrived/CompleteArrivalQuests.
    /// </summary>
    public List<string> ExpireOverdueQuests(IEnumerable<Quest> allQuests)
    {
        var timedQuestsByKey = allQuests.Where(q => q.HasTimeLimit).ToDictionary(q => q.Key);
        var expiredKeys = new List<string>();

        foreach (var progress in QuestProgress)
        {
            if (progress.Status is not (QuestStatus.Accepted or QuestStatus.ItemObtained))
            {
                continue;
            }

            if (!timedQuestsByKey.TryGetValue(progress.QuestKey, out var quest) || quest.TimeLimitHours is not { } limitHours)
            {
                continue;
            }

            if ((DateTime.UtcNow - progress.AcceptedAtUtc).TotalHours > limitHours)
            {
                progress.Status = QuestStatus.Failed;
                expiredKeys.Add(progress.QuestKey);
            }
        }

        if (expiredKeys.Count > 0)
        {
            OnPropertyChanged(nameof(QuestProgress));
        }

        return expiredKeys;
    }
}
