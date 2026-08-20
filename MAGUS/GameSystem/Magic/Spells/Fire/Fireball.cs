using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűzgolyó (Tűzvarázsló, Első Törvénykönyv p.274). A 1-láb sphere the caster can steer up to 20
/// lépés/round for the duration, dealing damage to anyone it touches. Fire-school damage bypasses
/// magic resistance entirely per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class Fireball : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Fireball";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 6;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 3;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
