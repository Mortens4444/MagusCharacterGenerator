using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class HighPastureLeopardOrdan : Quest
{
    public override string Name => "Teeth in the Snow";

    public override string Description => "Shepherds driving flocks to the high pastures above Ordan have lost lambs to something fast and white that vanishes back into the rocks before anyone gets a clear look at it.";

    public override string Objective => "Track down and deal with the predator hunting the high pastures.";

    public override City City => City.Ordan;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 45;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override string? TargetCreatureName => "SnowLeopard";
}
