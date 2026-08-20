using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Kékbábu (Boszorkány — Viaszbábok mágiája, Első Törvénykönyv p.229). Redirects any spell cast
/// on the effigy itself onto the bonded real victim instead (like the Mozaikmágia Tárgyszimpátia
/// mosaic, but reusable by anyone); requires 5 karát of powdered sapphire mixed into the wax.
/// The spell-redirection meta-effect isn't modeled here, this is a flavor-only catalog entry.
/// CastingTimeInSegments/DurationInRounds are nominal placeholders, see WhiteEffigy's note.
/// </summary>
public sealed class BlueEffigy : ISpell
{
    public string Name => "Blue effigy";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 33;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
