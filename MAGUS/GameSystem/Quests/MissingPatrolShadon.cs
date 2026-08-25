using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class MissingPatrolShadon : Quest
{
    public override string Name => "The Overdue Patrol";

    public override string Description => "A three-man border patrol out of Shadon never returned from their usual sweep of the hills, and the garrison can't spare more men to look without leaving the line thin.";

    public override string Objective => "Search the border hills near Shadon for the missing patrol.";

    public override City City => City.Shadon;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 45;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? SearchLocation => City.Shadon;
}
