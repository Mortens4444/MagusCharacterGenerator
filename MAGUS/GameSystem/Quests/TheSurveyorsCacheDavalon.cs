using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class TheSurveyorsCacheDavalon : Quest
{
    public override string Name => "The Surveyor's Cache";

    public override string Description => "An old land surveyor who charted Davalon's outskirts decades ago died without ever collecting his final fee - his notes hint at a small cache of instruments and coin left where he last worked.";

    public override string Objective => "Search Davalon's outskirts for the surveyor's cache.";

    public override City City => City.Davalon;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 25;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Davalon;
}
