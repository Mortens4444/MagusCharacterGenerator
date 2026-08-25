using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class HighwaymenOnTheRoadKalaril : Quest
{
    public override string Name => "The Kalaril Road Problem";

    public override string Description => "Every trader who's ridden into Kalaril in the last week has the same story: a small band waiting in the treeline just outside town, happy to lighten anyone's saddlebags.";

    public override string Objective => "Deal with the highwaymen waiting outside Kalaril.";

    public override City City => City.Kalaril;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 35;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override bool TargetIsGeneratedBandit => true;
}
