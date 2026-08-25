using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class ShakedownAtTheMarketIfin : Quest
{
    public override string Name => "Market Day Shakedown";

    public override string Description => "A rough crew has taken to strong-arming Ifin's market-day stallholders into handing over their morning takings before the square even fills up.";

    public override string Objective => "Break up the crew shaking down Ifin's market stalls.";

    public override City City => City.Ifin;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 40;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override bool TargetIsGeneratedBandit => true;
}
