using MAGUS.Enums;

namespace MAGUS.Extensions;

public static class MagicItemEffectTypeExtensions
{
    /// <summary>
    /// Első Törvénykönyv, "Drágakőmágia": the Mana-point cost of Átlényegítés (turning a mundane
    /// gemstone into a magic-capable one) - "Detekció esetén 50 Mp, Védelem esetén 80 Mp, Okozás
    /// esetén 100 Mp." Paid once, separately from and before the per-E charging cost (1 Mp = 1 E) -
    /// see Character.TryCraftGemstoneWeapon.
    /// </summary>
    public static int TransmutationManaCost(this MagicItemEffectType effectType) => effectType switch
    {
        MagicItemEffectType.Detection => 50,
        MagicItemEffectType.Protection => 80,
        MagicItemEffectType.Causation => 100,
        _ => throw new ArgumentOutOfRangeException(nameof(effectType))
    };
}
