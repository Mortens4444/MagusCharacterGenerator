using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

/// <summary>Laorgan rarely sees outside visitors, so a stranger willing to poke around the old works is worth a few coins to the locals.</summary>
public sealed class LostToolCacheLaorgan : Quest
{
    public override string Name => "The Old Works";

    public override string Description => "A prospector's cache of tools and surveying gear went missing from the abandoned works outside Laorgan, and the foreman swears someone local knows exactly where it ended up.";

    public override string Objective => "Search around Laorgan's old works for the missing tool cache.";

    public override City City => City.Laorgan;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 25;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Laorgan;
}
