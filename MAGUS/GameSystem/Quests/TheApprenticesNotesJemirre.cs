using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class TheApprenticesNotesJemirre : Quest
{
    public override string Name => "The Apprentice's Notes";

    public override string Description => "A scribe's apprentice in Jem-Irre misplaced an entire season's worth of ledger notes the night before they were due, and swears they're somewhere in town if only someone would look.";

    public override string Objective => "Search Jem-Irre for the apprentice's missing ledger notes.";

    public override City City => City.Jemirre;

    public override Money MoneyReward => new(0, 3, 0);

    public override ulong ExperienceReward => 20;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override City? SearchLocation => City.Jemirre;
}
