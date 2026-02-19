using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.PoisonsAndIllnesses;

public class BlackBlood : Poison
{
    public override string Name => "Black Blood";

    public override Money Price => new(20);

    public override string Description => "Level 6 nerve poison of Gorvikian origin. A thick, black, bitter liquid, most often administered via food. It affects the nervous system, causing stupor or, in more severe cases, death. It is fast-acting and lasts for a short duration if the victim survives.";

    public override PoisonDuration PoisonDuration => PoisonDuration.ShortDuration;

    public override PoisonOnsetTime PoisonOnsetTime => PoisonOnsetTime.Fast;

    public override PoisonType PoisonType => PoisonType.NervousSystem;

    public override IReadOnlyList<PoisonEffect> PoisonEffects => [PoisonEffect.Stupor, PoisonEffect.Death];

    public override int Level => 6;
}
