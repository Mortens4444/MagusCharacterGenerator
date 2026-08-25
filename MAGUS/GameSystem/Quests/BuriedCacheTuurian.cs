using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class BuriedCacheTuurian : Quest
{
    public override string Name => "A Dying Man's Map";

    public override string Description => "A trader passing through Tuurian died of fever before he could collect on a cache he claimed to have buried years ago, leaving behind only a crude, half-legible map.";

    public override string Objective => "Search near Tuurian for the buried cache from the dying trader's map.";

    public override City City => City.Tuurian;

    public override Money MoneyReward => new(0, 3, 0);

    public override ulong ExperienceReward => 20;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override City? SearchLocation => City.Tuurian;
}
