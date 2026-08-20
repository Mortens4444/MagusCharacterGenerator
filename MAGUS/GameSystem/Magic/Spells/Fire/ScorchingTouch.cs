using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Perzselő érintés (Tűzvarázsló, Első Törvénykönyv p.284). Same effect as Perzselő tekintet
/// (Scorching gaze), but delivered by a touch of the caster's hand rather than a gaze, and
/// resolved with a successful Támadó dobás (attack roll) instead of a magic-resistance check —
/// hence Power is null here too, but for a different reason than the usual Fire-school
/// resistance bypass (p.267): this is a physical touch attack.
/// </summary>
public sealed class ScorchingTouch : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Scorching touch";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 9;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 6;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
