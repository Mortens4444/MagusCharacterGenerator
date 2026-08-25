using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class ShipwreckSurvivorsRiegoy : Quest
{
    public override string Name => "Wreckage on the Bay";

    public override string Description => "Fishermen spotted wreckage washing into Riegoy Bay after last night's storm - and what might be a signal fire on one of the small islands further out.";

    public override string Objective => "Search the bay for survivors of the wreck.";

    public override City City => City.Riegoy;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 40;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Riegoy;
}
