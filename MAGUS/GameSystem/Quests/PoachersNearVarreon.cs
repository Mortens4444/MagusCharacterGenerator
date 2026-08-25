using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class PoachersNearVarreon : Quest
{
    public override string Name => "Out of Season";

    public override string Description => "An armed poaching crew has been working the protected woodland outside Varreon, stripping it of game the local hunters' guild depends on for the whole town's winter stores.";

    public override string Objective => "Track down and stop the poachers working the woods near Varreon.";

    public override City City => City.Varreon;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 35;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override bool TargetIsGeneratedBandit => true;
}
