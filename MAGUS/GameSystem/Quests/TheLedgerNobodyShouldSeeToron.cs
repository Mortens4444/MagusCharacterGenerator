using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class TheLedgerNobodyShouldSeeToron : Quest
{
    public override string Name => "The Ledger Nobody Should See";

    public override string Description => "A rival merchant in Toron keeps a second, more honest set of books locked in her office - the kind of evidence that would end a guild dispute overnight, if someone could get to it without being seen.";

    public override string Objective => "Steal the second ledger from the merchant's office in Toron.";

    public override City City => City.Toron;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 55;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? StealLocation => City.Toron;
}
