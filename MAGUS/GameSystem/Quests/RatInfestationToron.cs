using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class RatInfestationToron : Quest
{
    public override string Name => "Cellar Vermin";

    public override string Description => "A tavern keeper in Toron is losing stock to a swarm of rats nesting beneath the cellar, and none of the local ratcatchers dare go down there anymore.";

    public override string Objective => "Clear out whatever is nesting in the tavern's cellar.";

    public override City City => City.Toron;

    public override Money MoneyReward => new(0, 3, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override string? TargetCreatureName => "Rat";
}
