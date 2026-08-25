using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class BuriedLedgerAlidax : Quest
{
    public override string Name => "The Buried Ledger";

    public override string Description => "The waystation master in Alidax swears his tally ledger was in the strongbox before the last sandstorm, and swears just as hard he has no idea how it ended up gone when the box was never forced.";

    public override string Objective => "Search Alidax for the waystation's missing ledger.";

    public override City City => City.Alidax;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 25;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override City? SearchLocation => City.Alidax;
}
