using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Izzó csók (Boszorkány — Csókmágia, Első Törvénykönyv p.222, Type: Tűzmágia). The simplest kiss
/// magic: a burning wound at the point of the kiss. Pure Anyagi Mágia, so no resistance roll
/// applies. Book damage can be increased in 1D6 increments up to a 10D6 cap for 5 extra Mana-pont
/// per step; base 1D6 shown, scaling not modeled.
/// </summary>
public sealed class GlowingKiss : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Glowing kiss";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 12;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
