using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class MarketGangToron : Quest
{
    public override string Name => "The Toll Collectors";

    public override string Description => "A gang has started 'protecting' stalls in one corner of Toron's market whether the owners want it or not, and the ones who refused to pay have had their goods quietly wrecked.";

    public override string Objective => "Deal with the gang shaking down Toron's market stalls.";

    public override City City => City.Toron;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 55;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override bool TargetIsGeneratedBandit => true;
}
