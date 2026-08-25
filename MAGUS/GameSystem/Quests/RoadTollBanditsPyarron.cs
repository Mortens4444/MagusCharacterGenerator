using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class RoadTollBanditsPyarron : Quest
{
    public override string Name => "The Unofficial Toll";

    public override string Description => "A gang has taken to shaking down merchants on the last stretch of road before Pyarron's gates, close enough to the walls that the city guard's inaction has become its own scandal.";

    public override string Objective => "Deal with the gang extorting merchants near Pyarron's gates.";

    public override City City => City.Pyarron;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 55;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override bool TargetIsGeneratedBandit => true;
}
