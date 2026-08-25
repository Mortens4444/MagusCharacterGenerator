using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class SandRaidersAlidax : Quest
{
    public override string Name => "Riders Out of the Dunes";

    public override string Description => "A band out of the deep desert has been hitting the smaller waystations around Alidax, taking water and grain and leaving nothing behind for the caravans that come after.";

    public override string Objective => "Stop the raiders preying on Alidax's waystations.";

    public override City City => City.Alidax;

    public override Money MoneyReward => new(0, 7, 0);

    public override ulong ExperienceReward => 65;

    public override int MinLevel => 3;

    public override int MaxLevel => 5;

    public override string? TargetCreatureName => "SandElf";
}
