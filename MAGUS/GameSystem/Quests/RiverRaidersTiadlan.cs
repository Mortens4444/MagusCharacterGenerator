using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class RiverRaidersTiadlan : Quest
{
    public override string Name => "Wreckers on the Water";

    public override string Description => "Boats working Tiadlan's river have been boarded twice this week by raiders who seem to know exactly which cargo is worth taking, and no honest crew wants to risk a third crossing.";

    public override string Objective => "Deal with the raiders boarding boats on Tiadlan's river.";

    public override City City => City.Tiadlan;

    public override Money MoneyReward => new(0, 7, 0);

    public override ulong ExperienceReward => 60;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override bool TargetIsGeneratedBandit => true;
}
