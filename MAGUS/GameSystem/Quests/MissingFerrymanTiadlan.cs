using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class MissingFerrymanTiadlan : Quest
{
    public override string Name => "The Ferryman Didn't Come Back";

    public override string Description => "The old ferryman who crosses travelers over Tiadlan's river at dusk never returned last night, and his boat washed up empty a mile downstream.";

    public override string Objective => "Search along the river near Tiadlan for the missing ferryman.";

    public override City City => City.Tiadlan;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override City? SearchLocation => City.Tiadlan;
}
