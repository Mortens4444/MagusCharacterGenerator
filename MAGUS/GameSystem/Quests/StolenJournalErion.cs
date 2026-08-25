using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class StolenJournalErion : Quest
{
    public override string Name => "Borrowed Without Asking";

    public override string Description => "A researcher in Erion is missing the field journal holding three years of unpublished notes, and she's certain a rival took it rather than lost it.";

    public override string Objective => "Search Erion for the missing research journal.";

    public override City City => City.Erion;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 40;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Erion;
}
