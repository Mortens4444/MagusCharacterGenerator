using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class ArsonistErigow : Quest
{
    public override string Name => "Smoke at Night";

    public override string Description => "Three warehouses near Erigow's market square have burned in as many weeks, always after dark, always empty of witnesses. The guild masters fear they're next.";

    public override string Objective => "Catch whoever is setting the fires before another warehouse burns.";

    public override City City => City.Erigow;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 55;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? SearchLocation => City.Erigow;
}
