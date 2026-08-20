using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Hasadék (Boszorkány — Térmágia, Első Törvénykönyv p.231). Opens an 8-láb-long, 6-láb-deep
/// trench in the ground; anyone who fails to dodge falls in and takes the damage.
/// </summary>
public sealed class Chasm : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Chasm";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 12;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 10;

    [DiceThrow(ThrowType._3D6)]
    public int GetDamage() => diceThrow._3D6();
}
