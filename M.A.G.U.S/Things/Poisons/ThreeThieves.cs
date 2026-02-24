using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Poisons;

public class ThreeThieves : Poison
{
    public override string Name => "Three Thieves";

    public override Money Price => new(900);

    public override string Description => "Level 10, multi-component poison. Of Kráni origin, its recipe reportedly comes from Krilehor himself, the thirteenth demigod of Krán. What is certain, however, is that its recipe is strictly secret—Player Characters are unlikely to know it. The first component is a food poison, the second a drink poison, and the third an airborne poison introduced into the system via candle smoke. When all three components are present, the effect is slow but permanent. The poison affects the muscular system (III.) and, in severe cases, results in total paralysis; in milder cases, it causes a weakness that never fades without the use of magic.";

    public override PoisonDuration PoisonDuration => PoisonDuration.Permanent;

    public override PoisonOnsetTime PoisonOnsetTime => PoisonOnsetTime.Slow;

    public override PoisonType PoisonType => PoisonType.MuscularSystem;

    public override IReadOnlyList<PoisonEffect> PoisonEffects => [PoisonEffect.Paralysis, PoisonEffect.Weakness];

    public override int Level => 10;
}
