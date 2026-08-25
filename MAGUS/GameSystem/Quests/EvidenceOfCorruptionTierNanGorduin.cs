using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class EvidenceOfCorruptionTierNanGorduin : Quest
{
    public override string Name => "The Judge's Other Ledger";

    public override string Description => "A junior priest at TierNanGorduin is convinced one of Darton's own judges has been taking bribes to rule cases early - but proving it means getting into that judge's private chambers and finding the ledger he keeps of who's paid.";

    public override string Objective => "Steal the corrupt judge's private ledger from his chambers at TierNanGorduin.";

    public override City City => City.TierNanGorduin;

    public override Money MoneyReward => new(0, 7, 0);

    public override ulong ExperienceReward => 60;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? StealLocation => City.TierNanGorduin;
}
