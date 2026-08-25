using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class MissingSeedStockAbasis : Quest
{
    public override string Name => "The Missing Seed Stock";

    public override string Description => "Next season's seed grain went missing from an Abasis granary sometime between the count and the planting, and without it half the tenant farms won't have anything to sow.";

    public override string Objective => "Search Abasis for the missing seed stock.";

    public override City City => City.Abasis;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 25;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override City? SearchLocation => City.Abasis;
}
