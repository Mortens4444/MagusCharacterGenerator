using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Kín okozás (Boszorkány — Mentálmágia, Első Törvénykönyv p.218). Stimulates the target's pain
/// centers on a failed Mental resistance roll. Book inflicts loss of half the target's current
/// (not maximum) Fp — a percentage effect, not a fixed number; a flat 10 is used as a
/// representative approximation, and the accompanying 1-round total incapacitation (can't fight,
/// cast, or use Psi) isn't separately modeled.
/// </summary>
public sealed class InflictPain : ISpell
{
    public string Name => "Inflict pain";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 10;

    public int ManaCost => 20;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 10;
}
