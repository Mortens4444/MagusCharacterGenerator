using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class HarborBearGorvik : Quest
{
    public override string Name => "Trouble on the Ice Docks";

    public override string Description => "A half-starved bear has taken to prowling Gorvik's ice docks after dark, and it's already put one dockhand in the healer's care.";

    public override string Objective => "Drive off or kill the bear troubling Gorvik's docks.";

    public override City City => City.Gorvik;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 50;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override string? TargetCreatureName => "PolarBear";
}
