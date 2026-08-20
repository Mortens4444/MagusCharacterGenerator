using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűzhullám (Tűzvarázsló, Első Törvénykönyv p.275). Rings of flame radiate outward from the
/// caster to the edge of their zone, one new wave per round, each stronger than the last.
/// Fire-school damage bypasses magic resistance entirely per the rulebook (p.267), hence Power is
/// null.
/// </summary>
public sealed class FireWave : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Fire wave";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 6;

    public int DurationInRounds => 5;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
