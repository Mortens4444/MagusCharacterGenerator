using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class SeaSerpentTiadlan : Quest
{
    public override string Name => "Something in the Swells";

    public override string Description => "Fishermen out of Tiadlan are refusing to sail past the northern shoals, swearing something huge surfaced near their boats and dragged a net clean under.";

    public override string Objective => "Find out what's lurking in the northern shoals.";

    public override City City => City.Tiadlan;

    public override Money MoneyReward => new(0, 8, 0);

    public override ulong ExperienceReward => 95;

    public override int MinLevel => 4;

    public override int MaxLevel => 7;

    public override string? TargetCreatureName => "DemonShark";
}
