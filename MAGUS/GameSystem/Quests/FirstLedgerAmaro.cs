using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class FirstLedgerAmaro : Quest
{
    public override string Name => "The First Ledger";

    public override string Description => "Amaro sees so few outside travelers that the harbor clerk keeps a separate ledger just for them - and the last page of it references a strongbox that was never logged as delivered.";

    public override string Objective => "Search Amaro's harbor district for the missing strongbox.";

    public override City City => City.Amaro;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 25;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Amaro;
}
