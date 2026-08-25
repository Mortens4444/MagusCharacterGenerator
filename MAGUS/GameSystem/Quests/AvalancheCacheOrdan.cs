using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class AvalancheCacheOrdan : Quest
{
    public override string Name => "Buried Supplies";

    public override string Description => "An avalanche took out a supply cache meant to resupply the mining camps above Ordan for the whole winter, and without it the crews up there won't last the season.";

    public override string Objective => "Search the avalanche site above Ordan for the buried supplies.";

    public override City City => City.Ordan;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 35;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Ordan;
}
