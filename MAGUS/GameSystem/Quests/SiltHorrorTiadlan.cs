using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class SiltHorrorTiadlan : Quest
{
    public override string Name => "Something in the Silt";

    public override string Description => "The riverbank mud outside Tiadlan has started swallowing whole fence posts overnight, and one farmer's dog never came back from investigating the churned-up ground.";

    public override string Objective => "Find and kill whatever is burrowing through the riverbank silt.";

    public override City City => City.Tiadlan;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 55;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override string? TargetCreatureName => "SwampWorm";
}
