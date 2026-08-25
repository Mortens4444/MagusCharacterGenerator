using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class SeaSnakeNestRiegoy : Quest
{
    public override string Name => "Nest in the Reeds";

    public override string Description => "The reed shallows at the edge of Riegoy Bay have always been safe for wading and small boats - until this month, when two fishermen came back with bites nobody local claims to recognize.";

    public override string Objective => "Find and clear out the nest in Riegoy's reed shallows.";

    public override City City => City.Riegoy;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 45;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override string? TargetCreatureName => "SeaSnake";
}
