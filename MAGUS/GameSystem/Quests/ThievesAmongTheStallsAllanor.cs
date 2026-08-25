using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class ThievesAmongTheStallsAllanor : Quest
{
    public override string Name => "Thieves Among the Stalls";

    public override string Description => "A ring of cutpurses has been working Allanor's crowded fairgrounds all week, slitting purse-strings and vanishing into the crowd before anyone can raise a shout.";

    public override string Objective => "Track down and stop the thieves working Allanor's fairgrounds.";

    public override City City => City.Allanor;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 50;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override bool TargetIsGeneratedBandit => true;
}
