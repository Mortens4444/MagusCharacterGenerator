using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class BuriedBeneathBolk : Quest
{
    public override string Name => "Buried Beneath Bolk";

    public override string Description => "A collapsed cellar under one of Bolk's older houses turned up an iron-banded chest during repairs - the owner has no idea whose it was, and would rather not find out the hard way.";

    public override string Objective => "Search the collapsed cellar in Bolk before word of the chest spreads further.";

    public override City City => City.Bolk;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 25;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Bolk;
}
