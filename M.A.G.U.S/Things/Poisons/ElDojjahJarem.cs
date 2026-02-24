using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Poisons;

public class ElDojjahJarem : Poison
{
    public override string Name => "El Dojjah Jarem (The Black Scorpion)";

    public override string[] Images => ["the_black_scorpion.png"];

    public override Money Price => new(15);

    public override string Description => "Sand-like, yellowish powder, or a liquid of similar color dissolved in water. It is a level 8, extremely potent agony poison. It affects the digestive system (I.) and results in PTP loss. It is primarily known as a food and drink poison; its weaker effect causes 3D10 PTP loss, while the stronger version causes death. It is one of the few food poisons that can also be applied to weapons, as it poses a serious threat even when absorbed into the bloodstream (II.). In such cases, it causes nausea in milder instances, or fainting otherwise. In both cases, the effect is instantaneous and lasts for a medium duration.";

    public override PoisonDuration PoisonDuration => PoisonDuration.MediumDuration;

    public override PoisonOnsetTime PoisonOnsetTime => PoisonOnsetTime.Immediate;

    public override PoisonType PoisonType => PoisonType.DigestiveSystem;

    public override IReadOnlyList<PoisonEffect> PoisonEffects => [PoisonEffect.Nausea, PoisonEffect.Fainting, PoisonEffect.PtpLoss, PoisonEffect.Death];

    public override int Level => 8;
}
