using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class RobbedTroupeAllanor : Quest
{
    public override string Name => "The Empty Wagon";

    public override string Description => "A traveling troupe bound for Allanor's harvest fair was robbed on the road - instruments, costumes, and the season's takings all gone - and without them the fair has nothing to open with.";

    public override string Objective => "Recover the troupe's stolen wagon and belongings before the fair opens.";

    public override City City => City.Allanor;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 35;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override bool TargetIsGeneratedBandit => true;
}
