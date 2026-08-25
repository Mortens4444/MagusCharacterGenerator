using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

/// <summary>Sonnion is a ruined, uninhabited amund city, so like LostTextSonnion this has no city NPC to hand it out - the looters are simply who you run into while working the ruins.</summary>
public sealed class RuinLootersSonnion : Quest
{
    public override string Name => "Not Here for the History";

    public override string Description => "A gang has set up camp in Sonnion's outer ruins, stripping anything valuable and smashing whatever they can't carry, with no interest in what any of it actually meant.";

    public override string Objective => "Deal with the looters camped in Sonnion's ruins.";

    public override City City => City.Sonnion;

    public override Money MoneyReward => new(0, 8, 0);

    public override ulong ExperienceReward => 70;

    public override int MinLevel => 3;

    public override int MaxLevel => 5;

    public override bool TargetIsGeneratedBandit => true;
}
