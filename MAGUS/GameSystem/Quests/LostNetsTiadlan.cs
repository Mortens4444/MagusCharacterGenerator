using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class LostNetsTiadlan : Quest
{
    public override string Name => "The Missing Nets";

    public override string Description => "A fishing crew in Tiadlan lost an entire season's worth of nets and gear somewhere along the riverbank during last week's flood, and without them they can't work the water at all.";

    public override string Objective => "Search the riverbank near Tiadlan for the lost fishing gear.";

    public override City City => City.Tiadlan;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Tiadlan;
}
