using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class ThievesDenPyarron : Quest
{
    public override string Name => "Under the Old Quarter";

    public override string Description => "A string of burglaries in Pyarron's old quarter all lead to the same collapsed cellar - and whoever's living down there isn't entirely welcome company for the neighbors above.";

    public override string Objective => "Clear out whatever is nesting beneath Pyarron's old quarter.";

    public override City City => City.Pyarron;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 45;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override string? TargetCreatureName => "Goblin";
}
