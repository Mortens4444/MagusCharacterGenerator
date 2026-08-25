using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class WaterDebtAlidax : Quest
{
    public override string Name => "Water Debt";

    public override string Description => "An Alidax waystation keeper who fronted water and grain to a struggling farmer in Abasis wants his due collected in person - politely, if possible, but collected either way.";

    public override string Objective => "Escort the debt collector safely to Abasis.";

    public override City City => City.Alidax;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 40;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? EscortDestination => City.Abasis;
}
