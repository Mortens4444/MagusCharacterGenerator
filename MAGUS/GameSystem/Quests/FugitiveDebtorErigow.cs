using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class FugitiveDebtorErigow : Quest
{
    public override string Name => "Skipped Town";

    public override string Description => "A moneylender in Erigow wants a debtor found before he spends his way clear across the border - the man owes a small fortune and has a two-day head start.";

    public override string Objective => "Track down the fugitive debtor - word says he was making for Doran.";

    public override City City => City.Erigow;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Doran;
}
