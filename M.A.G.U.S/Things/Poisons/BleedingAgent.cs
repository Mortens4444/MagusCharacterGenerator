using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Poisons;

public class BleedingAgent : Poison
{
    public override string Name => "Bleeding Agent";

    public override Money Price => new(12);

    public override string Description => "Level 6 Gorvikian weapon poison. It exerts its instantaneous, one-time effect upon entering the bloodstream (IV.). Whether the case is milder (3D6 PTP) or more severe (6D6 PTP), the victim feels parching agony throughout their entire body (PTP loss). They break out in a cold sweat; their Quickness and Dexterity, regardless of their original values, drop below 10 for five rounds.";

    public override PoisonDuration PoisonDuration => PoisonDuration.SingleEffect;

    public override PoisonOnsetTime PoisonOnsetTime => PoisonOnsetTime.Immediate;

    public override PoisonType PoisonType => PoisonType.CirculatorySystem;

    public override IReadOnlyList<PoisonEffect> PoisonEffects => [PoisonEffect.PtpLoss];

    public override int Level => 6;
}
