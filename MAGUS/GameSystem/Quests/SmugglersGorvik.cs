using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class SmugglersGorvik : Quest
{
    public override string Name => "Cargo in the Dark";

    public override string Description => "A harbourmaster in Gorvik suspects one of the docked ships is unloading more than its manifest declares, but has no proof and no one willing to look closer.";

    public override string Objective => "Investigate the suspicious ship at the Gorvik docks.";

    public override City City => City.Gorvik;

    public override Money MoneyReward => new(0, 7, 0);

    public override ulong ExperienceReward => 80;

    public override int MinLevel => 3;

    public override int MaxLevel => 6;

    public override City? SearchLocation => City.Gorvik;
}
