using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class FarmYardMenaceAllanor : Quest
{
    public override string Name => "The Farm-Yard Menace";

    public override string Description => "A pack of half-wild mongrels has been slipping through a gap in the fences around Allanor after dark, worrying the fair livestock into a state no amount of calming will settle before judging.";

    public override string Objective => "Deal with the mongrel pack menacing Allanor's fair livestock.";

    public override City City => City.Allanor;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override string? TargetCreatureName => "Mongrel";
}
