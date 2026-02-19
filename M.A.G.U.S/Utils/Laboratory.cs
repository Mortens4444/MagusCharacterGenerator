using M.A.G.U.S.Enums;

namespace M.A.G.U.S.Utils;

/// <summary>
/// var effects = Laboratory.GetPoisonEffects(PoisonType.DigestiveSystem);
/// </summary>
public static class Laboratory
{
    private static readonly Dictionary<PoisonType, PoisonEffect[]> effectsByType =
        new()
        {
            [PoisonType.DigestiveSystem] =
            [
                PoisonEffect.None,
                PoisonEffect.Nausea,
                PoisonEffect.Malaise,
                PoisonEffect.PtpLoss,
                PoisonEffect.Fainting,
                PoisonEffect.Death
            ],
            [PoisonType.NervousSystem] =
            [
                PoisonEffect.None,
                PoisonEffect.Nausea,
                PoisonEffect.Stupor,
                PoisonEffect.Sleep,
                PoisonEffect.Death
            ],
            [PoisonType.MuscularSystem] =
            [
                PoisonEffect.None,
                PoisonEffect.Weakness,
                PoisonEffect.Cramps,
                PoisonEffect.Paralysis,
                PoisonEffect.Death
            ],
            [PoisonType.CirculatorySystem] =
            [
                PoisonEffect.None,
                PoisonEffect.Nausea,
                PoisonEffect.Dizziness,
                PoisonEffect.PtpLoss,
                PoisonEffect.Fainting,
                PoisonEffect.Death
            ]
        };

    public static IReadOnlyList<PoisonEffect> GetPoisonEffects(PoisonType type) => effectsByType.TryGetValue(type, out var effects) ? effects : [];
}

