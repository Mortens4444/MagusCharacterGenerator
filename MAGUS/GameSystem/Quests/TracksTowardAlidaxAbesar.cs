using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class TracksTowardAlidaxAbesar : Quest
{
    public override string Name => "Tracks Toward Alidax";

    public override string Description => "An Abesar trader's strongbox went missing the same night a hired hand disappeared, and the last anyone saw of him he was asking about the road to Alidax.";

    public override string Objective => "Follow the trail and search Alidax for the trader's missing strongbox.";

    public override City City => City.Abesar;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 35;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Alidax;
}
