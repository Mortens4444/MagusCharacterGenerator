using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Villámvért (Boszorkánymester — Villámmágia, Első Törvénykönyv p.242). A blue-crackling aura
/// of raw energy around the caster or a touched creature; damages anyone who touches the wearer
/// or strikes them with a metal weapon.
/// </summary>
public sealed class LightningArmor : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Lightning armor";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 7;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 3;

    [DiceThrow(ThrowType._1D10)]
    public int GetDamage() => diceThrow._1D10();
}
