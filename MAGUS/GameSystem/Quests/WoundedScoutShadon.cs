using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class WoundedScoutShadon : Quest
{
    public override string Name => "Get the Wounded Scout Out";

    public override string Description => "A scout stumbled into camp bleeding and half-delirious, insisting the road ahead isn't safe - if anything comes for the camp tonight, someone needs to keep him alive long enough to hear the rest of what he knows.";

    public override string Objective => "Keep the wounded scout alive if trouble finds the camp.";

    public override City City => City.Shadon;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 55;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override bool HasProtectAlly => true;

    public override string AllyDescription => "the wounded scout";
}
