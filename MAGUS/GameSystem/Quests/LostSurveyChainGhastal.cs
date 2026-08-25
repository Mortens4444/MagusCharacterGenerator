using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class LostSurveyChainGhastal : Quest
{
    public override string Name => "The Surveyor's Chain";

    public override string Description => "A traveling surveyor mapping the roads around Ghastal lost his measuring chain somewhere in the town proper and can't finish his work without it.";

    public override string Objective => "Search Ghastal for the surveyor's lost measuring chain.";

    public override City City => City.Ghastal;

    public override Money MoneyReward => new(0, 3, 0);

    public override ulong ExperienceReward => 20;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override City? SearchLocation => City.Ghastal;
}
