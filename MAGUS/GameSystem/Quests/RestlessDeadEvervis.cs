using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class RestlessDeadEvervis : Quest
{
    public override string Name => "What the Well Woke";

    public override string Description => "Whatever tainted Evervis's well didn't stay in the water - the old grave markers behind the chapel have been found disturbed, and something is walking that shouldn't be.";

    public override string Objective => "Put down whatever is walking near Evervis's chapel graveyard.";

    public override City City => City.Evervis;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 55;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override string? TargetCreatureName => "Zombie";
}
