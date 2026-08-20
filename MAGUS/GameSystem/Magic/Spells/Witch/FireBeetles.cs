using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Tűzbogarak (Boszorkány — Tűzmágia, Első Törvénykönyv p.208). Conjures tiny fire-beetles that
/// unerringly reach their targets. Book conjures up to 1D6 tiny 1-Sp fire beetles per round (max
/// 72), useful mainly for igniting flammables; simplified to a single flat 1D6 roll.
/// </summary>
public sealed class FireBeetles : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Fire beetles";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 7;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 12;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
