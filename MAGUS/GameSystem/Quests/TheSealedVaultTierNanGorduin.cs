using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class TheSealedVaultTierNanGorduin : Quest
{
    public override string Name => "What the Old Judges Sealed";

    public override string Description => "A crack in the temple's undercroft at TierNanGorduin has opened onto a sealed vault nobody currently serving remembers building - old enough that whatever mechanism guards it predates the current order entirely.";

    public override string Objective => "Search the undercroft at TierNanGorduin for the way into the sealed vault.";

    public override City City => City.TierNanGorduin;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 55;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? TrapLocation => City.TierNanGorduin;
}
