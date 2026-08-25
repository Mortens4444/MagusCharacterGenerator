using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class WellPoisonersHaonwell : Quest
{
    public override string Name => "Bad Water";

    public override string Description => "A gang trying to squeeze protection money out of Haonwell's tavern-keepers has taken to fouling the well of anyone who refuses to pay.";

    public override string Objective => "Run off the gang threatening Haonwell's water supply.";

    public override City City => City.Haonwell;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 35;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override bool TargetIsGeneratedBandit => true;
}
