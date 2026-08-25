using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class HighwaymenOnTheGrainRoadAbasis : Quest
{
    public override string Name => "Highwaymen on the Grain Road";

    public override string Description => "A second band has moved onto the roads around Abasis since the last toll-collectors were dealt with, this one smarter - they check wagons for guards first and only strike the ones traveling light.";

    public override string Objective => "Track down and stop the highwaymen targeting Abasis's grain wagons.";

    public override City City => City.Abasis;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 55;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override bool TargetIsGeneratedBandit => true;
}
