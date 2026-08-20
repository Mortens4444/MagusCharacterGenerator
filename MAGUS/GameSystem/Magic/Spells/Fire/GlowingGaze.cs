using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Izzó tekintet (Tűzvarázsló, Első Törvénykönyv p.278). Like Scorching gaze, but the focal
/// point reaches roughly 500°C - hot enough to start melting some metals. Fire-school damage
/// bypasses magic resistance entirely per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class GlowingGaze : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Glowing gaze";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 32;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 6;

    [DiceThrow(ThrowType._3D6)]
    public int GetDamage() => diceThrow._3D6();
}
