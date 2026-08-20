using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Fürkészés (Boszorkány — Bájolás, Első Törvénykönyv p.221-222). Reveals what kind of woman —
/// physically and in character — the touched target desires, and (on a further failed resistance
/// roll) their sexual preferences too.
/// </summary>
public sealed class Probing : ISpell
{
    public string Name => "Probing";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 10;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 2;

    public int GetDamage() => 0;
}
