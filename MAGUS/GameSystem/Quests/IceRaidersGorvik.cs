using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class IceRaidersGorvik : Quest
{
    public override string Name => "Raiders on the Ice";

    public override string Description => "Fishing shacks on Gorvik's frozen inlet have been ransacked twice this month, gear stolen and one shack burned to the waterline, by something small, quick, and clearly not human.";

    public override string Objective => "Stop whatever is raiding the fishing shacks on Gorvik's ice.";

    public override City City => City.Gorvik;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 45;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override string? TargetCreatureName => "SnowGoblin";
}
