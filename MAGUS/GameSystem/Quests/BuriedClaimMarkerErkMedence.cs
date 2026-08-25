using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

/// <summary>Erk medence (the Erk basin) is a low-lying settlement newly added to the map - little is established about it yet beyond its place on the basin floor, so this quest keeps to grounded local flavor rather than inventing deep lore.</summary>
public sealed class BuriedClaimMarkerErkMedence : Quest
{
    public override string Name => "The Basin's Old Boundary";

    public override string Description => "A silt-covered boundary marker has resurfaced at the edge of Erk medence after the spring floods, and whoever finds it first can settle an old argument over where one family's land actually ends.";

    public override string Objective => "Search the basin's edge for the resurfaced boundary marker.";

    public override City City => City.ErkMedence;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 25;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.ErkMedence;
}
