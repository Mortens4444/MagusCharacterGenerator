using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.PoisonsAndIllnesses;

public class SleepingPill : Poison
{
    public override string Name => "Sleeping Pill";

    public override Money Price => new(0, 5);

    public override string Description => "Level 3 poison affecting the nervous system (II.), which either has no effect or causes sleep. It acts quickly but only for a short duration. It is a slightly greenish gel that can be applied to weapons; its preparation is known to most alchemists.";

    public override PoisonDuration PoisonDuration => PoisonDuration.ShortDuration;

    public override PoisonOnsetTime PoisonOnsetTime => PoisonOnsetTime.Fast;

    public override PoisonType PoisonType => PoisonType.NervousSystem;

    public override IReadOnlyList<PoisonEffect> PoisonEffects => [PoisonEffect.None, PoisonEffect.Sleep];

    public override int Level => 3;
}
