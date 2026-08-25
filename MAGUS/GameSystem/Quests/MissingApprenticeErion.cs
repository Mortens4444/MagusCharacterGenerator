using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

/// <summary>Erion is Első Törvénykönyv's "Kalandozók Városa" (City of Adventurers) - fittingly, its first quest is exactly the kind of odd job posted on its boards.</summary>
public sealed class MissingApprenticeErion : Quest
{
    public override string Name => "The Apprentice Who Wandered Off";

    public override string Description => "A minor scholar in Erion is offering coin for word of his apprentice, last seen chasing rumors of ruins outside the city three days ago.";

    public override string Objective => "Track down the missing apprentice and see them safely back.";

    public override City City => City.Erion;

    public override Money MoneyReward => new(0, 8, 0);

    public override ulong ExperienceReward => 100;

    public override int MinLevel => 4;

    public override int MaxLevel => 7;

    public override City? SearchLocation => City.Erion;
}
