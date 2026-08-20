using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Transz (Boszorkány — Alapvarázslatok, Type: Asztrálmágia, Első Törvénykönyv p.201). Lets the
/// witch chant herself into a trance in which she can move, speak slowly, and cast spells, but
/// cannot fight or exert serious physical effort. Book says this has the same effect as the Pszi
/// Kyr method's identically-named Trance discipline and lasts as long as the witch wishes;
/// approximated as a representative 60-round duration.
/// </summary>
public sealed class WitchTrance : ISpell
{
    public string Name => "Witch trance";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 3;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 900;

    public int DurationInRounds => 60;

    public int GetDamage() => 0;
}
