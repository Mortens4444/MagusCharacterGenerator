using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class RaidersOnTheRoadPyarron : Quest
{
    public override string Name => "Blood on the Capital Road";

    public override string Description => "A trade road feeding Pyarron itself has been hit twice this month by raiders bold enough to strike within sight of the city walls, and the merchant guilds want it ended before panic does more damage than the raiders have.";

    public override string Objective => "Deal with the raiders striking the road into Pyarron.";

    public override City City => City.Pyarron;

    public override Money MoneyReward => new(0, 7, 0);

    public override ulong ExperienceReward => 70;

    public override int MinLevel => 3;

    public override int MaxLevel => 5;

    public override string? TargetCreatureName => "Orc";
}
