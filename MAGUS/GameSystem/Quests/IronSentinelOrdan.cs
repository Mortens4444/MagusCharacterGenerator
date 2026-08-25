using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class IronSentinelOrdan : Quest
{
    public override string Name => "The Sentinel in the Shaft";

    public override string Description => "An old silver mine above Ordan, sealed decades ago, has been reopened by treasure-seekers who didn't get far - something built of iron and old magic still guards whatever's left inside.";

    public override string Objective => "Deal with the guardian sealed in the old silver mine above Ordan.";

    public override City City => City.Ordan;

    public override Money MoneyReward => new(0, 7, 0);

    public override ulong ExperienceReward => 65;

    public override int MinLevel => 3;

    public override int MaxLevel => 5;

    public override string? TargetCreatureName => "IronGolem";
}
