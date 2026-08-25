using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class OgreAtTheOutpostShadon : Quest
{
    public override string Name => "The Thing at the Old Outpost";

    public override string Description => "An abandoned watchtower along Shadon's border has gone from empty to occupied, and whatever moved in is strong enough to have bent the tower's iron gate nearly in half getting through it.";

    public override string Objective => "Deal with whatever has taken the old watchtower on Shadon's border.";

    public override City City => City.Shadon;

    public override Money MoneyReward => new(0, 8, 0);

    public override ulong ExperienceReward => 75;

    public override int MinLevel => 3;

    public override int MaxLevel => 6;

    public override string? TargetCreatureName => "Ogar";
}
