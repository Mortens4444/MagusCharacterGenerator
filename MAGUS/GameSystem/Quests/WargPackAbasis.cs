using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class WargPackAbasis : Quest
{
    public override string Name => "Wardens of the Grain Road";

    public override string Description => "Herders driving stock along the Abasis grain road have lost three animals in a week to a warg pack grown bold enough to hunt in daylight.";

    public override string Objective => "Drive off or kill the warg pack menacing the grain road.";

    public override City City => City.Abasis;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 50;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override string? TargetCreatureName => "Warg";
}
