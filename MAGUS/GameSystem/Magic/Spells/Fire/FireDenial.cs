using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűztagadás (Tűzvarázsló, Első Törvénykönyv p.272). A protective touch spell granting immunity
/// to natural and elemental fire and heat damage, including every fire-and-heat-based caster
/// class's damaging spells. Grants defense rather than dealing damage, so Power is null.
/// </summary>
public sealed class FireDenial : ISpell
{
    public string Name => "Fire denial";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 35;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;
}
