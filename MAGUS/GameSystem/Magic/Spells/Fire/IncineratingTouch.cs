using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Hamvasztó érintés (Tűzvarázsló, Első Törvénykönyv p.285). Same effect as Hamvasztó tekintet
/// (Incinerating gaze), but delivered by touch and resolved with a successful Támadó dobás
/// (attack roll) instead of a magic-resistance check — hence Power is null.
/// </summary>
public sealed class IncineratingTouch : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Incinerating touch";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 32;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 6;

    [DiceThrow(ThrowType._5D6)]
    public int GetDamage() => diceThrow._5D6();
}
