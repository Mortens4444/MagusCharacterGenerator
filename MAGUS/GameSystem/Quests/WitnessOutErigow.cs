using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class WitnessOutErigow : Quest
{
    public override string Name => "Somebody Saw Something";

    public override string Description => "A warehouse hand in Evervis saw more of the merchant houses' sabotage than was healthy for her to see, and now she'd very much like to be somewhere else - specifically, family in Erigow.";

    public override string Objective => "Escort the witness safely to Erigow.";

    public override City City => City.Evervis;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 50;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? EscortDestination => City.Erigow;
}
