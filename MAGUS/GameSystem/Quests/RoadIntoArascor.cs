using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class RoadIntoArascor : Quest
{
    public override string Name => "The Road Into Arascor";

    public override string Description => "A gang has taken to shaking down anyone approaching Arascor from the outlying trail, betting correctly that a town this rarely visited has no standing patrol to stop them.";

    public override string Objective => "Clear the raiders off the approach road into Arascor.";

    public override City City => City.Arascor;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 40;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override bool TargetIsGeneratedBandit => true;
}
