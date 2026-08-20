using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Villám tűk (Boszorkánymester — Villámmágia, Első Törvénykönyv p.241). Fires dozens of tiny
/// lightning needles from the caster's palm up to 15 láb away. Duration is 1 kör/szint in the
/// book; level-1 baseline shown, not level-scaled. Book resistance is a Dexterity+Speed check,
/// not magic resistance; Power is null since that mechanic isn't modeled here.
/// </summary>
public sealed class LightningNeedles : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Lightning needles";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 4;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._1D10)]
    public int GetDamage() => diceThrow._1D10();
}
