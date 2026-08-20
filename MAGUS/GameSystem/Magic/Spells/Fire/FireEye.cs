using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűzszem (Tűzvarázsló, Első Törvénykönyv p.281). Egy megjelölt ponton varázsjelet hoz létre,
/// amely érzékeli az arra elhaladókat, és minden alkalommal tűznyilat lő ki rájuk. Fire-school
/// damage bypasses magic resistance entirely per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class FireEye : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Fire eye";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 720;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
