using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Távolbalátás (Boszorkány — Térmágia, Misztikus képesség, Első Törvénykönyv p.229). Shows a
/// distant place or person in a crystal ball or water-filled silver bowl. Book duration lasts as
/// long as the witch concentrates; approximated as a long but finite value. Requires a crystal
/// ball/water-filled bowl and prior knowledge of the place or person scried.
/// </summary>
public sealed class Scrying : ISpell
{
    public string Name => "Scrying";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 22;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 30;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
