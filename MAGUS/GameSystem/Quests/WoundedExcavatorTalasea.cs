using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class WoundedExcavatorTalasea : Quest
{
    public override string Name => "Get Him Out Alive";

    public override string Description => "A dig foreman broke his leg badly when a passage in Talasea's ruins collapsed, and the site's healer says he needs a proper surgeon - the nearest one is in Toron, and the road is no place for a man who can't run.";

    public override string Objective => "Escort the injured foreman safely to Toron.";

    public override City City => City.Talasea;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 50;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? EscortDestination => City.Toron;
}
