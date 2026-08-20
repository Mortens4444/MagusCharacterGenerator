using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Észlelhetetlenség (Boszorkány — Mentálmágia, Első Törvénykönyv p.216-217). An enhanced form
/// of Witch Invisibility that also masks sound, smell, and mental/astral presence from anyone
/// who fails a Mental resistance roll; only touch can reveal the witch. Book duration is k6 óra
/// (1-6 hours); the average roll is shown rather than randomized.
/// </summary>
public sealed class Undetectability : ISpell
{
    public string Name => "Undetectability";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 1;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 1260;

    public int GetDamage() => 0;
}
