using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class PoisonedWellEvervis : Quest
{
    public override string Name => "Foul Water";

    public override string Description => "A well on the edge of Evervis has sickened half the households that draw from it. The healer has treated the symptoms but has no idea what's tainting the water itself.";

    public override string Objective => "Find the source of the well's contamination.";

    public override City City => City.Evervis;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 55;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? SearchLocation => City.Evervis;
}
