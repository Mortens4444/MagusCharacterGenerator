using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class DisturbedRuinsAbesar : Quest
{
    public override string Name => "What the Diggers Woke";

    public override string Description => "Relic hunters working the desert ruins near Abesar broke into a sealed chamber - and something has been following their tracks back toward the camp ever since.";

    public override string Objective => "Find out what the relic hunters disturbed, and stop it from reaching the camp.";

    public override City City => City.Abesar;

    public override Money MoneyReward => new(0, 8, 0);

    public override ulong ExperienceReward => 90;

    public override int MinLevel => 4;

    public override int MaxLevel => 6;

    public override string? TargetCreatureName => "GiantScorpion";
}
