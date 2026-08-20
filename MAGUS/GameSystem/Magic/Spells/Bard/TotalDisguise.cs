using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Teljes álca (Bárd — Fénymágia, Első Törvénykönyv p.147). Like Mask's face-disguise mode, but
/// changes clothing and gear too, and can affect up to 5 + caster level targets at once (not
/// modeled as a multi-target list here). Duration is 10 kör/szint in the book; level-1 baseline
/// shown, not level-scaled.
/// </summary>
public sealed class TotalDisguise : ISpell
{
    public string Name => "Total disguise";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 35;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 100;

    public int GetDamage() => 0;
}
