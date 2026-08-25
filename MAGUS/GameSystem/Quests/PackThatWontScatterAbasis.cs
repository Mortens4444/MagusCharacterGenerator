using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class PackThatWontScatterAbasis : Quest
{
    public override string Name => "The Pack That Won't Scatter";

    public override string Description => "A pack of feral dogs has grown too used to Abasis's outskirts, snapping at children on their way to the fields and refusing to be chased off by anything short of a real fight.";

    public override string Objective => "Deal with the feral dog pack on the edge of Abasis.";

    public override City City => City.Abasis;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override string? TargetCreatureName => "WildDog";
}
