using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class ThievesOnTheElHamedRoad : Quest
{
    public override string Name => "Thieves on the El Hamed Road";

    public override string Description => "A small band of thieves has taken up along the approach to El Hamed, picking off travelers too tired from the journey to put up much of a fight.";

    public override string Objective => "Deal with the thieves preying on the road into El Hamed.";

    public override City City => City.ElHamed;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 35;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override bool TargetIsGeneratedBandit => true;
}
