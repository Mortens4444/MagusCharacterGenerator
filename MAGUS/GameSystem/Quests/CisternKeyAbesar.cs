using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class CisternKeyAbesar : Quest
{
    public override string Name => "The Cistern Key";

    public override string Description => "The iron key to Abesar's shared cistern went missing off the elder's belt during the last sandstorm, and until it's found the whole quarter is drawing water through a hole barely wide enough for a bucket.";

    public override string Objective => "Search Abesar for the missing cistern key.";

    public override City City => City.Abesar;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 25;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override City? SearchLocation => City.Abesar;
}
