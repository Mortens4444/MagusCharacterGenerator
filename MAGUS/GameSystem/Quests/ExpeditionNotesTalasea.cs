using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class ExpeditionNotesTalasea : Quest
{
    public override string Name => "The Survey Left Behind";

    public override string Description => "A cataloguing expedition working Talasea's ruins packed up in a hurry after the tremors started, and left their entire survey ledger behind somewhere in the rubble.";

    public override string Objective => "Search Talasea's ruins for the expedition's lost survey ledger.";

    public override City City => City.Talasea;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 40;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? SearchLocation => City.Talasea;
}
