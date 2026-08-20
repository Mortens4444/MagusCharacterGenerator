using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűzcsapás (Tűzvarázsló, Első Törvénykönyv p.276). An existing fire briefly comes alive and
/// lashes out at a target within 5 steps of it. The book resolves this as the caster's unarmed
/// Támadó dobás (attack roll) at +40, not a dice-rolled damage amount; 1D6 approximates it within
/// this interface's damage model. Fire-school damage bypasses magic resistance entirely per the
/// rulebook (p.267), hence Power is null.
/// </summary>
public sealed class FireStrike : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Fire strike";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 2;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
