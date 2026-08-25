using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class PrizeRamAllanor : Quest
{
    public override string Name => "The Prize Ram";

    public override string Description => "The ram expected to win Allanor's harvest fair three years running has gone missing from its pen the night before judging, and its owner suspects a rival breeder more than simple bad luck.";

    public override string Objective => "Search Allanor for the missing prize ram.";

    public override City City => City.Allanor;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 25;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override City? SearchLocation => City.Allanor;
}
