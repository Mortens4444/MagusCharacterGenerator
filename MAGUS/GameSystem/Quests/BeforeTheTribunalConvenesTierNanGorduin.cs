using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class BeforeTheTribunalConvenesTierNanGorduin : Quest
{
    public override string Name => "Before the Tribunal Convenes";

    public override string Description => "A key witness has gone missing somewhere in TierNanGorduin the night before her testimony is due, and Darton's judges will not delay the tribunal for anyone - found in time, or the case collapses.";

    public override string Objective => "Find the missing witness in TierNanGorduin before the tribunal convenes.";

    public override City City => City.TierNanGorduin;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 50;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? SearchLocation => City.TierNanGorduin;

    public override double? TimeLimitHours => 12;
}
