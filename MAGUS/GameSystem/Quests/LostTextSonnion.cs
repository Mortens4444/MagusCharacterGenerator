using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

/// <summary>Sonnion (Thon-nion) is a ruined, uninhabited amund city, so this quest has no NPC to hand it out - it's simply what a careful search of the ruins turns up.</summary>
public sealed class LostTextSonnion : Quest
{
    public override string Name => "Echoes of Thon-nion";

    public override string Description => "Half-buried among Sonnion's collapsed colonnades, a sealed archive chamber still stands - untouched, as far as you can tell, by the centuries or by other looters.";

    public override string Objective => "Search the archive chamber for anything worth salvaging.";

    public override City City => City.Sonnion;

    public override Money MoneyReward => new(0, 10, 0);

    public override ulong ExperienceReward => 100;

    public override int MinLevel => 4;

    public override int MaxLevel => 7;

    public override City? SearchLocation => City.Sonnion;
}
