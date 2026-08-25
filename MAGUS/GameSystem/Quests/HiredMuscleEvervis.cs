using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class HiredMuscleEvervis : Quest
{
    public override string Name => "Persuasion, Evervis Style";

    public override string Description => "One of Evervis's merchant houses has started hiring rough men to lean on the other's carters, and a few bruises have already turned into something worse.";

    public override string Objective => "Deal with the hired muscle intimidating Evervis's carters.";

    public override City City => City.Evervis;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 50;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override bool TargetIsGeneratedBandit => true;
}
