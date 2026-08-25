using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class ThePressGangOfCaedon : Quest
{
    public override string Name => "The Press Gang of Caedon";

    public override string Description => "A crew of thugs has been strong-arming Caedon's smaller merchants into paying for 'protection' nobody asked for and nobody's seen delivered.";

    public override string Objective => "Break up the extortion racket operating in Caedon.";

    public override City City => City.Caedon;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 35;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override bool TargetIsGeneratedBandit => true;
}
