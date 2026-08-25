using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class SilentLighthouseGorvik : Quest
{
    public override string Name => "The Dark Light";

    public override string Description => "The lighthouse guiding ships into Gorvik's harbor has gone dark three nights running, and no one who's rowed out to check has come back to explain why.";

    public override string Objective => "Find out what happened at the lighthouse and get it lit again.";

    public override City City => City.Gorvik;

    public override Money MoneyReward => new(0, 8, 0);

    public override ulong ExperienceReward => 85;

    public override int MinLevel => 3;

    public override int MaxLevel => 6;

    public override City? SearchLocation => City.Gorvik;
}
