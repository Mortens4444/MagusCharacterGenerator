using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// A Sárkányfiók lehelete (Tűzvarázsló, Első Törvénykönyv p.278). For the spell's duration, the
/// caster can breathe fire like a dragon three times, in a narrow 10-foot cone widening to 3 feet
/// across. Fire-school damage bypasses magic resistance entirely per the rulebook (p.267), hence
/// Power is null.
/// </summary>
public sealed class DragonWhelpBreath : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Dragon whelp's breath";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 34;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 30;

    [DiceThrow(ThrowType._6D6)]
    public int GetDamage() => diceThrow._6D6();
}
