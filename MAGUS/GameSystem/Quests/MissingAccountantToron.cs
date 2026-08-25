using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class MissingAccountantToron : Quest
{
    public override string Name => "The Ledger Went With Him";

    public override string Description => "A merchant house accountant vanished from Toron three days ago along with the only complete ledger of who owes whom, and both his employer and several nervous debtors want him found first.";

    public override string Objective => "Search Toron for the missing accountant and his ledger.";

    public override City City => City.Toron;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 40;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Toron;
}
