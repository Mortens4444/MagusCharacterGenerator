using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Tűzalak (Boszorkánymester — Elemi mágia, Első Törvénykönyv p.240-241). Transforms the caster
/// (or a touched creature) into a flying, fire-based form, sheddable only by magical weapons.
/// Duration is kör/szint in the book; level-1 baseline shown, not level-scaled. 1D6 represents
/// the form's touch damage, not a direct attack on cast.
/// </summary>
public sealed class FireForm : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Fire form";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 27;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
