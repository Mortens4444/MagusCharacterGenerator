using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class MissingSealPyarron : Quest
{
    public override string Name => "The Chancellor's Seal";

    public override string Description => "A minor chancellery clerk in Pyarron misplaced the wax seal used to certify trade permits, and until it's found or replaced, half the merchant guild's paperwork is stuck in limbo.";

    public override string Objective => "Search Pyarron for the missing chancellery seal.";

    public override City City => City.Pyarron;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Pyarron;
}
