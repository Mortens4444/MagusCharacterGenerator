using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűzvihar (Tűzvarázsló, Első Törvénykönyv p.279). Világító lángfellegek gyűlnek össze az
/// égen, majd tűzeső hullik belőlük egy 1 km átmérőjű területre. Fire-school damage bypasses
/// magic resistance entirely per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class Firestorm : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Firestorm";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 95;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 600;

    public int DurationInRounds => 90;

    [DiceThrow(ThrowType._8D6)]
    public int GetDamage() => diceThrow._8D6();
}
