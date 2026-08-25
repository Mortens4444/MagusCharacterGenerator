using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class WharfSkiffCrewEnosuke : Quest
{
    public override string Name => "The Night Skiff";

    public override string Description => "A small, fast skiff has been slipping between the anchored trade ships after dark, and whatever its crew is taking, the captains it's taken from want it back.";

    public override string Objective => "Catch the crew raiding ships anchored off Enosuke.";

    public override City City => City.Enosuke;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 55;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override bool TargetIsGeneratedBandit => true;
}
