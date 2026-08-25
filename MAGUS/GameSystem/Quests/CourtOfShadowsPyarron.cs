using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class CourtOfShadowsPyarron : Quest
{
    public override string Name => "A Guest at Court";

    public override string Description => "A noble house in Pyarron has quietly asked for help after a string of servants turned up pale, exhausted, and unwilling to talk about the guest who visits their mistress only after dark.";

    public override string Objective => "Deal with whatever - or whoever - is preying on the noble house in Pyarron.";

    public override City City => City.Pyarron;

    public override Money MoneyReward => new(0, 9, 0);

    public override ulong ExperienceReward => 90;

    public override int MinLevel => 4;

    public override int MaxLevel => 7;

    public override string? TargetCreatureName => "Vampire";
}
