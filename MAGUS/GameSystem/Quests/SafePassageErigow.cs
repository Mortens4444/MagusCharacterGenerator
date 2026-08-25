using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class SafePassageErigow : Quest
{
    public override string Name => "Under Guard";

    public override string Description => "A moneylender in Erigow has finally recovered enough of what he's owed that he doesn't trust the road to Doran without someone walking beside the strongbox.";

    public override string Objective => "Escort the moneylender's strongbox safely to Doran.";

    public override City City => City.Erigow;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 50;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? EscortDestination => City.Doran;
}
