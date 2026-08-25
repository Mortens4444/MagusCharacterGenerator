using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class BanditsAbasis : Quest
{
    public override string Name => "Toll of the Road";

    public override string Description => "Traders arriving in Abasis speak of a band collecting an illegal 'toll' on the trade road, at knifepoint, from anyone passing through.";

    public override string Objective => "Deal with the bandits holding the trade road.";

    public override City City => City.Abasis;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 60;

    public override int MinLevel => 2;

    public override int MaxLevel => 5;

    public override bool TargetIsGeneratedBandit => true;
}
