using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.PoisonsAndIllnesses;

public class AlBahraKahrem : Poison
{
    public override string Name => "Al Bahra-kahrem (The Death Dance)";

    public override string[] Images => ["al_bahra_kahrem.png"];

    public override Money Price => new(5);

    public override string Description => "Level 3 Jad stimulant. A contact poison in the form of a whitish balm, usually rubbed into the skin at the temples. It is fast-acting and lasts for a medium duration. In more severe cases, it causes death (which appears accidental); in milder cases, it causes a peculiar stupor (this is the desired effect). During the stupor, the modifiers listed under the \"Stupor\" column apply, but exceptionally with a positive instead of a negative sign. However, no attribute may rise above 20. As the effect fades, nausea overcomes the victim.";

    public override PoisonDuration PoisonDuration => PoisonDuration.MediumDuration;

    public override PoisonOnsetTime PoisonOnsetTime => PoisonOnsetTime.Fast;

    public override PoisonType PoisonType => PoisonType.NervousSystem;

    public override IReadOnlyList<PoisonEffect> PoisonEffects => [PoisonEffect.Nausea, PoisonEffect.Stupor, PoisonEffect.Death];

    public override int Level => 3;
}
