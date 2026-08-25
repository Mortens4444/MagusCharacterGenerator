using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

/// <summary>Sonnion is a ruined, uninhabited amund city, so like LostTextSonnion this has no city NPC to hand it out - the hollow floor is simply what a careful search of the ruins turns up.</summary>
public sealed class TheFloorThatIsntSonnion : Quest
{
    public override string Name => "The Floor That Isn't";

    public override string Description => "A section of Sonnion's inner sanctum sounds hollow underfoot, and the carvings nearby hint at a hidden mechanism - but whoever built this clearly didn't want it found by accident.";

    public override string Objective => "Search the inner sanctum in Sonnion for the hidden mechanism.";

    public override City City => City.Sonnion;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 55;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? TrapLocation => City.Sonnion;
}
