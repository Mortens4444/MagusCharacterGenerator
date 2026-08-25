using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class RaidedOasisAlidax : Quest
{
    public override string Name => "Dry Well, Empty Tents";

    public override string Description => "An oasis waystation outside Alidax was raided in the night - stores taken, the well fouled - and the caravans that depend on it are now stranded between towns.";

    public override string Objective => "Find who raided the oasis and make the water safe again.";

    public override City City => City.Alidax;

    public override Money MoneyReward => new(0, 7, 0);

    public override ulong ExperienceReward => 70;

    public override int MinLevel => 3;

    public override int MaxLevel => 5;

    public override City? SearchLocation => City.Alidax;
}
