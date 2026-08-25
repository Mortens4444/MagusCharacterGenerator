using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class ShakedownAtTerragin : Quest
{
    public override string Name => "Protection, Unwanted";

    public override string Description => "A self-appointed 'protection' outfit has been leaning on Terragin's smaller stallholders for coin they can't afford, and the ones who refused have had their goods trashed.";

    public override string Objective => "Deal with the thugs shaking down stallholders in Terragin.";

    public override City City => City.Terragin;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 40;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override bool TargetIsGeneratedBandit => true;
}
