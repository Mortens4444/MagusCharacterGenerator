using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class BuriedStrongboxMezrud : Quest
{
    public override string Name => "What the Flood Uncovered";

    public override string Description => "A spring flood near Mezrud scoured out a stretch of riverbank and exposed the corner of an old iron strongbox - too heavy for whoever found it to dig out alone before the water rose again.";

    public override string Objective => "Search the exposed riverbank near Mezrud for the buried strongbox.";

    public override City City => City.Mezrud;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Mezrud;
}
