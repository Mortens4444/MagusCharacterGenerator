using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class SmuggledCratesPyarron : Quest
{
    public override string Name => "Crates Without a Manifest";

    public override string Description => "A dockside warehouse in Pyarron is holding a shipment nobody will claim, and the harbor master suspects it's being deliberately hidden among legitimate cargo until the fuss dies down.";

    public override string Objective => "Search Pyarron's warehouses for the unclaimed shipment.";

    public override City City => City.Pyarron;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 40;

    public override int MinLevel => 2;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Pyarron;
}
