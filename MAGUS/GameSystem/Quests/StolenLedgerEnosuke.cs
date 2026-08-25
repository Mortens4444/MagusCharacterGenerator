using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class StolenLedgerEnosuke : Quest
{
    public override string Name => "Missing Manifest";

    public override string Description => "A trading house clerk in Enosuke has misplaced - or had stolen - the manifest proving which shipments already paid harbor tax, and without it every house on the wharf is accusing every other of dodging their share.";

    public override string Objective => "Search Enosuke for the missing manifest.";

    public override City City => City.Enosuke;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Enosuke;
}
