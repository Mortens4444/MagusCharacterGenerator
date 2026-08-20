using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Hamvasztó tekintet (Tűzvarázsló, Első Törvénykönyv p.278-279). Like Scorching gaze, but the
/// focal point reaches roughly 2000°C - hot enough to melt metals outright. Fire-school damage
/// bypasses magic resistance entirely per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class IncineratingGaze : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Incinerating gaze";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 44;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 6;

    [DiceThrow(ThrowType._5D6)]
    public int GetDamage() => diceThrow._5D6();
}
