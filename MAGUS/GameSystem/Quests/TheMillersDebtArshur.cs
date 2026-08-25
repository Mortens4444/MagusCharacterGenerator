using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class TheMillersDebtArshur : Quest
{
    public override string Name => "The Miller's Debt";

    public override string Description => "Arshur's mill changed hands twice in a bad year, and somewhere in the paperwork a debt receipt vanished - the current owner needs it found before the old creditor's heirs come collecting twice.";

    public override string Objective => "Search the mill in Arshur for the missing receipt.";

    public override City City => City.Arshur;

    public override Money MoneyReward => new(0, 3, 0);

    public override ulong ExperienceReward => 20;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override City? SearchLocation => City.Arshur;
}
