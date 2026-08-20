using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Perzselő tekintet (Tűzvarázsló, Első Törvénykönyv p.278). For the spell's duration, the
/// caster's gaze scorches anything they look at within their zone (roughly 150°C at the focal
/// point), igniting flammables and burning creatures each round. Fire-school damage bypasses
/// magic resistance entirely per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class ScorchingGaze : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Scorching gaze";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 12;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 6;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
