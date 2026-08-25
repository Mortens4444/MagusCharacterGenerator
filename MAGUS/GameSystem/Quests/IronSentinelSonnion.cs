using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

/// <summary>Sonnion is a ruined, uninhabited amund city, so like LostTextSonnion this has no city NPC to hand it out - the sentinel is simply what stands in your way while working the ruins.</summary>
public sealed class IronSentinelSonnion : Quest
{
    public override string Name => "Rusted But Not Dead";

    public override string Description => "A second guardian stands watch over a different quarter of Sonnion's ruins - iron where the other was stone, and no less willing to crush anything that steps past its post.";

    public override string Objective => "Destroy or disable the iron guardian blocking the ruins.";

    public override City City => City.Sonnion;

    public override Money MoneyReward => new(0, 11, 0);

    public override ulong ExperienceReward => 125;

    public override int MinLevel => 5;

    public override int MaxLevel => 8;

    public override string? TargetCreatureName => "IronGolem";
}
