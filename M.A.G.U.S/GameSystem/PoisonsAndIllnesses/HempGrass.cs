using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.PoisonsAndIllnesses;

public class HempGrass : Poison
{
    public override string Name => "Hemp Grass";

    public override Money Price => new(1);

    public override string Description => "Level 2 airborne poison produced by burning a mixture primarily consisting of hemp leaves and sweet tobacco. It affects the nervous system (II.); its effect is rapid and lasts for a medium duration. It causes stupor or sleep. In some areas of Ynev, it is smoked from pipes as a drug. Frequent indulgence causes addiction. For the intoxicated victim, the outside world ceases to exist, leaving only their own buoyant, dream-like world.";

    public override PoisonDuration PoisonDuration => PoisonDuration.MediumDuration;

    public override PoisonOnsetTime PoisonOnsetTime => PoisonOnsetTime.Fast;

    public override PoisonType PoisonType => PoisonType.NervousSystem;

    public override IReadOnlyList<PoisonEffect> PoisonEffects => [PoisonEffect.Sleep, PoisonEffect.Stupor];

    public override int Level => 2;
}
