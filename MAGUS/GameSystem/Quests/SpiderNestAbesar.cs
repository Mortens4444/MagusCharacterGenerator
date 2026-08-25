using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class SpiderNestAbesar : Quest
{
    public override string Name => "What the Sand Hides";

    public override string Description => "The relic hunters who broke into that sealed chamber near Abesar weren't the first thing living down there - something with too many legs has been dragging livestock into the dunes ever since.";

    public override string Objective => "Find and destroy the nest in the desert ruins outside Abesar.";

    public override City City => City.Abesar;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 55;

    public override int MinLevel => 2;

    public override int MaxLevel => 5;

    public override string? TargetCreatureName => "GiantSpider";
}
