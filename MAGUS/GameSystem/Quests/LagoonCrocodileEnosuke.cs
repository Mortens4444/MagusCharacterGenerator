using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class LagoonCrocodileEnosuke : Quest
{
    public override string Name => "Something in the Lagoon";

    public override string Description => "A fisherman's skiff came back to Enosuke's harbor empty and badly bitten, and nobody's willing to net the lagoon until whatever did it is dealt with.";

    public override string Objective => "Deal with the creature lurking in Enosuke's lagoon.";

    public override City City => City.Enosuke;

    public override Money MoneyReward => new(0, 7, 0);

    public override ulong ExperienceReward => 65;

    public override int MinLevel => 3;

    public override int MaxLevel => 5;

    public override string? TargetCreatureName => "GiantCrocodile";
}
