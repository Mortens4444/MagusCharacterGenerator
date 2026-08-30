namespace MAGUS.Enums;

/// <summary>
/// The three kinds of magical effect a Drágakőmágiával (or Rúnamágiával) készített varázstárgy can be
/// imbued with - Detekció, Védelem, Okozás. Determines the Átlényegítés (Mana-point) cost of turning a
/// mundane gemstone into a magic-capable one - see MagicItemEffectTypeExtensions.TransmutationManaCost.
/// </summary>
public enum MagicItemEffectType
{
    Detection,
    Protection,
    Causation
}
