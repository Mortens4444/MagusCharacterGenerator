using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Láthatatlanság (Boszorkány — Mentálmágia, Első Törvénykönyv p.216). A mental "won't be
/// perceived" effect rather than true invisibility — the witch stays physically visible but
/// vanishes from the senses of anyone who fails a Mental resistance roll. Book duration is k6
/// óra (1-6 hours); the average roll is shown rather than randomized.
/// </summary>
public sealed class WitchInvisibility : ISpell
{
    public string Name => "Witch invisibility";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 2;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 4;

    public int DurationInRounds => 1260;

    public int GetDamage() => 0;
}
