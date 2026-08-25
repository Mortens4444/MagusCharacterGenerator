using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class MountainPassOrdan : Quest
{
    public override string Name => "Blocked Passage";

    public override string Description => "The mountain pass that feeds Ordan's trade has been unsafe for weeks - wagons turned back, one simply gone missing - and no caravan master will risk it without an escort.";

    public override string Objective => "Clear whatever is blocking the mountain pass.";

    public override City City => City.Ordan;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 60;

    public override int MinLevel => 2;

    public override int MaxLevel => 5;

    public override bool TargetIsGeneratedBandit => true;
}
