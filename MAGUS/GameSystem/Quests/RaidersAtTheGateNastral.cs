using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class RaidersAtTheGateNastral : Quest
{
    public override string Name => "Trouble at the Gate";

    public override string Description => "A small band of raiders has been harassing the outskirts of Nastral, picking off livestock and lone travelers, and the gate wardens don't have the numbers to run them off themselves.";

    public override string Objective => "Drive off the raiders troubling Nastral's outskirts.";

    public override City City => City.Nastral;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 35;

    public override int MinLevel => 1;

    public override int MaxLevel => 4;

    public override bool TargetIsGeneratedBandit => true;
}
