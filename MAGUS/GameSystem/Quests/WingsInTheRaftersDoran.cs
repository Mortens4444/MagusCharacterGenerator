using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class WingsInTheRaftersDoran : Quest
{
    public override string Name => "Wings in the Rafters";

    public override string Description => "A colony of unnaturally large bats has moved into the attic of a shuttered Doran manor, and the neighbors want them cleared out before the smell - or worse, the bites - spreads any further.";

    public override string Objective => "Clear the bats out of the shuttered manor's attic in Doran.";

    public override City City => City.Doran;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override string? TargetCreatureName => "Bat";
}
