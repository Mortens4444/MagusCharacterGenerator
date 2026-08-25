using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class GuardianConstructSonnion : Quest
{
    public override string Name => "The Watcher That Woke";

    public override string Description => "Something in Sonnion's ruins is still standing guard after all these centuries - a carved sentinel that turned to track your footsteps as you passed, and hasn't stopped since.";

    public override string Objective => "Deal with the guardian construct before it deals with you.";

    public override City City => City.Sonnion;

    public override Money MoneyReward => new(0, 12, 0);

    public override ulong ExperienceReward => 140;

    public override int MinLevel => 6;

    public override int MaxLevel => 9;

    public override string? TargetCreatureName => "StoneGolem";
}
