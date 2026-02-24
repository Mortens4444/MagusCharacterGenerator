using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Poisons;

public class ToronsHell : Poison
{
    public override string Name => "Toron's Hell";

    public override Money Price => new(8);

    public override string Description => "Level 5 agony poison that can be applied to weapons. Upon entering the bloodstream, it exerts an instantaneous effect (IV.) that lasts for a medium duration. The victim suffers from nausea or experiences searing agony, losing 2D10 PTP. This type of poison is crafted by the poison-masters of the Sect of Twins; their assassins use it with great preference. It is sold only on rare occasions.";

    public override PoisonDuration PoisonDuration => PoisonDuration.MediumDuration;

    public override PoisonOnsetTime PoisonOnsetTime => PoisonOnsetTime.Immediate;

    public override PoisonType PoisonType => PoisonType.CirculatorySystem;

    public override IReadOnlyList<PoisonEffect> PoisonEffects => [PoisonEffect.Nausea, PoisonEffect.PtpLoss];

    public override int Level => 5;
}
