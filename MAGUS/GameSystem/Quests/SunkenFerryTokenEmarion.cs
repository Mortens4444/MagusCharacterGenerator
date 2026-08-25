using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class SunkenFerryTokenEmarion : Quest
{
    public override string Name => "The Ferryman's Token";

    public override string Description => "A brass token that opens the old toll-house strongbox slipped from a ferryman's pocket somewhere along Emarion's landing, and he can't afford to have the smith cut him a new one.";

    public override string Objective => "Search Emarion's landing for the missing ferry token.";

    public override City City => City.Emarion;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 25;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Emarion;
}
