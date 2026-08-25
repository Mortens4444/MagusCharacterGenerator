using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class DrownedStrongboxTiadlan : Quest
{
    public override string Name => "The Trader's Strongbox";

    public override string Description => "A trader's barge capsized in Tiadlan's current last month, and while the crew made it to shore, his strongbox never surfaced - and he's offering a fair cut to whoever finds it first.";

    public override string Objective => "Search the river near Tiadlan for the trader's lost strongbox.";

    public override City City => City.Tiadlan;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 35;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Tiadlan;
}
