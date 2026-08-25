using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class BuriedOutpostAlidax : Quest
{
    public override string Name => "Under the Sand";

    public override string Description => "A three-day sandstorm buried a small trading post outside Alidax, and no word has come from the family that kept it since the wind died down.";

    public override string Objective => "Dig out the buried outpost and find out if anyone survived.";

    public override City City => City.Alidax;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 45;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? SearchLocation => City.Alidax;
}
