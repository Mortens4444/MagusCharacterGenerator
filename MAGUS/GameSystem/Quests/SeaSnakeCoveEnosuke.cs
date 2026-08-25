using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class SeaSnakeCoveEnosuke : Quest
{
    public override string Name => "Something in the Shallows";

    public override string Description => "Pearl divers working the shallows off Enosuke have stopped going in the water after two lost fingers and a shredded net turned out not to be the work of any fish anyone recognized.";

    public override string Objective => "Deal with whatever is lurking in the shallows off Enosuke.";

    public override City City => City.Enosuke;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 55;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override string? TargetCreatureName => "SeaSnake";
}
