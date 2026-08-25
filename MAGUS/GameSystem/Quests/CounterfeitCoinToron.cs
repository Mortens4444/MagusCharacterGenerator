using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class CounterfeitCoinToron : Quest
{
    public override string Name => "Bad Silver";

    public override string Description => "Toron's moneychangers are refusing coin from a particular batch - light, dull, and clearly counterfeit - and it's starting to choke trade in the market district.";

    public override string Objective => "Trace the counterfeit silver back to whoever is minting it.";

    public override City City => City.Toron;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 45;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? SearchLocation => City.Toron;
}
