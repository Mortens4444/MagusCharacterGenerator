using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Rémütés (Bárd — Fénymágia, Első Törvénykönyv p.145). Conjures a terrifying illusory monster
/// that chases (but never catches) a chosen target; flavor-only, no combat mechanic given in the
/// book beyond the chase itself.
/// </summary>
public sealed class TerrorPhantom : ISpell
{
    public string Name => "Terror phantom";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 5;

    public int GetDamage() => 0;
}
