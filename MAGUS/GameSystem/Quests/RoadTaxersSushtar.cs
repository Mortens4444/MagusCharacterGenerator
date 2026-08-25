using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class RoadTaxersSushtar : Quest
{
    public override string Name => "Unlicensed Collectors";

    public override string Description => "A gang has set up a checkpoint on the approach to Sushtar, waving a forged writ and demanding coin from every cart and traveler that passes.";

    public override string Objective => "Break up the gang shaking down travelers outside Sushtar.";

    public override City City => City.Sushtar;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 40;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override bool TargetIsGeneratedBandit => true;
}
