using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class TunnelKoboldsShadon : Quest
{
    public override string Name => "Tunnels Under the Wire";

    public override string Description => "Shadon's border garrison found a tunnel entrance inside their own perimeter fence, freshly dug from below, and whatever's using it to slip supplies past the checkpoints is still down there.";

    public override string Objective => "Clear out whatever is using the tunnel under Shadon's border fence.";

    public override City City => City.Shadon;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 45;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override string? TargetCreatureName => "Kobold";
}
