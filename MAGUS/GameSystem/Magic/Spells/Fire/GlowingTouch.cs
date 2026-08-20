using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Izzó érintés (Tűzvarázsló, Első Törvénykönyv p.285). Same effect as Izzó tekintet (Glowing
/// gaze), but delivered by touch and resolved with a successful Támadó dobás (attack roll)
/// instead of a magic-resistance check — hence Power is null.
/// </summary>
public sealed class GlowingTouch : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Glowing touch";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 20;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 6;

    [DiceThrow(ThrowType._3D6)]
    public int GetDamage() => diceThrow._3D6();
}
