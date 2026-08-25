using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class GoblinsInTheSiloRowAbasis : Quest
{
    public override string Name => "Green Raiders in the Silo Row";

    public override string Description => "A band of goblins has taken to cracking open Abasis's grain silos at night, spilling more than they carry off, and the granary masters want them gone before the whole row is picked clean.";

    public override string Objective => "Drive the goblins out of Abasis's silo row.";

    public override City City => City.Abasis;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 40;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override string? TargetCreatureName => "Goblin";
}
