using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class SewerThievesToron : Quest
{
    public override string Name => "Voices in the Drains";

    public override string Description => "Stallholders in Toron's market have been losing small goods overnight with no sign of forced entry, until one of them heard chittering voices coming up through the drain grate.";

    public override string Objective => "Find and deal with whatever is stealing from Toron's market through the drains.";

    public override City City => City.Toron;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 45;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override string? TargetCreatureName => "Kobold";
}
