using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Boszorkánykör (Boszorkány — Alapvarázslatok, Type: Mentálmágia, Első Törvénykönyv p.202). Lets
/// multiple witches pool their Mana-points and levels into whichever one stands at the circle's
/// center; the pooling mechanic isn't modeled here, this represents only the base ritual's own
/// cost. Book casting time is 10 kör plus a Trance; only the 10 kör shown.
/// </summary>
public sealed class WitchesCircle : ISpell
{
    public string Name => "Witches' circle";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 3;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 100;

    public int DurationInRounds => 60;

    public int GetDamage() => 0;
}
