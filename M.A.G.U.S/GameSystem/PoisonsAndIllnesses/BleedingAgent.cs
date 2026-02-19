using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.PoisonsAndIllnesses;

public class BleedingAgent : Poison
{
    public override string Name => "Bleeding Agent";

    public override Money Price => new(12);

    public override string Description => "Level 6 Gorviki weapon poison. It exerts its instantaneous, one-time effect upon entering the bloodstream (IV.). Whether the case is milder (3d6 FP) or more severe (6d6 FP), the victim feels parching agony throughout their entire body (FP loss). They break out in a cold sweat; their Quickness and Dexterity, regardless of their original values, drop below 10 for five rounds.";

    public override PoisonDuration PoisonDuration => PoisonDuration.SingleEffect;

    public override PoisonOnsetTime PoisonOnsetTime => PoisonOnsetTime.Immediate;

    public override PoisonType PoisonType => PoisonType.CirculatorySystem;

    public override IReadOnlyList<PoisonEffect> PoisonEffects => [PoisonEffect.PtpLoss];

    public override int Level => 6;
}
