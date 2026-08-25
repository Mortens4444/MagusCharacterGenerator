using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class HighwayAmbushErigow : Quest
{
    public override string Name => "Toll of Broken Wheels";

    public override string Description => "A stretch of road just outside Erigow has swallowed two supply wagons in a month, wheels found broken and cargo gone, with no bodies and no witnesses left behind to say who did it.";

    public override string Objective => "Find and deal with whoever is ambushing wagons outside Erigow.";

    public override City City => City.Erigow;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 55;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override bool TargetIsGeneratedBandit => true;
}
