using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Sebzés (Sámán — Zotgejt/Vérszimpatikus mágia, Második Törvénykönyv p.134). Repeatedly stabbing
/// a Zotgejt puppet with a needle or blade opens small but severe, heavily bleeding wounds on the
/// real victim - 1 ÉP plus 1D6 FP per stab, once per shaman level per round - that also permanently
/// lower the victim's max FP by 2D6 until magically or mundanely healed. Collapsed here into a
/// single damage figure combining both pools (1 flat + 1D6).
/// </summary>
public sealed class PuppetWounding : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Puppet wounding";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 44;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 20;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => 1 + diceThrow._1D6();
}
