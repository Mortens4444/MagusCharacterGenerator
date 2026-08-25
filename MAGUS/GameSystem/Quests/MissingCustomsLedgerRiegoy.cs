using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class MissingCustomsLedgerRiegoy : Quest
{
    public override string Name => "The Missing Ledger";

    public override string Description => "Riegoy's customs house has lost the ledger recording an entire month of harbor traffic, and without it there's no way to tell which ships actually paid their tariffs.";

    public override string Objective => "Search the Riegoy customs house for the missing ledger.";

    public override City City => City.Riegoy;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Riegoy;
}
