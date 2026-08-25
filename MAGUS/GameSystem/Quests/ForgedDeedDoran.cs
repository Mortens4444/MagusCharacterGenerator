using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class ForgedDeedDoran : Quest
{
    public override string Name => "The Forged Deed";

    public override string Description => "A Doran landholder suspects the deed to his late father's warehouse has been swapped for a forgery somewhere in his own study, and he'd rather find proof quietly before accusing anyone by name.";

    public override string Objective => "Search Doran for the original warehouse deed.";

    public override City City => City.Doran;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Doran;
}
