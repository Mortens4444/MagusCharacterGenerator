using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class ShoalSerpentTiadlan : Quest
{
    public override string Name => "Coils in the Shallows";

    public override string Description => "A sea snake has taken up residence in the shallows where Tiadlan's children used to swim, and it's already struck at two fishermen wading out to check their lines.";

    public override string Objective => "Kill or drive off the sea snake in Tiadlan's shallows.";

    public override City City => City.Tiadlan;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 35;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override string? TargetCreatureName => "SeaSnake";
}
