using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Poisons;

public class CobraBite : Poison
{
    public override string Name => "Cobra Bite";

    public override Money Price => new(12);

    public override string Description => "A complex, Level 5 weapon poison, whose primary component is snake venom. It affects the muscular system (III.). It causes convulsions or death; its effect is instantaneous and, in the case of convulsions, long-lasting. It is mainly produced in the South; it is difficult to obtain and extremely expensive in the North.";

    public override PoisonDuration PoisonDuration => PoisonDuration.LongDuration;

    public override PoisonOnsetTime PoisonOnsetTime => PoisonOnsetTime.Immediate;

    public override PoisonType PoisonType => PoisonType.MuscularSystem;

    public override IReadOnlyList<PoisonEffect> PoisonEffects => [PoisonEffect.Cramps, PoisonEffect.Death];

    public override int Level => 5;
}
