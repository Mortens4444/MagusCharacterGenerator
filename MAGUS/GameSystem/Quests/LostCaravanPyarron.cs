using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class LostCaravanPyarron : Quest
{
    public override string Name => "The Overdue Caravan";

    public override string Description => "A merchant house in Pyarron has lost contact with a caravan that should have arrived from Erigow days ago. They fear bandits, or worse, on the road.";

    public override string Objective => "Find the missing caravan and report what became of it - search along the road near Erigow, where it was headed from.";

    public override City City => City.Pyarron;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 75;

    public override int MinLevel => 3;

    public override int MaxLevel => 6;

    public override City? SearchLocation => City.Erigow;
}
