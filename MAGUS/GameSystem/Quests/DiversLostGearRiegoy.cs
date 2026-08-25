using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class DiversLostGearRiegoy : Quest
{
    public override string Name => "Left on the Seabed";

    public override string Description => "A pearl diver's entire kit - weights, lines, breathing reed, the lot - went down with her during a bad dive off Riegoy and never came back up, and she can't afford to replace it herself.";

    public override string Objective => "Search the waters off Riegoy for the diver's lost gear.";

    public override City City => City.Riegoy;

    public override Money MoneyReward => new(0, 3, 0);

    public override ulong ExperienceReward => 25;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override City? SearchLocation => City.Riegoy;
}
