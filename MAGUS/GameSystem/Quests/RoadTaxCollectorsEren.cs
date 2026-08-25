using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class RoadTaxCollectorsEren : Quest
{
    public override string Name => "Uninvited Collectors";

    public override string Description => "A gang has set up a checkpoint on the approach to Eren, waving a forged writ and helping themselves to a cut of every cart that comes through.";

    public override string Objective => "Clear the false toll collectors off the road into Eren.";

    public override City City => City.Eren;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 40;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override bool TargetIsGeneratedBandit => true;
}
