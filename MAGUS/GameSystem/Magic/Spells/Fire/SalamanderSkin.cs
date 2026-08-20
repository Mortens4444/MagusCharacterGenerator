using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Szalamandrabőr (Tűzvarázsló, Első Törvénykönyv p.272). A protective touch spell granting heat
/// resistance and a Damage Absorption Value against fire, scaling with the caster's Experience
/// Level. Grants defense rather than dealing damage, so Power is null.
/// </summary>
public sealed class SalamanderSkin : ISpell
{
    public string Name => "Salamander skin";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 10;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;
}
