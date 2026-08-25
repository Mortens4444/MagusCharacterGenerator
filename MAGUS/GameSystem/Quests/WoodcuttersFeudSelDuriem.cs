using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class WoodcuttersFeudSelDuriem : Quest
{
    public override string Name => "Trouble in the Timber Camp";

    public override string Description => "A gang of sacked woodcutters has taken to ambushing Sel Duriem's timber wagons out of spite, and the ones still working the camp are too few to push back.";

    public override string Objective => "Deal with the sacked woodcutters ambushing the timber wagons near Sel Duriem.";

    public override City City => City.SelDuriem;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 35;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override bool TargetIsGeneratedBandit => true;
}
