using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class WolvesAtTheFenceLineAbasis : Quest
{
    public override string Name => "Wolves at the Fence Line";

    public override string Description => "A shepherd outside Abasis spotted a wolf pack circling the north pasture at dusk - if nobody deals with them tonight, the flock won't survive till morning.";

    public override string Objective => "Drive off the wolf pack before they reach the flock.";

    public override City City => City.Abasis;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 45;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override string? TargetCreatureName => "Wolf";

    public override double? TimeLimitHours => 10;
}
