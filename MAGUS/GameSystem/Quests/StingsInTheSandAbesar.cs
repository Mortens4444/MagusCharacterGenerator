using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class StingsInTheSandAbesar : Quest
{
    public override string Name => "Stings in the Sand";

    public override string Description => "A nest of scorpions has spread under the tent-camp outside Abesar faster than anyone noticed, and two children have already been stung badly enough to need the healer.";

    public override string Objective => "Clear the scorpion nest from the tent-camp outside Abesar.";

    public override City City => City.Abesar;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override string? TargetCreatureName => "Scorpion";
}
